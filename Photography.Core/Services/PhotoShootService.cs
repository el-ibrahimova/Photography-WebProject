﻿using Microsoft.EntityFrameworkCore;
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
                  .Select(ps => new AllPhotoShootsViewModel()
                  {
                      Id = ps.Id.ToString(),
                      Name = ps.Name,
                      ImageUrl1 = ps.ImageUrl1,
                      ImageUrl2 = ps.ImageUrl2,
                      ImageUrl3 = ps.ImageUrl3,
                      Description = ps.Description
                  })
                  .ToArrayAsync();
        }

        public async Task AddPhotoShootAsync(AddPhotoShootViewModel model)
        {
            DateTime createdAt;

            if (!DateTime.TryParseExact(model.CreatedAt, EntityDateFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out createdAt))
            {
                throw new InvalidOperationException($"Невалиден формат за дата. Датата трябва да бъде във формат: {EntityDateFormat}");
            }

            PhotoShoot photoShoot = new PhotoShoot()
            {
                Name = model.Name,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                ImageUrl3 = model.ImageUrl3,
                Description = model.Description,
                CreatedAt =createdAt
            };

            await context.AddAsync(photoShoot);
            await context.SaveChangesAsync();
        }

        public async Task<bool> HasUserDeclaredParticipationAsync(Guid photoShootIdGuid, Guid userIdGuid)
        {
            return await context.PhotoShootParticipants
                .AnyAsync(ph => ph.PhotoShootId == photoShootIdGuid && ph.UserId == userIdGuid);
        }
    }
}