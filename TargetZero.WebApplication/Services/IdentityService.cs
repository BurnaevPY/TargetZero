using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;
using TargetZero.Domain.Abstractions;

namespace TargetZero.WebApplication.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityService(IHttpContextAccessor httpContextAccessor)
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

            foreach (var considerationGroup in ConsiderationGroups)
            {
                if (_httpContextAccessor.HttpContext.User.IsInRole(considerationGroup.Key))
                {
                    return considerationGroup.Value;
                }
            }
            return null;
        }

        public bool IsConsiderationUser()
        {
            foreach (var considerationGroup in ConsiderationGroups)
            {
                if (_httpContextAccessor.HttpContext.User.IsInRole(considerationGroup.Key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsDecisionUser()
        {
            return _httpContextAccessor.HttpContext.User.IsInRole("GRP01-IS-TargetZero-Group-Decision");
        }

        public bool IsInformationSecurityUser()
        {
            return _httpContextAccessor.HttpContext.User.IsInRole("GRP01-IS-TargetZero-Group-IS");
        }

        private Dictionary<string, int> ConsiderationGroups = new Dictionary<string, int>
        {
           { "GRP01-IS-TargetZero-Group01", ConsiderationGroup.Group1.Id },
           { "GRP01-IS-TargetZero-Group02", ConsiderationGroup.Group2.Id },
           { "GRP01-IS-TargetZero-Group03", ConsiderationGroup.Group3.Id },
           { "GRP01-IS-TargetZero-Group04", ConsiderationGroup.Group4.Id },
           { "GRP01-IS-TargetZero-Group05", ConsiderationGroup.Group5.Id },
           { "GRP01-IS-TargetZero-Group06", ConsiderationGroup.Group6.Id },
           { "GRP01-IS-TargetZero-Group07", ConsiderationGroup.Group7.Id },
           { "GRP01-IS-TargetZero-Group-GRNU", ConsiderationGroup.GrnuGroup.Id },
           { "GRP01-IS-TargetZero-Group-RRNU", ConsiderationGroup.RrnuGroup.Id },
           { "GRP01-IS-TargetZero-Group-MRNU", ConsiderationGroup.MrnuGroup.Id },
           { "GRP01-IS-TargetZero-Group-TNM", ConsiderationGroup.TnmGroup.Id },
           { "GRP01-IS-TargetZero-Group-BPTO", ConsiderationGroup.BptoGroup.Id },
           { "GRP01-IS-TargetZero-Group-VRNPU", ConsiderationGroup.VrnpuGroup.Id },
           { "GRP01-IS-TargetZero-Group-TSPA", ConsiderationGroup.TspaGroup.Id },
        };

    }
}
