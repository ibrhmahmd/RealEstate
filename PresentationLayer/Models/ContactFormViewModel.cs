using Humanizer;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

public class ContactFormViewModel
{
    [Required(ErrorMessage = "Recipient's name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } // Sender's email

    [Required(ErrorMessage = "Message is required.")]
    public string Message { get; set; } // Corrected property name to PascalCase

    [Required(ErrorMessage = "Subject is required.")]
    public string Subject { get; set; }

    public string To { get; set; } // Recipient's email address

    public async Task<bool> SendMailAsync(string fromEmail, string fromPassword)
    {
        try
        {
            using (var mc = new MailMessage(fromEmail, To))
            {
                mc.Subject = Subject;
                mc.Body = Message; 
                mc.IsBodyHtml = false;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Timeout = 10000; 
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);

                    await smtp.SendMailAsync(mc);
                }
            }
            return true; // Successfully sent
        }
        catch (SmtpException smtpEx)
        {
            Console.WriteLine($"SMTP error: {smtpEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General error: {ex.Message}");
        }
        return false; 
    }
}
