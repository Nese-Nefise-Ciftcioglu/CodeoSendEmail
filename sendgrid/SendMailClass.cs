using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sendgrid
{
    public class SendMailClass
    {
        public async void SendMail(string pcInfo ,string Attachment)
        {
            var apiKey = "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";
            //Api Key should be saved in environment variables for security issues: 
            //var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("ipek.tekin@codeo.com.tr", "sender user"); // Sender's email address should be saved in Sendgrid beforehand.     
            var to = new EmailAddress("ipek.tekin@codeo.com.tr", "receiver user");

            var subject = "Error Report";
            var plainTextContent = "Example text content";
            var htmlContent = pcInfo;

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            //Attach image
            var imagepPath = Attachment;
            var bytes = File.ReadAllBytes(imagepPath);
            var base64Image = Convert.ToBase64String(bytes);
            msg.AddAttachment("image.jpg", base64Image);

            try
            {
                var response = await client.SendEmailAsync(msg);
                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    //MessageBox.Show("Email sent successfully!");
                    Application.Exit();  // Exit the application once email is sent
                }
                else
                {
                    MessageBox.Show("Failed to send email.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
