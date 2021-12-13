using Microsoft.AspNetCore.Mvc.Filters;
using API.Course.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace API.Course.Filters
{
    public class ValidateModelStateCustom : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var fieldValidateViewModel = new FieldValidateViewModelOutput(context.ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage));
                context.Result = new BadRequestObjectResult(fieldValidateViewModel);
            }

        }
    }
}
