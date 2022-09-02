using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FINALBRIGHTPROJECT.ViewModel.BrightModel
{
    interface IApplicationUser
    {
        string FullName { get; set; }
        string Gender { get; set; }
        string physicalAddr { get; set; }

        Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager);
    }
}
