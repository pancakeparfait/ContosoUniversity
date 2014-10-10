using System;
using System.Web.Mvc;
using ContosoUniversity.Web.Lib.FormHandlers;

namespace ContosoUniversity.Web.Lib.ActionResults
{
    public class FormHandlerResult<TForm> : ActionResult
        where TForm : class
    {
        #region [Properties]

        public IFormHandler<TForm> FormHandler { get; protected set; }
        public TForm Form { get; protected set; }
        public Func<ActionResult> Success { get; protected set; }
        public Func<ActionResult> Failure { get; protected set; }

        #endregion

        #region [Ctors]

        public FormHandlerResult(TForm form, Func<ActionResult> success, Func<ActionResult> failure)
        {
            Form = form;
            Success = success;
            Failure = failure;
        }

        #endregion

        public override void ExecuteResult(ControllerContext context)
        {
            if (context.Controller.ViewData.ModelState.IsValid)
            {
                try
                {
                    FormHandler = DependencyResolver.Current.GetService<IFormHandler<TForm>>();
                    FormHandler.Handle(Form);
                    Success.Invoke();
                    context.ParentActionViewContext.TempData.Add(Alerts.Success, FormHandler.SuccessMessage);
                }
                catch (ApplicationException ex)
                {
                    context.ParentActionViewContext.TempData.Add(Alerts.Warning, ex.Message);
                }
            }
            else
            {
                Failure.Invoke();
                context.ParentActionViewContext.TempData.Add(Alerts.Error, FormHandler.ErrorMessage);
            }
        }
    }
}