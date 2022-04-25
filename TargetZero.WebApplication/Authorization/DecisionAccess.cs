using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.WebApplication.Services;

namespace TargetZero.WebApplication.Authorization
{
    public class DecisionAccess
    {
    }

    public class DecisionAccessRequirement : IAuthorizationRequirement
    {
    }


    public class DecisionAccessHandler : AuthorizationHandler<DecisionAccessRequirement>
    {
        private readonly IIdentityService _identityService;

        public DecisionAccessHandler(
            IIdentityService identityService)
        {
            _identityService = identityService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DecisionAccessRequirement requirement)
        {
            if (_identityService.IsDecisionUser())
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
