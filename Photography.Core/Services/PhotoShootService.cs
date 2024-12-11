namespace Photography.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Interfaces;
    using ViewModels.PhotoShoot;
    using Infrastructure.Data;
    using Infrastructure.Data.Models;
    using System.Globalization;
    using static Common.ApplicationConstants;
    public class PhotoShootService : BaseService, IPhotoShootService
    {
        private readonly PhotographyDbContext context;

        public PhotoShootService(PhotographyDbContext data)
            : base(data)
        {
            context = data;
        }
        
        public async Task<IEnumerable<AllPhotoShootsViewModel>> GetAllPhotoShootsAsync()
        {
            return await context.PhotoShoots
                  .AsNoTracking()
                  .Where(ps => ps.IsDeleted == false)
                  .OrderBy(ps => ps.CreatedAt)
                  .Select(ps => new AllPhotoShootsViewModel()
                  {
                      Id = ps.Id.ToString(),
                      Name = ps.Name,
                      ImageUrl1 = ps.ImageUrl1,
                      ImageUrl2 = ps.ImageUrl2,
                      ImageUrl3 = ps.ImageUrl3,
                      Description = ps.Description,
                      PhotographerId = ps.PhotographerId.ToString()
                  })
                  .ToArrayAsync();
        }

        public async Task<IEnumerable<AllPhotoShootsViewModel>> GetAllPhotoShootsForManageAsync()
        {
            var viewModel = await context.PhotoShoots
                 .Where(ps => ps.IsDeleted == false)
                 .Include(ps => ps.Participants)
                 .ThenInclude(p => p.User)
                 .Select(ps => new AllPhotoShootsViewModel()
                 {
                     Id = ps.Id.ToString(),
                     Name = ps.Name,
                     PhotographerId = ps.PhotographerId.ToString(),
                     PhotographerBrandName = context
                         .Photographers
                         .Where(p => p.Id.ToString().ToLower() == ps.PhotographerId.ToString().ToLower()).Select(p => p.BrandName)
                         .FirstOrDefault()!
                         .ToString(),

                     ImageUrl1 = ps.ImageUrl1,
                     ImageUrl2 = ps.ImageUrl2,
                     ImageUrl3 = ps.ImageUrl3,
                     Description = ps.Description,
                     Participants = ps.Participants.Select(p => new ParticipantViewModel()
                                                     {
                                                         UserName = p.User.UserName!,
                                                         PhoneNumber = p.User.PhoneNumber!
                                                     }).ToArray()
                 })
                 .ToArrayAsync();

            return viewModel;
        }

        public async Task<bool> AddPhotoShootAsync(AddPhotoShootViewModel model)
        {
            DateTime createdAt;

            if (!DateTime.TryParseExact(model.CreatedAt, 
                                        EntityDateFormat, 
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, 
                                        out createdAt))
            {
                return false;
            }

            PhotoShoot photoShoot = new PhotoShoot()
            {
                Name = model.Name,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                ImageUrl3 = model.ImageUrl3,
                Description = model.Description,
                PhotographerId = Guid.Parse(model.PhotographerId),
                CreatedAt = createdAt
            };

            await context.PhotoShoots.AddAsync(photoShoot);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HasUserDeclaredParticipationAsync(string photoShootId, string userId)
        {
            return await context.PhotoShootParticipants
                .AnyAsync(ph => ph.PhotoShootId.ToString().ToLower() == photoShootId.ToLower() 
                                               && ph.UserId.ToString().ToLower() == userId.ToLower());
        }

        public async Task<bool> AddParticipantToPhotoShoot(string photoShootId, string userId)
        {
            PhotoShoot? photoShoot = await context
                .PhotoShoots.Where(ps => ps.Id.ToString().ToLower() == photoShootId.ToLower() && ps.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (photoShoot == null)
            {
                return false;
            }

            bool hasUserDeclared = await context
                .PhotoShootParticipants.AnyAsync(p => p.PhotoShootId.ToString().ToLower() == photoShootId.ToLower() 
                                                                     && p.UserId.ToString().ToLower() == userId.ToLower());

            if (!hasUserDeclared)
            {
                context.PhotoShootParticipants.Add(new PhotoShootParticipant()
                {
                    PhotoShootId = Guid.Parse(photoShootId),
                    UserId = Guid.Parse(userId)
                });

                await context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<IEnumerable<UserPhotoShootsViewModel>> GetUserPhotoShootsAsync(string userId)
        {
            return await context.PhotoShootParticipants
                .AsNoTracking()
                .Where(pp => pp.UserId.ToString().ToLower() == userId.ToLower() && pp.PhotoShoot.IsDeleted == false)
                .Select(pp => new UserPhotoShootsViewModel()
                {
                    Id = pp.PhotoShoot.Id.ToString(),
                    ImageUrl1 = pp.PhotoShoot.ImageUrl1,
                    ImageUrl2 = pp.PhotoShoot.ImageUrl2,
                    ImageUrl3 = pp.PhotoShoot.ImageUrl3,
                    Name = pp.PhotoShoot.Name,
                    Description = pp.PhotoShoot.Description,
                    PhotographerId = pp.PhotoShoot.PhotographerId.ToString()
                })
                .ToListAsync();
        }

        public async Task<bool> RemoveUserFromParticipation(string userId, string photoShootId)
        {
            PhotoShoot? photoShoot = await context.PhotoShoots
                .Where(p => p.Id.ToString().ToLower() == photoShootId.ToLower() && !p.IsDeleted)
                .Include(p => p.Participants)
                .FirstOrDefaultAsync();

            var user = await context.PhotoShootParticipants
                .Where(u => u.UserId.ToString().ToLower() == userId.ToLower())
                .FirstOrDefaultAsync();

            if (photoShoot == null || user == null)
            {
                return false;
            }

            context.PhotoShootParticipants.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<EditPhotoShootViewModel?> GetPhotoShootToEditAsync(string photoShootId)
        {
            PhotoShoot? photoShoot = await context.PhotoShoots
                .Where(ps => !ps.IsDeleted && ps.Id.ToString().ToLower() == photoShootId.ToLower())
                .FirstOrDefaultAsync();

            if (photoShoot == null)
            {
                return null;
            }

            var model = new EditPhotoShootViewModel()
            {
                Id = photoShoot.Id.ToString(),
                Name = photoShoot.Name,
                Description = photoShoot.Description,
                ImageUrl1 = photoShoot.ImageUrl1,
                ImageUrl2 = photoShoot.ImageUrl2,
                ImageUrl3 = photoShoot.ImageUrl3,
                PhotographerId = photoShoot.PhotographerId.ToString()
            };

            return model;
        }

        public async Task<bool> EditPhotoShootAsync(EditPhotoShootViewModel model)
        {
            Guid photoShootIdGuid = Guid.Empty;
            if (!IsGuidValid(model.Id, ref photoShootIdGuid))
            {
                return false;
            }

            PhotoShoot? photoShoot = await context.PhotoShoots
                .Where(ps => !ps.IsDeleted && ps.Id.ToString().ToLower() == model.Id.ToLower() 
                                                    && model.PhotographerId.ToLower() == ps.PhotographerId.ToString().ToLower())
                .FirstOrDefaultAsync();

            if (photoShoot == null)
            {
                return false;
            }

            photoShoot.Name = model.Name;
            photoShoot.Description = model.Description;
            photoShoot.ImageUrl1 = model.ImageUrl1;
            photoShoot.ImageUrl2 = model.ImageUrl2;
            photoShoot.ImageUrl3 = model.ImageUrl3;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<PhotoShoot?> GetPhotoShootByIdAsync(string photoId)
        {
            return await context.PhotoShoots.FirstOrDefaultAsync(ps => ps.Id.ToString().ToLower() == photoId.ToLower() && ps.IsDeleted == false);
        }

        public async Task<DeletePhotoShootViewModel?> GetPhotoShootToDelete(string photoShootId)
        {
            return await context.PhotoShoots
                .AsNoTracking()
                .Where(p => p.Id.ToString().ToLower() == photoShootId.ToLower() && !p.IsDeleted)
                .Select(p => new DeletePhotoShootViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    IsDeleted = p.IsDeleted,
                    PhotographerId = p.PhotographerId.ToString()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DeletePhotoShootAsync(string photoShootId)
        {
            PhotoShoot? photoShootToDelete = await context.PhotoShoots
                .FirstOrDefaultAsync(p => p.Id.ToString().ToLower() == photoShootId.ToLower() && p.IsDeleted == false);

            if (photoShootToDelete == null)
            {
                return false;
            }

            photoShootToDelete.IsDeleted = true;

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Guid> GetPhotographerIdByUserIdAsync(string userId)
        {
            Photographer? photographer = await context.Photographers
                .Include(p => p.User)
                .Where(p => p.UserId.ToString().ToLower() == userId.ToLower())
                .FirstOrDefaultAsync();

            if (photographer == null)
            {
                return Guid.Empty;
            }

            return photographer.Id;
        }

        public async Task<bool> IsPhotoShootOwnedByPhotographerAsync(string photoShootId, string userId)
        {
            Guid photoShootIdGuid = Guid.Empty;
            if (!IsGuidValid(photoShootId, ref photoShootIdGuid))
            {
                return false;
            }

            var photographer = await context.Photographers.Include(p => p.PhotoShoots)
                .Where(p => p.UserId.ToString().ToLower() == userId.ToLower())
                .FirstOrDefaultAsync();


            if (photographer == null)
            {
                return false;
            }

            bool isOwner = photographer.PhotoShoots.Any(ps => ps.Id.ToString().ToLower() == photoShootId.ToLower());

            return isOwner;
        }
    }
}
