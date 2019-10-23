// www.craftedforeveryone.com
// Licensed under the MIT License. See LICENSE file in the project root for full license information.  

using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAuthorizeAttribute.Approach2
{
    public class A2AuthorizePermissionHandler : AuthorizationHandler<A2AuthorizePermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, A2AuthorizePermissionRequirement requirement)
        {
            if (string.IsNullOrEmpty(requirement.Permissions))
            {
                context.Fail();
            }

            var userName = context.User.Identity.Name;
            var assignedPermissionsForUser = MockData.UserPermissions.Where(x => x.Key == userName).Select(x => x.Value).ToList();


            var requiredPermissions = requirement.Permissions.Split(",");
            foreach (var x in requiredPermissions)
            {
                if (assignedPermissionsForUser.Contains(x))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }  
            }
            context.Fail();
            return Task.CompletedTask;
        }
    }
}
