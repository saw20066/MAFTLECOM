using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace MAFTLECOME.Models
{
    public class ContactFormModel
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public IFormFile Attachment { get; set; }
    }
}