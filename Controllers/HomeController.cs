using MAFTLECOME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MAFTLECOME.Controllers
{   

    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        // GET: Home
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactFormModel model)
        {
            _logger.LogInformation("Form submitted");

            string host = _configuration.GetValue<string>("Smtp:Server");
            int port = _configuration.GetValue<int>("Smtp:Port");
            string fromAddress = _configuration.GetValue<string>("Smtp:FromAddress");
            string userName = _configuration.GetValue<string>("Smtp:UserName");
            string password = _configuration.GetValue<string>("Smtp:Password");

            using (MailMessage mm = new MailMessage(fromAddress, "youness.kherbache@gmail.com"))
            {
                mm.Subject = model.Subject;
                mm.Body = $"Name: {model.Name}<br /><br />Email: {model.Email}<br />{model.Body}";
                mm.IsBodyHtml = true;

                if (model.Attachment != null && model.Attachment.Length > 0)
                {
                    string fileName = Path.GetFileName(model.Attachment.FileName);
                    mm.Attachments.Add(new Attachment(model.Attachment.OpenReadStream(), fileName));
                }

                using (SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(userName, password);

                    try
                    {
                        smtp.Send(mm);
                        ViewData["Message"] = "Email sent successfully.";
                    }
                    catch (SmtpFailedRecipientsException ex)
                    {
                        _logger.LogError(ex, "Error sending email to one or more recipients.");
                        ViewData["Message"] = "Error sending email. Failed recipients: " + string.Join(", ", ex.InnerExceptions.Select(e => e.FailedRecipient));
                    }
                    catch (SmtpException ex)
                    {
                        _logger.LogError(ex, "SMTP error occurred while sending email.");
                        ViewData["Message"] = "SMTP error: " + ex.Message;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An unexpected error occurred while sending email.");
                        ViewData["Message"] = "An unexpected error occurred: " + ex.Message;
                    }
                }
            }

            return View(); // Return the view to ensure the message is displayed
        }





        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
