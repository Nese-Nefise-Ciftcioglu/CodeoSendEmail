using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace sendgrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }     

        private async void button1_Click(object sender, EventArgs e)
        {
            var apiKey = "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";
            //Api Key should be saved in environment variables for security issues: 
            //var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("completedy@hotmail.com", "sender user"); // Sender's email address should be saved in Sendgrid beforehand.     
            var to = new EmailAddress("nesenefise@hotmail.com", "receiver user");

            var subject = "Example subject";
            var plainTextContent = "Example text content";
            var htmlContent = "<strong>Codeo</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            try
            {
                var response = await client.SendEmailAsync(msg);
                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    MessageBox.Show("Email sent successfully!");
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