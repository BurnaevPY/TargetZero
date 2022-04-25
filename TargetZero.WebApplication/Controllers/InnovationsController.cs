using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;
using TargetZero.Domain.Exceptions;
using TargetZero.WebApplication.Authorization;
using TargetZero.WebApplication.Models;
using TargetZero.WebApplication.Queries;
using TargetZero.WebApplication.Services;

namespace TargetZero.WebApplication.Controllers
{
    [Authorize]
    public class InnovationsController : Controller
    {
        const string DefaultRedirectAction = "Index";

        private readonly ILogger<InnovationsController> _logger;
        private readonly IInnovationRepository _innovationRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFilialRepository _filialRepository;
        private readonly IInnovationStatusRepository _innovationStatusRepository;
        private readonly IConsiderationRepository _considerationRepository;
        private readonly IResolutionRepository _resolutionRepository;
        private readonly IQueries _queries;
        private readonly IIdentityService _identityService;
        private readonly IConsiderationGroupRepository _considerationGroupRepository;

        public InnovationsController(
            ILogger<InnovationsController> logger,
            IQueries queries,
            IIdentityService identityService,
            IInnovationRepository innovationRepository,
            IFilialRepository filialRepository,
            IInnovationStatusRepository innovationStatusRepository, 
            IConsiderationGroupRepository considerationGroupRepository,
            IConsiderationRepository considerationRepository,
            IResolutionRepository resolutionRepository,
            ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _queries = queries;
            _innovationRepository = innovationRepository;
            _categoryRepository = categoryRepository;
            _filialRepository = filialRepository;
            _innovationStatusRepository = innovationStatusRepository;
            _considerationRepository = considerationRepository;
            _resolutionRepository = resolutionRepository;
            _identityService = identityService;
            _considerationGroupRepository = considerationGroupRepository;
        }


        private async Task<InnovationListModel> GetInnovations(
            string innovationNumber = null,
            int? considerationGroupId = null, int? nonConsiderationGroupId = null, int? categoryId = null, int? filialId = null, int? innovationStatusId = null,
            InnovationTasks innovationTask = InnovationTasks.None,
            bool? hasResolution = null, bool? hasConsideration = null,
            int page = 1, InnovationSortState sortOrder = InnovationSortState.IdDesc)
        {
            int? InnovationNumberParse(string s)
            {
                if (int.TryParse(s, out int i))
                    return i;
                else
                    return null;
            };

            var innovationId = InnovationNumberParse(innovationNumber);

            string author = null;
            switch (innovationTask)
            {
                case InnovationTasks.MyInnovations:
                    author = _identityService.GetCurrentUser();
                    break;
            }

            var count = await _queries.GetInnovationCount(innovationId, considerationGroupId, nonConsiderationGroupId, categoryId, filialId, innovationStatusId, author, hasResolution, hasConsideration);
            var innovations = await _queries.GetInnovationList(innovationId, considerationGroupId, nonConsiderationGroupId, categoryId, filialId, innovationStatusId, author, hasResolution, hasConsideration, (page - 1) * Options.InnovationPageSize, Options.InnovationPageSize, sortOrder);

            var categories = await _categoryRepository.GetAsync();
            var filials = await _filialRepository.GetAsync();
            var innovationStatuses = await _innovationStatusRepository.GetAsync();
            var considerationGroups = await _considerationGroupRepository.GetAsync();

            var currentUserName = _identityService.GetCurrentUser();
            var canWriteResolution = _identityService.IsDecisionUser();
            var canWriteConsideration = _identityService.IsConsiderationUser();
            var canGetSecurityReport = _identityService.IsInformationSecurityUser();

            foreach (var innovation in innovations)
            {
                innovation.CanChangeInnovation = ChangeInnovationAccess.CanChangeInnovationAccess(currentUserName, innovation.Author, innovation.InnovationStatusId);
                innovation.CanWriteResolution = canWriteResolution;
                innovation.CanWriteConsideration = ConsiderationAccess.CanAddOrChangeConsiderationAccess(canWriteConsideration, innovation.InnovationStatusId);
            }

            var model = new InnovationListModel
            {
                Count = count,
                Innovations = innovations,
                PageModel = new PageModel(count, page, Options.InnovationPageSize),
                SortModel = new InnovationSortModel(sortOrder),
                FilterModel = new InnovationFilterModel(
                    innovationId,
                    considerationGroups, considerationGroupId, nonConsiderationGroupId,
                    categories, categoryId,
                    filials, filialId,
                    innovationStatuses, innovationStatusId,
                    innovationTask,
                    hasResolution, hasConsideration),
                CanGetSecurityReport = canGetSecurityReport
            };


            return model;
        }

