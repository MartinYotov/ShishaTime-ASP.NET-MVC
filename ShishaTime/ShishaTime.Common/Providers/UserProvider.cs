using ShishaTime.Common.Providers.Contracts;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Web;

namespace ShishaTime.Common.Providers
{
    public class UserProvider : IUserProvider
    { 
        public string GetUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }
    }
}
