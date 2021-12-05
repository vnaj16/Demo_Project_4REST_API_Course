using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo_Project_4REST_API_Course.Filters
{
    public class RequireHttpsOrCloseAttribute : RequireHttpsAttribute
    {
        protected override void HandleNonHttpsRequest(AuthorizationFilterContext filterContext)
        {
            //base.HandleNonHttpsRequest(filterContext);  
            filterContext.Result = new StatusCodeResult(400);
        }
    }
}
