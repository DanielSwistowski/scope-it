using Scope_IT.CustomValidationAttributes;
using Scope_IT.Models;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Scope_IT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryTokenForAjaxPost]
        public async Task<JsonResult> Contact(ContactEmail model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = "<p>Nowa wiadomość od: {0} ({1}), telefon: {2}</p><p>Treść wiadomości:</p><p>{3}</p>";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress("danielswistowski@wp.pl")); //replace with valid value
                    message.Subject = model.Subject;
                    message.Body = string.Format(body, model.FirstName + " " + model.LastName, model.Email, model.Phone, model.Message);
                    message.IsBodyHtml = true;
                    using (var smtp = new SmtpClient())
                    {
                        await smtp.SendMailAsync(message);
                        return Json(new { success = true, message = "Dziękujemy za wysłanie wiadomości. Odpowiemy najszybciej jak tylko będzie to możliwe." }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch
                {
                    return Json(new { success = false, message = "Błąd wysyłania wiadomości. Proszę spróbować ponownie." }, JsonRequestBehavior.AllowGet);
                    //return Json(new { success = false, message = ex.ToString() }, JsonRequestBehavior.AllowGet); todo: custom errors mode na off
                }
            }
            return Json(new { success = false, message = "Proszę uzupełnić wszystkie dane." }, JsonRequestBehavior.AllowGet);
        }
    }
}