using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Pharmacy.Framework
{
    internal class ClaimBasedAuthorizationHandler : AuthorizationHandler<HasClaim>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasClaim requirement)
        {
            if (context.User.HasClaim(c => c.Value.Equals(requirement.Claim, StringComparison.InvariantCulture)))
            {
                // Mark the requirement as satisfied
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    internal class HasClaim : IAuthorizationRequirement
    {
        public string Claim { get; private set; }
        public HasClaim(string claim)
        {
            Claim = claim;
        }
    }
}
