namespace Photography.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Attributes;
    using Core.Interfaces;
    using Core.ViewModels.PhotoShoot;
    using Extensions;
    using Infrastructure.Data.Models;
    using static Common.ApplicationConstants;
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
            Guid userIdGuid = Guid.NewGuid();
            if (!IsGuidValid(GetUserId(), ref userIdGuid))
            {
                return Unauthorized();
            }

            var model = new AddPhotoShootViewModel();

            Guid photographerIdGuid = await photoShootService.GetPhotographerIdByUserIdAsync(GetUserId());

            if (photographerIdGuid == Guid.Empty)
            {
                return Unauthorized();
            }

            model.PhotographerId = photographerIdGuid.ToString();

            return View(model);
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

            TempData[SuccessMessage] = "Успешно добавихте фотосесия";
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

            Guid userIdGuid = Guid.Empty;
            if (!IsGuidValid(GetUserId(), ref userIdGuid))
            {
                return Unauthorized();
            }

            IEnumerable<AllPhotoShootsViewModel> photoShoots = await photoShootService.GetAllPhotoShootsForManageAsync();

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

            var model = await photoShootService.GetPhotoShootToEditAsync(id);
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

                Guid userIdGuid = Guid.Empty;
                if (!IsGuidValid(model.Id, ref userIdGuid))
                {
                    return Unauthorized();
                }

                EditPhotoShootViewModel? photoShoot = await photoShootService.GetPhotoShootToEditAsync(model.Id);

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

            DeletePhotoShootViewModel? model = await photoShootService.GetPhotoShootToDelete(id);

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


            bool isDeleted = await photoShootService.DeletePhotoShootAsync(model.Id);

            if (!isDeleted)
            {
                return BadRequest();
            }

            TempData[SuccessMessage] = "Успешно изтрихте фотосесия";
            return RedirectToAction("Manage", "PhotoShoot");
        }


        [HttpPost]
        public async Task<IActionResult> DeclareParticipation(string id)
        {
            Guid photoShootIdGuid = Guid.Empty;
            if (!IsGuidValid(id, ref photoShootIdGuid))
            {
                return NotFound();
            }

            Guid userIdGuid = Guid.Empty;
            if (!IsGuidValid(GetUserId(), ref userIdGuid))
            {
                return Unauthorized();
            }

            PhotoShoot? photoShoot = await photoShootService.GetPhotoShootByIdAsync(id);
            if (photoShoot == null)
            {
                return NotFound();
            }

            bool hasUserDeclared = await photoShootService.HasUserDeclaredParticipationAsync(id, GetUserId());

            if (hasUserDeclared)
            {
                TempData["Message"] = $"Вече заявихте участие за фотосесия \"{photoShoot.Name}\"";
            }
            else
            {
                TempData["Message"] = $"Вие успешно се записахте за фотосесия \"{photoShoot.Name}\"";
            }

            bool result = await photoShootService.AddParticipantToPhotoShoot(id, GetUserId());

            if (result == false)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> UserPhotoShoots()
        {
            Guid userIdGuid = Guid.Empty;
            if (!IsGuidValid(GetUserId(), ref userIdGuid))
            {
                return Unauthorized();
            }

            IEnumerable<UserPhotoShootsViewModel> model = await photoShootService.GetUserPhotoShootsAsync(GetUserId());

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeclineParticipation(string id)
        {
            string userId = GetUserId();

            var isRemoved = await photoShootService.RemoveUserFromParticipation(userId, id);
            if (isRemoved == false)
            {
                return RedirectToAction(nameof(UserPhotoShoots));
            }

            TempData[InfoMessage] = "Успешно отказахте участие във фотосесия";
            return RedirectToAction(nameof(UserPhotoShoots));
        }
    }
}
