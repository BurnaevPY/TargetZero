using Flurl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;
using TargetZero.Domain.Exceptions;
using TargetZero.WebApplication.Authorization;
using TargetZero.WebApplication.Exceptions;
using TargetZero.WebApplication.Models;
using TargetZero.WebApplication.Services;

namespace TargetZero.WebApplication.Controllers
{
    [Authorize]
    public class ConsiderationsController : Controller
    {
        const string DefaultRedirectAction = "Index";
        const string DefaultRedirectController = "Innovations";

        private readonly ILogger<InnovationsController> _logger;
        private readonly IIdentityService _identityService;
        private readonly IInnovationRepository _innovationRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFilialRepository _filialRepository;
        //private readonly IInnovationStatusRepository _innovationStatusRepository;
        private readonly IConsiderationResultRepository _considerationResultRepository;
        private readonly IResolutionRepository _resolutionRepository;
        private readonly IConsiderationRepository _considerationRepository;
        private readonly IConsiderationGroupRepository _considerationGroupRepository;

        public ConsiderationsController(
            ILogger<InnovationsController> logger,
            IIdentityService identityService,
            IResolutionRepository resolutionRepository,
            IInnovationRepository innovationRepository,
            IFilialRepository filialRepository,
            //IInnovationStatusRepository innovationStatusRepository,
            IConsiderationResultRepository considerationResultRepository,
            ICategoryRepository categoryRepository,
            IConsiderationRepository considerationRepository,
            IConsiderationGroupRepository considerationGroupRepository)
        {
            _logger = logger;
            _innovationRepository = innovationRepository;
            _categoryRepository = categoryRepository;
            _filialRepository = filialRepository;
            //_innovationStatusRepository = innovationStatusRepository;
            _considerationResultRepository = considerationResultRepository;
            _resolutionRepository = resolutionRepository;
            _considerationGroupRepository = considerationGroupRepository;
            _considerationRepository = considerationRepository;
            _identityService = identityService;
        }

        [HttpGet]
        [Route("[controller]/[action]/{innovationId}")]
        [Authorize(Policy = nameof(ConsiderationAccess))]
        public async Task<IActionResult> Edit(int innovationId)
        {
            var innovation = await _innovationRepository.GetAsync(innovationId) ??
                throw new InnovationNotFoundException();

            var considerationGroupId = _identityService.GetUserConsiderationGroupId() ??
                throw new UserConsiderationGroupNotFoundException();

            var considerationGroup = await _considerationGroupRepository.GetAsync(considerationGroupId);

            var consideration = await _considerationRepository.GetAsync(innovation.Id, considerationGroup.Id);

            var considerations = await _considerationRepository.GetInnovationConsiderationsAsync(innovation.Id);

            //var innovationStatuses = await _innovationStatusRepository.GetAsync();
            //ViewBag.InnovationStatuses = new SelectList(innovationStatuses, "Id", "Description");

            var considerationResults = await _considerationResultRepository.GetAsync();
            ViewBag.ConsiderationResults = new SelectList(considerationResults, "Id", "Description");

            var uri = new Uri(Request.Headers["Referer"].ToString());
            var returnUrl = uri.PathAndQuery;


            var model = new EditConsiderationModel
            {
                InnovationId = innovation.Id,
                Innovation = InnovationCardModel.ToViewModel(innovation),
                ConsiderationGroupName = considerationGroup.Description,
                Considerations = considerations.Select(x => ConsiderationModel.ToViewModel(x)),
                ReturnUrl = returnUrl
             };

            if (consideration != null)
            {
                model.Content = consideration.Content;
                //model.InnovationStatusId = consideration.InnovationStatus.Id;
                model.ConsiderationResultId = consideration.ConsiderationResult.Id;
            }

            return View(model);
        }

        [HttpPost]
        [Route("[controller]/[action]/{innovationId}")]
        [Authorize(Policy = nameof(ConsiderationAccess))]
        public async Task<IActionResult> Edit(EditConsiderationModel model)
        {
            var innovation = await _innovationRepository.GetAsync(model.InnovationId) ??
                throw new InnovationNotFoundException();

            if (!ModelState.IsValid)
            {
                //var innovationStatuses = await _innovationStatusRepository.GetAsync();
                //ViewBag.InnovationStatuses = new SelectList(innovationStatuses, "Id", "Description");

                var considerationResults = await _considerationResultRepository.GetAsync();
                ViewBag.ConsiderationResults = new SelectList(considerationResults, "Id", "Description");

                model.Innovation = InnovationCardModel.ToViewModel(innovation);

                var considerations = await _considerationRepository.GetInnovationConsiderationsAsync(innovation.Id);
                model.Considerations = considerations.Select(x => ConsiderationModel.ToViewModel(x));

                return View(model);
            }

            //var innovationStatus = await _innovationStatusRepository.GetAsync(model.InnovationStatusId) ??
            //    throw new InnovatioStatusnNotFoundException();

            var considerationResult = await _considerationResultRepository.GetAsync(model.ConsiderationResultId) ??
                throw new ConsiderationResultNotFoundException();

            var considerationGroupId = _identityService.GetUserConsiderationGroupId() ??
                throw new UserConsiderationGroupNotFoundException();

            var considerationGroup = await _considerationGroupRepository.GetAsync(considerationGroupId);


            var consideration = await _considerationRepository.GetAsync(innovation.Id, considerationGroup.Id);
            if (consideration == null)
            {
                consideration = Consideration.Create(considerationGroup, considerationResult, innovation.Id, model.Content);
                _considerationRepository.Insert(consideration);
            }
            else
            {
                consideration.SetRecommendation(considerationResult, model.Content);
                _considerationRepository.Update(consideration);
            }

            await _considerationRepository.UnitOfWork.SaveChangesAsync();

            var url = model.ReturnUrl.SetQueryParam(Options.ScrollParameter, model.InnovationId);
            if (Url.IsLocalUrl(url))
            {
                return Redirect(url);
            }

            return RedirectToAction(DefaultRedirectAction, DefaultRedirectController);
        }


    }
}
