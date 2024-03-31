using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using Org.BouncyCastle.Utilities.Net;

namespace PetitionManagementSystem.Operation
{
    public static class EmailGenerator
    {
       
public static void SendEmail(string Email, string status)

        {

            string fromMail = "smano8312@gmail.com";

            string senderPass = "mktt mzmx pasy gdgl";

            MailMessage message = new MailMessage();

            message.From = new MailAddress(fromMail);

            message.To.Add(Email);

            if (status=="Approved")
            {
                message.Subject = $"Petition Status updation";
                message.Body = $"Your Petition has been approved by the handler";
            }
            else if (status== "Rejected")
            {
                message.Subject = $"Petition Status updation";
                message.Body = $"Your Petition has been Rejected";
            }
            else if (status == "Resolved")
            {
                message.Subject = $"Petition Status updation";
                message.Body = $"Your Petition has been Resolved";
            }

            else 
            {
                message.Subject = $"Petition Status updation";
                message.Body = $"Your Petition has been Closed";
            }


            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromMail, senderPass);
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(message);
                return;
            }
            catch (Exception ex)
            {
                return;
            }

        }
    }
}
