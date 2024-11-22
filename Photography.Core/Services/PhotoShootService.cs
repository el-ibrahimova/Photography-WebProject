using Photography.Core.Interfaces;
using Photography.Infrastructure.Data;

namespace Photography.Core.Services
{
    public class PhotoShootService:BaseService, IPhotoShootService
    {
        private readonly PhotographyDbContext context;

        public PhotoShootService(PhotographyDbContext data)
            : base(data)
        {
            context = data;
        }
       
    }
}
