using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;
using TargetZero.Domain.Abstractions;

namespace TargetZero.WebApplication.Services
{
    public class MockIdentityService: IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MockIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetCurrentUser()
        {
            return _httpContextAccessor.HttpContext.User.Identity.Name.ToLower();
        }

        public bool IsCurrentUser(string userName)
        {
            return _httpContextAccessor.HttpContext.User.Identity.Name.ToLower() == userName.ToLower();
        }


        public int? GetUserConsiderationGroupId()
        {
            var groupId = (DateTime.Now.Second / 10) + 1;
            return groupId;
        }

        public bool IsConsiderationUser()
        {
            return false;
        }

        public bool IsDecisionUser()
        {
            return false;
        }

        public bool IsInformationSecurityUser()
        {
            return false;
        }
    }
}
