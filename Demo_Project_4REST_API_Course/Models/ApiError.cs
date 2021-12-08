using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Demo_Project_4REST_API_Course.Models
{
    public class ApiError
    {
        public ApiError()
        {
                
        }
        public ApiError(ModelStateDictionary modelState)
        {
            Message = "Invalid parameters.";
            Details = modelState
                .FirstOrDefault(x => x.Value.Errors.Any()).Value.Errors
                .FirstOrDefault().ErrorMessage;
        }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}
