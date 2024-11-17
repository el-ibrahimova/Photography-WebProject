using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Infrastructure.Data;

namespace Photography.Core.Services
{
    public class BaseService : IBaseService
    {
        private readonly PhotographyDbContext context;

        public BaseService(PhotographyDbContext data)
        {
            context = data;
        }

        public bool IsGuidValid(string? id, ref Guid parsedGuid)
        {
            // non-existing parameter in the URL
            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            // invalid parameter in the URL
            bool isGuidValid = Guid.TryParse(id, out parsedGuid);

            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> IsUserPhotographerAsync(string? userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            bool result = await this.context.Photographers.AnyAsync(m => m.UserId.ToString().ToLower() == userId);

            return result;
        }
    }
}
