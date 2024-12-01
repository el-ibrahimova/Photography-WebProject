using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.PhotoShoot;
using Photography.Infrastructure.Data;
using Photography.Infrastructure.Data.Models;
using System.Globalization;

namespace Photography.Core.Services
{
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
                  .OrderBy(ps=>ps.CreatedAt.Hour)
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
            var participant = await context.PhotoShoots
                .Include(ps => ps.Participants)
                .ThenInclude(p => p.User)
                .Where(ps => ps.IsDeleted == false)
                .Select(ps => new AllPhotoShootsViewModel()
                {
                    Id = ps.Id.ToString(),
                    Name = ps.Name,
                    ImageUrl1 = ps.ImageUrl1,
                    ImageUrl2 = ps.ImageUrl2,
                    ImageUrl3 = ps.ImageUrl3,
                    Description = ps.Description,
                    PhotographerId = ps.PhotographerId.ToString(),
                    Participants = ps.Participants.Select(p => new ParticipantViewModel()
                    {
                        UserName = p.User.UserName,
                        PhoneNumber = p.User.PhoneNumber
                    }).ToArray()
                })
                .ToArrayAsync();

            return participant;
        }

        public async Task<bool> AddPhotoShootAsync(AddPhotoShootViewModel model)
        {
            DateTime createdAt;

            if (!DateTime.TryParseExact(model.CreatedAt, EntityDateFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out createdAt))
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
                PhotographerId = Guid.Parse(model.PhotographerId)
            };

            await context.PhotoShoots.AddAsync(photoShoot);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HasUserDeclaredParticipationAsync(Guid photoShootIdGuid, Guid userIdGuid)
        {
            return await context.PhotoShootParticipants
                .AnyAsync(ph => ph.PhotoShootId == photoShootIdGuid && ph.UserId == userIdGuid);
        }

        public async Task<bool> AddParticipantToPhotoShoot(Guid photoShootIdGuid, Guid userIdGuid)
        {
            PhotoShoot? photoShoot = await context
                .PhotoShoots.Where(ps => ps.Id == photoShootIdGuid && ps.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (photoShoot == null)
            {
                return false;
            }

            bool hasUserDeclared = await context
                .PhotoShootParticipants.AnyAsync(p => p.PhotoShootId == photoShootIdGuid && p.UserId == userIdGuid);

            if (!hasUserDeclared)
            {
                context.PhotoShootParticipants.Add(new PhotoShootParticipant()
                {
                    PhotoShootId = photoShootIdGuid,
                    UserId = userIdGuid
                });
                
                await context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<IEnumerable<UserPhotoShootsViewModel>> GetUserPhotoShootsAsync(string userId)
        {
            return await context.PhotoShootParticipants
                .AsNoTracking()
                .Where(fp => fp.UserId.ToString() == userId && fp.PhotoShoot.IsDeleted == false)
                .Select(fp => new UserPhotoShootsViewModel()
                {
                    Id = fp.PhotoShoot.Id.ToString(),
                    ImageUrl1 = fp.PhotoShoot.ImageUrl1,
                    ImageUrl2 = fp.PhotoShoot.ImageUrl2,
                    ImageUrl3 = fp.PhotoShoot.ImageUrl3,
                    Name = fp.PhotoShoot.Name,
                    Description = fp.PhotoShoot.Description,
                    PhotographerId = fp.PhotoShoot.PhotographerId.ToString()
                })
                .ToListAsync();
        }

        public async Task<bool> RemoveUserFromParticipation(string userId, string photoShootId)
        {
            PhotoShoot? photoShoot = await context.PhotoShoots
                .Where(p => !p.IsDeleted && p.Id.ToString() == photoShootId)
                .Include(p => p.Participants)
                .FirstOrDefaultAsync();

            var user = await context.PhotoShootParticipants
                .Where(u => u.UserId.ToString() == userId)
                .FirstOrDefaultAsync();

            if (photoShoot == null || user == null)
            {
                return false;
            }

            context.PhotoShootParticipants.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<EditPhotoShootViewModel> GetPhotoShootToEditAsync(Guid photoShootGuid, Guid userGuid)
        {
                var photoShoot = await context.PhotoShoots
                    .Where(ps => ps.IsDeleted == false && ps.Id == photoShootGuid && userGuid ==ps.PhotographerId )
                    .FirstOrDefaultAsync();

                if (photoShoot == null)
                {
                    throw new ArgumentException("Фотосесията не съществува");
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
            if (!Guid.TryParse(model.Id, out Guid photoShootIdGuid))
            {
                return false;
            }

            var photoShoot = await context.PhotoShoots
                .Where(ps => !ps.IsDeleted && ps.Id == photoShootIdGuid && model.PhotographerId ==ps.PhotographerId.ToString())
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

        public async Task<PhotoShoot?> GetPhotoShootByIdAsync(Guid photoIdGuid)
        {
            return await context.PhotoShoots.FirstOrDefaultAsync(ps => ps.Id == photoIdGuid);
        }

        public async Task<DeletePhotoShootViewModel?> GetPhotoShootDelete(string photoShootId)
        {
            return await context.PhotoShoots
                .AsNoTracking()
                .Where(p => p.IsDeleted == false && p.Id.ToString() == photoShootId)
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
                .FirstOrDefaultAsync(p => p.Id.ToString() == photoShootId);

            if (photoShootToDelete== null)
            {
                return false;
            }

            photoShootToDelete.IsDeleted = true;

            await context.SaveChangesAsync();
            return true;
        }
    }
}
