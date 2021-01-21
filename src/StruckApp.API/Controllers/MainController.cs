using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace StruckApp.API.Controllers
{
    [ApiController]
    public abstract class MainController: Controller
    {
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (!IsValidOperation())
            {
                return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    {"Messages", Errors.ToArray()}
                }));
            }
            return Ok(result);
        }

        private bool IsValidOperation()
        {
            return Errors.Any();
        }

        protected void AddError(string newError)
        {
            Errors.Add(newError);
        }

        protected void ClearError()
        {
            Errors.Clear();
        }
    }
}