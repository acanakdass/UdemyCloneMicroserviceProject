using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using UdemyClone.IdentityServer.Models;

namespace UdemyClone.IdentityServer.Services
{
    public class IdentityResourceOwnerPasswordValidator:IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userManager.FindByEmailAsync(context.UserName);
            if (user == null)
            {
                var err = new Dictionary<string, object>();
                err.Add("errors", new List<string> { "Email or password is incorrect!" });
                context.Result.CustomResponse = err;
                return;
            }
            var pwCheck = await _userManager.CheckPasswordAsync(user, context.Password);
            if (!pwCheck)
            {
                var err = new Dictionary<string, object>();
                err.Add("errors", new List<string> { "Email or password is incorrect!" });
                context.Result.CustomResponse = err;
                return;
            }
            context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
        }
    }
}

