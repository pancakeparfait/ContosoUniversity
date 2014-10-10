using System.Web;

namespace ContosoUniversity.Web.Lib.FormHandlers
{
    public interface IFormHandler<in TForm> where TForm : class
    {
        string SuccessMessage { get; set; }
        string ErrorMessage { get; set; }
        void Handle(TForm form);
    }
}
