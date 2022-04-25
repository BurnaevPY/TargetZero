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
    public class ConsiderationAccess
    {
        public static bool CanAddOrChangeConsiderationAccess(bool isConsiderationUser, int innovationStatusId)
        {
            if (isConsiderationUser && innovationStatusId != InnovationStatus.Implemented.Id)
            {
                return true;
            }

            return false;
        }
    }

    public class ConsiderationAccessRequirement : IAuthorizationRequirement
    {
    }


    public class ConsiderationAccessHandler : AuthorizationHandler<ConsiderationAccessRequirement>
    {
        private readonly IIdentityService _identityService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IInnovationRepository _innovationRepository;

        public ConsiderationAccessHandler(
            IHttpContextAccessor httpContextAccessor,
            IIdentityService identityService,
            IInnovationRepository innovationRepository)
        {
            _identityService = identityService;
            _httpContextAccessor = httpContextAccessor;
            _innovationRepository = innovationRepository;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ConsiderationAccessRequirement requirement)
        {
            if (!int.TryParse(_httpContextAccessor.HttpContext.Request.RouteValues["innovationId"].ToString(), out int innovationId))
            {
                throw new InnovationNotFoundException();
            }

            var innovation = await _innovationRepository.GetAsync(innovationId);
            if (innovation == null)
            {
                throw new InnovationNotFoundException();
            }

            if (ConsiderationAccess.CanAddOrChangeConsiderationAccess(_identityService.IsConsiderationUser(), innovation.InnovationStatus.Id ) )
            {
                context.Succeed(requirement);
            }

        }
    }
}
