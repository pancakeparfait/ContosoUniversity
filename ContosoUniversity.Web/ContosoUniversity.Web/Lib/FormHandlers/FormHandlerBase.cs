using System;

namespace ContosoUniversity.Web.Lib.FormHandlers
{
    public abstract class FormHandlerBase<TForm> : IFormHandler<TForm> where TForm : class
    {
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public abstract void Handle(TForm form);

        protected void SetSuccessMessage(string message, params object[] parameters)
        {
            SuccessMessage = String.Format(message, parameters);
        }
    }
}