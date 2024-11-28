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
                    Name = ps.Name,
                    ImageUrl1 = ps.ImageUrl1,
                    ImageUrl2 = ps.ImageUrl2,
                    ImageUrl3 = ps.ImageUrl3,
                    Description = ps.Description,
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

        public async Task AddParticipantToPhotoShoot(Guid photoShootIdGuid, Guid userIdGuid)
        {
            PhotoShoot? photoShoot = await context
                .PhotoShoots.Where(ps => ps.Id == photoShootIdGuid && ps.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (photoShoot == null)
            {
                throw new InvalidOperationException("Фотосесията не е намерена.");
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
        }

    }
}
