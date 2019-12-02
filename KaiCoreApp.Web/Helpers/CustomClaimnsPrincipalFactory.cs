﻿using KaiCoreApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KaiCoreApp.Web.Helpers
{
    public class CustomClaimnsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, AppRole>
    {
        UserManager<AppUser> _userManger;

        public CustomClaimnsPrincipalFactory(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager, IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {
            _userManger = userManager;
        }

        public async override Task<ClaimsPrincipal> CreateAsync(AppUser user)
        {
            var principal = await base.CreateAsync(user);
            var roles = await _userManger.GetRolesAsync(user);
            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                new Claim("Email",user.Email),
                new Claim("FullName",user.FullName),
                new Claim("Avatar",user.Avatar??string.Empty),
                new Claim("Roles",string.Join(";",roles)),
                new Claim("UserId", user.Id.ToString())
            });
            return principal;
        }
    }
}