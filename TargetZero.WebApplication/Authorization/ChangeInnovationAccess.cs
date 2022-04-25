using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;
using TargetZero.Domain.Exceptions;
using TargetZero.WebApplication.Services;

namespace TargetZero.WebApplication.Authorization
{
    public class ChangeInnovationAccess
    {
        public static bool CanChangeInnovationAccess(string currentUserName, string author, int innovationStatusId)
        {
            if (currentUserName == author.ToLower() && 
                (innovationStatusId == InnovationStatus.Consideration.Id || innovationStatusId == InnovationStatus.Rework.Id))
            {
                return true;
            }

            return false;
        }

    }

    public class ChangeInnovationAccessRequirement : IAuthorizationRequirement
    {
    }


    public class ChangeInnovationAccessHandler : AuthorizationHandler<ChangeInnovationAccessRequirement>
    {
        private readonly IIdentityService _identityService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IInnovationRepository _innovationRepository;

        public ChangeInnovationAccessHandler(
            IHttpContextAccessor httpContextAccessor,
            IIdentityService identityService,
            IInnovationRepository innovationRepository)
        {
            _identityService = identityService;
            _httpContextAccessor = httpContextAccessor;
            _innovationRepository = innovationRepository;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ChangeInnovationAccessRequirement requirement)
        {
            if (!int.TryParse(_httpContextAccessor.HttpContext.Request.RouteValues["id"].ToString(), out int id))
            {
                throw new InnovationNotFoundException();
            }

            var innovation = await _innovationRepository.GetAsync(id);
            if (innovation == null)
            {
                throw new InnovationNotFoundException();
            }

            if (ChangeInnovationAccess.CanChangeInnovationAccess
                (_identityService.GetCurrentUser(), innovation.Author, innovation.InnovationStatus.Id))
            {
                context.Succeed(requirement);
            }
        }
    }
}
