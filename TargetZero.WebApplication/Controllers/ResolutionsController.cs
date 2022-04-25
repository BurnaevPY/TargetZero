using Flurl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;
using TargetZero.Domain.Exceptions;
using TargetZero.WebApplication.Authorization;
using TargetZero.WebApplication.Models;

namespace TargetZero.WebApplication.Controllers
{
    [Authorize]
    public class ResolutionsController : Controller
    {
        const string DefaultRedirectAction = "Index";
        const string DefaultRedirectController = "Innovations";

        private readonly ILogger<InnovationsController> _logger;
        private readonly IInnovationRepository _innovationRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFilialRepository _filialRepository;
        private readonly IInnovationStatusRepository _innovationStatusRepository;
        private readonly IResolutionRepository _resolutionRepository;
        private readonly IConsiderationRepository _considerationRepository;

        public ResolutionsController(
            ILogger<InnovationsController> logger,
            IResolutionRepository resolutionRepository,
            IInnovationRepository innovationRepository,
            IFilialRepository filialRepository,
            IInnovationStatusRepository innovationStatusRepository,
            IConsiderationRepository considerationRepository,
            ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _innovationRepository = innovationRepository;
            _categoryRepository = categoryRepository;
            _filialRepository = filialRepository;
            _innovationStatusRepository = innovationStatusRepository;
            _resolutionRepository = resolutionRepository;
            _considerationRepository = considerationRepository;
        }


        private async Task<NewResolutionModel> CreateNewResolutionModel(int innovationId, string returnUrl)
        {
            var innovation = await _innovationRepository.GetAsync(innovationId) ??
                throw new InnovationNotFoundException();
            var history = await _resolutionRepository.GetInnovationResolutionsAsync(innovationId);

            var considerations = await _considerationRepository.GetInnovationConsiderationsAsync(innovationId);

            var model = new NewResolutionModel
            {
                Considerations = considerations.Select(x => ConsiderationModel.ToViewModel(x)),
                InnovationId = innovation.Id,
                Innovation = InnovationCardModel.ToViewModel(innovation),
                History = history.Select(x => ResolutionHistoryModel.ToViewModel(x)),
                ReturnUrl = returnUrl
            };

            return model;
        }

        private async Task RestoreNewResolutionModel(NewResolutionModel model)
        {
            var innovation = await _innovationRepository.GetAsync(model.InnovationId) ??
                throw new InnovationNotFoundException();
            var history = await _resolutionRepository.GetInnovationResolutionsAsync(model.InnovationId);

            var considerations = await _considerationRepository.GetInnovationConsiderationsAsync(model.InnovationId);

            model.Considerations = considerations.Select(x => ConsiderationModel.ToViewModel(x));
            model.Innovation = InnovationCardModel.ToViewModel(innovation);
            model.History = history.Select(x => ResolutionHistoryModel.ToViewModel(x));
        }

        private async Task SaveResolution(NewResolutionModel model, int innovationStatusId) 
        {
            var innovation = await _innovationRepository.GetAsync(model.InnovationId) ??
                throw new InnovationNotFoundException();

            var innovationStatus = await _innovationStatusRepository.GetAsync(innovationStatusId) ??
                throw new InnovationStatusnNotFoundException();

            var author = User.Identity.Name;

            var resolution = Resolution.Create(innovation.Id, innovationStatus, author, model.ExcecutionTime, model.Content);
            _resolutionRepository.Insert(resolution);

            innovation.SetInnovationStatus(innovationStatus);
            _innovationRepository.Update(innovation);

            await _resolutionRepository.UnitOfWork.SaveChangesAsync();
        }

        [HttpGet]
        [Authorize(Policy = nameof(DecisionAccess))]
        public async Task<IActionResult> New(int innovationId)
        {
            var uri = new Uri(Request.Headers["Referer"].ToString());
            var returnUrl = uri.PathAndQuery;

            var model = await CreateNewResolutionModel(innovationId, returnUrl);
            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = nameof(DecisionAccess))]
        public async Task<IActionResult> Accept(NewResolutionModel model)
        {
            if (!ModelState.IsValid)
            {
                await RestoreNewResolutionModel(model);
                return View(model);
            }

            await SaveResolution(model, InnovationStatus.Accepted.Id);

            var url = model.ReturnUrl.SetQueryParam(Options.ScrollParameter, model.InnovationId);
            if (Url.IsLocalUrl(url))
            {
                return Redirect(url);
            }


            return RedirectToAction(DefaultRedirectAction, DefaultRedirectController);
        }

        [HttpPost]
        [Authorize(Policy = nameof(DecisionAccess))]
        public async Task<IActionResult> Reject(NewResolutionModel model)
        {
            if (!ModelState.IsValid)
            {
                await RestoreNewResolutionModel(model);
                return View(model);
            }

            await SaveResolution(model, InnovationStatus.Rejected.Id);

            var url = model.ReturnUrl.SetQueryParam(Options.ScrollParameter, model.InnovationId);
            if (Url.IsLocalUrl(url))
            {
                return Redirect(url);
            }


            return RedirectToAction(DefaultRedirectAction, DefaultRedirectController);
        }

        [HttpPost]
        [Authorize(Policy = nameof(DecisionAccess))]
        public async Task<IActionResult> Rework(NewResolutionModel model)
        {
            if (!ModelState.IsValid)
            {
                await RestoreNewResolutionModel(model);
                return View(model);
            }

            await SaveResolution(model, InnovationStatus.Rework.Id);

            var url = model.ReturnUrl.SetQueryParam(Options.ScrollParameter, model.InnovationId);
            if (Url.IsLocalUrl(url))
            {
                return Redirect(url);
            }


            return RedirectToAction(DefaultRedirectAction, DefaultRedirectController);
        }

        [HttpPost]
        [Authorize(Policy = nameof(DecisionAccess))]
        public async Task<IActionResult> Implemented(NewResolutionModel model)
        {
            if (!ModelState.IsValid)
            {
                await RestoreNewResolutionModel(model);
                return View(model);
            }

            await SaveResolution(model, InnovationStatus.Implemented.Id);

            var url = model.ReturnUrl.SetQueryParam(Options.ScrollParameter, model.InnovationId);
            if (Url.IsLocalUrl(url))
            {
                return Redirect(url);
            }


            return RedirectToAction(DefaultRedirectAction, DefaultRedirectController);
        }


    }
}
