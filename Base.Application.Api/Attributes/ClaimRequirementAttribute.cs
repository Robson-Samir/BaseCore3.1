using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Base.Application.Api.Attributes
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute() : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { new Claim("", "") };
        }
    }
}
