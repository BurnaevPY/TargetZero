using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.WebApplication.Services;

namespace TargetZero.WebApplication.Authorization
{
    public class InformationSecurityAccess
    {
    }

    public class InformationSecurityAccessRequirement : IAuthorizationRequirement
    {
    }


    public class InformationSecurityAccessAccessHandler : AuthorizationHandler<InformationSecurityAccessRequirement>
    {
        private readonly IIdentityService _identityService;

        public InformationSecurityAccessAccessHandler(
            IIdentityService identityService)
        {
            _identityService = identityService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, InformationSecurityAccessRequirement requirement)
        {
            if (_identityService.IsInformationSecurityUser())
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
