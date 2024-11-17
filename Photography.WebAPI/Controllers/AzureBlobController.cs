using Microsoft.AspNetCore.Mvc;
using Photography.WebAPI.Interface;

namespace Photography.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AzureBlobController : ControllerBase
    {
        private readonly IBlobService blobService;

        public AzureBlobController(IBlobService _blobService)
        {
            blobService = _blobService;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, string containerName)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var fileUrl = await blobService.UploadFileAsync(file, containerName);

            // return uploaded photo URL
            return Ok(new { Url = fileUrl });
        }
    }
}
