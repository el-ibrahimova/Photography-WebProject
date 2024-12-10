using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Attributes;
using Photography.Core.Interfaces;
using Photography.Core.Services;
using Photography.Core.ViewModels.PhotoShoot;
using Photography.Extensions;
using Photography.Infrastructure.Data.Models;


namespace Photography.Controllers
{
    public class PhotoShootController : BaseController
    {
        private readonly IPhotoShootService photoShootService;
        private readonly IPhotoService photoService;

        public PhotoShootController(IPhotoShootService _photoShootService, IPhotoService _photoService)
        {
            photoShootService = _photoShootService;
            photoService = _photoService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<AllPhotoShootsViewModel> model = await photoShootService.GetAllPhotoShootsAsync();
            return View(model);
        }

        [HttpGet]
        [MustBePhotographer]
        public async Task<IActionResult> Add()
        {
            string userId = GetUserId();

            Guid userIdGuid = Guid.NewGuid();
            if (!IsGuidValid(userId, ref userIdGuid))
            {
                return Unauthorized();
            }

            var model = new AddPhotoShootViewModel();

            Guid photographerIdGuid = await photoShootService.GetPhotographerIdByUserIdAsync(userIdGuid);

            if (photographerIdGuid == Guid.Empty)
            {
                return Unauthorized();
            }

            model.PhotographerId = photographerIdGuid.ToString();

            return this.View(model);
        }

        [HttpPost]
        [MustBePhotographer]
        public async Task<IActionResult> Add(AddPhotoShootViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isAdded = await photoShootService.AddPhotoShootAsync(model);

            if (isAdded == false)
            {
                return View(model);
            }

            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            bool isPhotographer = await photoShootService.IsUserPhotographerAsync(GetUserId());

            if (!User.IsAdmin() && !isPhotographer)
            {
                return Unauthorized();
            }

            Guid userIdGuid=Guid.Empty;
            if (!IsGuidValid(GetUserId(), ref userIdGuid))
            {
                return Unauthorized();
            }

            IEnumerable<AllPhotoShootsViewModel> photoShoots = await photoShootService.GetAllPhotoShootsForManageAsync(userIdGuid);

            return View(photoShoots);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());
            bool isOwner = await photoShootService.IsPhotoShootOwnedByPhotographerAsync(id, GetUserId());

            if (!isPhotographer && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (isPhotographer && !isOwner)
            {
                return Unauthorized();
            }


            Guid photoShootGuid = Guid.Empty;
            if (!IsGuidValid(id, ref photoShootGuid))
            {
                return NotFound();
            }

            Guid userIdGuid = Guid.Empty;
            if (!IsGuidValid(GetUserId(), ref userIdGuid))
            {
                return Unauthorized();
            }
            
            var photographerIdGuid = await photoShootService.GetPhotographerIdByUserIdAsync(userIdGuid);

            if (photographerIdGuid == Guid.Empty)
            {
                return Unauthorized();
            }

           var model  = await photoShootService.GetPhotoShootToEditAsync(photoShootGuid, photographerIdGuid);
           if (model == null)
           {
               return BadRequest();
           }

           return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPhotoShootViewModel model)
        {
            bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());
            bool isOwner = await photoShootService.IsPhotoShootOwnedByPhotographerAsync(model.Id, GetUserId());

            if (!isPhotographer && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (isPhotographer && !isOwner)
            {
                return Unauthorized();
            }

            var result = await photoShootService.EditPhotoShootAsync(model);

            if (!result)
            {
                Guid photoShootGuid = Guid.Empty;
                if (!IsGuidValid(model.Id, ref photoShootGuid))
                {
                    return NotFound();
                }

                string currentUserId = GetUserId();
                Guid userIdGuid = Guid.Empty;
                if (!IsGuidValid(model.Id, ref userIdGuid))
                {
                    return Unauthorized();
                }

                Guid photographerIdGuid = await photoShootService.GetPhotographerIdByUserIdAsync(userIdGuid);

                if (photographerIdGuid == Guid.Empty)
                {
                    return Unauthorized();
                }

                EditPhotoShootViewModel? photoShoot = await photoShootService.GetPhotoShootToEditAsync(photoShootGuid, photographerIdGuid);

                if (photoShoot == null)
                {
                    return BadRequest();
                }

                return View(photoShoot);
            }

            return RedirectToAction("Manage", "PhotoShoot");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());
            bool isOwner = await photoShootService.IsPhotoShootOwnedByPhotographerAsync(id, GetUserId());

            if (!isPhotographer && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (isPhotographer && !isOwner)
            {
                return Unauthorized();
            }

            Guid photoShootIdGuid = Guid.Empty;
            if (!IsGuidValid(id, ref photoShootIdGuid))
            {
                return Unauthorized();
            }

            DeletePhotoShootViewModel? model = await photoShootService.GetPhotoShootToDelete(photoShootIdGuid);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeletePhotoShootViewModel model)
        {
            bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());
            bool isOwner = await photoShootService.IsPhotoShootOwnedByPhotographerAsync(model.Id, GetUserId());

            if (!isPhotographer && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (isPhotographer && !isOwner)
            {
                return Unauthorized();
            }


            bool isDeleted= await photoShootService.DeletePhotoShootAsync(model.Id);

          if (!isDeleted)
          {
              return BadRequest();
          }

            return RedirectToAction("Manage", "PhotoShoot");
        }


        [HttpPost]
        public async Task<IActionResult> DeclareParticipation(string id)
        {
            Guid photoShootIdGuid=Guid.Empty;
            if (!IsGuidValid(id, ref photoShootIdGuid))
            {
                return NotFound();
            }

            string currentUserId = GetUserId();

            Guid userIdGuid=Guid.Empty;
            if (!IsGuidValid(currentUserId, ref userIdGuid))
            {
                return Unauthorized();
            }

            PhotoShoot? photoShoot = await photoShootService.GetPhotoShootByIdAsync(photoShootIdGuid);
            if (photoShoot == null)
            {
                return NotFound();
            }

            bool hasUserDeclared = await photoShootService.HasUserDeclaredParticipationAsync(photoShootIdGuid, userIdGuid);

            if (hasUserDeclared)
            {
                TempData["Message"] = $"Вече заявихте участие за фотосесия \"{photoShoot.Name}\"";
            }
            else
            {
                TempData["Message"] = $"Вие успешно се записахте за фотосесия \"{photoShoot.Name}\"";
            }

            bool result = await photoShootService.AddParticipantToPhotoShoot(photoShootIdGuid, userIdGuid);

            if (result == false)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> UserPhotoShoots()
        {
            string userId = GetUserId();

            Guid userIdGuid=Guid.Empty;
            if (!IsGuidValid(userId, ref userIdGuid))
            {
                return Unauthorized();
            }

            IEnumerable<UserPhotoShootsViewModel> model = await photoShootService.GetUserPhotoShootsAsync(userIdGuid);

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> DeclineParticipation(string id)
        {
            string userId = GetUserId();

            var isRemoved = await photoShootService.RemoveUserFromParticipation(userId, id);
            if(isRemoved==false)
            {
                return RedirectToAction(nameof(UserPhotoShoots));
            }

            return RedirectToAction(nameof(UserPhotoShoots));
        }
    }
}
