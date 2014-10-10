using System;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using ContosoUniversity.Web.Lib.ActionResults;

namespace ContosoUniversity.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ActionResult Get(Func<ActionResult> action, Func<ActionResult> failure = null)
        {
            if (failure == null) failure = View;

            try
            {
                return action.Invoke();
            }
            catch (RetryLimitExceededException ex)
            {
                //Log
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator");
            }

            return failure.Invoke();
        }

        protected FormHandlerResult<TForm> Form<TForm>(TForm form, Func<ActionResult> success,
            Func<ActionResult> failure = null, bool doSuccessOnFailure = false)
            where TForm : class
        {
            if (failure == null) failure = () => View(form);
            
            return new FormHandlerResult<TForm>(form, success, failure);
        }
    }
}