        [HttpGet]
        public async Task<IActionResult> Index(
            string innovationNumber = null,
            int? considerationGroupId = null, int? nonConsiderationGroupId = null, int? categoryId = null, int? filialId = null, int? innovationStatusId = null,
            bool? hasResolution = null, bool? hasConsideration = null, 
            InnovationTasks innovationTask = InnovationTasks.None, 
            int page = 1, InnovationSortState sortOrder = InnovationSortState.IdDesc,
            int scrollId = 0)
        {

            var total = await _innovationRepository.GetCountAsync();

            var model = await GetInnovations(
                        innovationNumber,
                        considerationGroupId, nonConsiderationGroupId, categoryId, filialId, innovationStatusId,
                        innovationTask,
                        hasResolution, hasConsideration,
                        page, sortOrder);

            ViewData[Options.ScrollParameter] = scrollId;

            if (total != model.Count)
            {
                ViewBag.TotalCaption = "Отфильтровано";
            }
            else
            {
                ViewBag.TotalCaption = "Всего";
            }

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var innovation = await _innovationRepository.GetAsync(id) ??
                throw new InnovationNotFoundException();

            var considerations = await _considerationRepository.GetInnovationConsiderationsAsync(id);
            var resolutions = await _resolutionRepository.GetInnovationResolutionsAsync(id);

            var model = new ViewInnovationModel
            {
                Innovation = InnovationCardModel.ToViewModel(innovation),
                Considerations = considerations.Select(x => ConsiderationModel.ToViewModel(x)),
                ResolutionHistory = resolutions.Select(x => ResolutionHistoryModel.ToViewModel(x))
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> New()
        {
            var categories = await _categoryRepository.GetAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            var filials = await _filialRepository.GetAsync();
            ViewBag.Filials = new SelectList(filials, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(NewInnovationModel model)
        {
            var category = await _categoryRepository.GetAsync(model.CategoryId);
            if (category == null)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Категория не найдена");
            }

            var filial = await _filialRepository.GetAsync(model.FilialId);
            if (filial == null)
            {
                ModelState.AddModelError(nameof(model.FilialId), "Подразделение не найдено");
            }

            if (!ModelState.IsValid)
            {
                var categories = await _categoryRepository.GetAsync();
                ViewBag.Categories = new SelectList(categories, "Id", "Name");

                var filials = await _filialRepository.GetAsync();
                ViewBag.Filials = new SelectList(filials, "Id", "Name");

                return View(model);
            }

            var status = await _innovationStatusRepository.GetAsync(Options.DefaultStatusId) ??
                throw new InnovationStatusnNotFoundException();

            var author = User.Identity.Name;
            var innovation = Innovation.Create(category, filial, status, author, model.Description, model.CurrentState, model.TargetState, model.Reason);

            _innovationRepository.Insert(innovation);
            await _innovationRepository.UnitOfWork.SaveChangesAsync();

            return RedirectToAction(DefaultRedirectAction);

        }

        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        [Authorize(Policy = nameof(ChangeInnovationAccess))]
        public async Task<IActionResult> Edit(int id)
        {
            var innovation = await _innovationRepository.GetAsync(id) ??
                throw new InnovationNotFoundException();

            var categories = await _categoryRepository.GetAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            var filials = await _filialRepository.GetAsync();
            ViewBag.Filials = new SelectList(filials, "Id", "Name");

            var uri = new Uri(Request.Headers["Referer"].ToString());
            var returnUrl = uri.PathAndQuery;
            var model = EditInnovationModel.ToViewModel(innovation, returnUrl);
            return View(model);
        }

        [HttpPost]
        [Route("[controller]/[action]/{id}")]
        [Authorize(Policy = nameof(ChangeInnovationAccess))]
        public async Task<IActionResult> Edit(EditInnovationModel model)
        {
            var innovationToUpdate = await _innovationRepository.GetAsync(model.Id);
            if (innovationToUpdate == null)
            {
                ModelState.AddModelError(string.Empty, "Рацпредложение не найдено");
            }

            var category = await _categoryRepository.GetAsync(model.CategoryId);
            if (category == null)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Категория не найдена");
            }

            var filial = await _filialRepository.GetAsync(model.FilialId);
            if (filial == null)
            {
                ModelState.AddModelError(nameof(model.FilialId), "Подразделение не найдено");
            }

            var innovationStatus = await _innovationStatusRepository.GetAsync(InnovationStatus.Consideration.Id);
            if (innovationStatus == null)
            {
                ModelState.AddModelError(nameof(model.InnovationStatusDescription), "Не найден статус рассмотрение");
            }

            if (!ModelState.IsValid)
            {
                var categories = await _categoryRepository.GetAsync();
                ViewBag.Categories = new SelectList(categories, "Id", "Name");

                var filials = await _filialRepository.GetAsync();
                ViewBag.Filials = new SelectList(filials, "Id", "Name");

                return View(model);
            }

            innovationToUpdate.Update(
                category, filial,
                model.Description, model.CurrentState, model.TargetState, model.Reason);

            innovationToUpdate.SetInnovationStatus(innovationStatus);

            _innovationRepository.Update(innovationToUpdate);

            await _innovationRepository.UnitOfWork.SaveChangesAsync();

            if (Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }

            return RedirectToAction(DefaultRedirectAction);
        }


        [Authorize(Policy = nameof(ChangeInnovationAccess))]
        public async Task<ActionResult> Remove(int id)
        {
            var innovationToDelete = await _innovationRepository.GetAsync(id) ??
                throw new InnovationNotFoundException();

            innovationToDelete.MarkAsDeleted();
            await _innovationRepository.UnitOfWork.SaveChangesAsync();

            return RedirectToAction(DefaultRedirectAction);
        }


        public async Task<FileContentResult> ToExcel(
            int? innovationId,
            int? considerationGroupId = null, int? nonConsiderationGroupId = null, 
            int? categoryId = null, int? filialId = null, int? innovationStatusId = null,
            InnovationTasks innovationTask = InnovationTasks.None,
            bool? hasResolution = null, bool? hasConsideration = null)
        {
            string author = null;
            switch (innovationTask)
            {
                case InnovationTasks.MyInnovations:
                    author = _identityService.GetCurrentUser();
                    break;
            }

            var innovations = await _queries.GetInnovationReportList(
                innovationId, 
                considerationGroupId, nonConsiderationGroupId, 
                categoryId, filialId, innovationStatusId, 
                author,
                hasResolution, hasConsideration);

            var fileBytes = GetInnovationReportExcelFile(innovations, false);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Список рацпредложений {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}.xlsx");
        }


        [Authorize(Policy = nameof(InformationSecurityAccess))]
        public async Task<FileContentResult> ToExcelWithAuthors(
            int? innovationId,
            int? considerationGroupId = null , int? nonConsiderationGroupId = null, 
            int? categoryId = null, int? filialId = null, int? innovationStatusId = null,
            InnovationTasks innovationTask = InnovationTasks.None,
            bool? hasResolution = null, bool? hasConsideration = null)
        {
            string author = null;
            switch (innovationTask)
            {
                case InnovationTasks.MyInnovations:
                    author = _identityService.GetCurrentUser();
                    break;
            }

            var innovations = await _queries.GetInnovationReportList(
                innovationId, 
                considerationGroupId, nonConsiderationGroupId, 
                categoryId, filialId, innovationStatusId,
                author,
                hasResolution, hasConsideration);

            var fileBytes = GetInnovationReportExcelFile(innovations, true);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Список рацпредложений для ОИБ {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}.xlsx");
        }


        private byte[] GetInnovationReportExcelFile(IEnumerable<ReportInnovationItemModel> innovations, bool showAuthor)
        {
            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Список рацпредложений");

            var cols = showAuthor ? 21 : 20;

            ws.Cells[1, 1].Value = "№ предложения";
            ws.Cells[1, 2].Value = "Подразделение";
            ws.Cells[1, 3].Value = "Категория";
            ws.Cells[1, 4].Value = "Дата предложения";
            ws.Cells[1, 5].Value = "Краткое описание";
            ws.Cells[1, 6].Value = "Текущее состояние";
            ws.Cells[1, 7].Value = "Целевое состояние";
            ws.Cells[1, 8].Value = "Обоснование";
            ws.Cells[1, 9].Value = "Количество рассмотрений";
            ws.Cells[1, 10].Value = "Количество резолюций";
            ws.Cells[1, 11].Value = "Дата исполнения последней резолюции";
            ws.Cells[1, 12].Value = "Содержимое последней резолюции";
            ws.Cells[1, 13].Value = "Статус предложения";
            ws.Cells[1, 14].Value = "Группа 1";
            ws.Cells[1, 15].Value = "Группа 2";
            ws.Cells[1, 16].Value = "Группа 3";
            ws.Cells[1, 17].Value = "Группа 4";
            ws.Cells[1, 18].Value = "Группа 5";
            ws.Cells[1, 19].Value = "Группа 6";
            ws.Cells[1, 20].Value = "Группа 7";

            if (showAuthor)
            {
                ws.Cells[1, 21].Value = "Автор предложения";
            }

            int rowIndex = 2;
            foreach (var innovation in innovations)
            {
                ws.Cells[rowIndex, 1].Value = innovation.Id;
                ws.Cells[rowIndex, 2].Value = innovation.FilialName;
                ws.Cells[rowIndex, 3].Value = innovation.CategoryName;
                ws.Cells[rowIndex, 4].Value = innovation.CreateTime;
                ws.Cells[rowIndex, 5].Value = innovation.Description;
                ws.Cells[rowIndex, 6].Value = innovation.CurrentState;
                ws.Cells[rowIndex, 7].Value = innovation.TargetState;
                ws.Cells[rowIndex, 8].Value = innovation.Reason;
                ws.Cells[rowIndex, 9].Value = innovation.ConsiderationCount;
                ws.Cells[rowIndex, 10].Value = innovation.ResolutionCount;
                ws.Cells[rowIndex, 11].Value = innovation.LastResolutionCreateTime;
                ws.Cells[rowIndex, 12].Value = innovation.LastResolutionContent;
                ws.Cells[rowIndex, 13].Value = innovation.InnovationStatusDescription;
                ws.Cells[rowIndex, 14].Value = innovation.ConsiderationGroup1;
                ws.Cells[rowIndex, 15].Value = innovation.ConsiderationGroup2;
                ws.Cells[rowIndex, 16].Value = innovation.ConsiderationGroup3;
                ws.Cells[rowIndex, 17].Value = innovation.ConsiderationGroup4;
                ws.Cells[rowIndex, 18].Value = innovation.ConsiderationGroup5;
                ws.Cells[rowIndex, 19].Value = innovation.ConsiderationGroup6;
                ws.Cells[rowIndex, 20].Value = innovation.ConsiderationGroup7;
                if (showAuthor)
                {
                    ws.Cells[rowIndex, 21].Value = innovation.Author;
                }

                rowIndex++;
            }

            using (ExcelRange header = ws.Cells[1, 1, 1, cols])
            {
                //header.Style.Fill.PatternType = ExcelFillStyle.Solid;
                //header.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 108, 108));
                //header.Style.Font.Color.SetColor(Color.White);
                header.Style.Font.Bold = true;
                header.Style.WrapText = true;
                header.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                header.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                //header.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                //header.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                //header.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                header.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
            }

            ws.Column(4).Style.Numberformat.Format = "dd.MM.yyyy";
            ws.Column(11).Style.Numberformat.Format = "dd.MM.yyyy";

            ws.Cells.AutoFitColumns();

            ws.Cells[1, 5].AutoFitColumns(50);
            ws.Cells[1, 6].AutoFitColumns(50);
            ws.Cells[1, 7].AutoFitColumns(50);
            ws.Cells[1, 8].AutoFitColumns(50);
            ws.Cells[1, 12].AutoFitColumns(50);
            ws.Cells[1, 14].AutoFitColumns(50);
            ws.Cells[1, 15].AutoFitColumns(50);
            ws.Cells[1, 16].AutoFitColumns(50);
            ws.Cells[1, 17].AutoFitColumns(50);
            ws.Cells[1, 18].AutoFitColumns(50);
            ws.Cells[1, 19].AutoFitColumns(50);
            ws.Cells[1, 20].AutoFitColumns(50);

            var fileBytes = p.GetAsByteArray();
            return fileBytes;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
