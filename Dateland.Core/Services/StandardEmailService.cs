namespace Dateland.Core
{
    // Required namespaces
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    /// <summary>
    /// This is an email service that uses Gmail.com as it's host
    /// </summary>
    /// <seealso cref="Dateland.Core.IEmailService" />
    public class StandardEmailService : IEmailService
    {
        /// <summary>
        /// <see cref="IEmailService.Client"/>
        /// </summary>
        public SmtpClient Client { get; private set; }

        /// <summary>
        /// <see cref="IEmailService.HostAddress"/>
        /// </summary>
        public string HostAddress { get => "smtp.gmail.com"; }

        /// <summary>
        /// <see cref="IEmailService.Port"/>
        /// </summary>
        public int Port { get => 587; }

        /// <summary>
        /// <see cref="IEmailService.SenderEmail"/>
        /// </summary>
        public string SenderEmail { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardEmailService"/> class.
        /// </summary>
        /// <param name="senderEmail">The sender email.</param>
        /// <param name="senderPassword">The sender password.</param>
        public StandardEmailService(NetworkCredential credentials)
        {          
            // Create the client
            Client = new SmtpClient(HostAddress);
            // Set the port for the client
            Client.Port = Port;
            // Enable ssl for the client
            Client.EnableSsl = true;
            // We wan to use our own credentials
            Client.UseDefaultCredentials = false;
            // Set the senders email
            SenderEmail = credentials.UserName;

            // CREDENTIALS SHOULD NOT BE SET HERE!
            Client.Credentials = credentials;
        }

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="to">The receiever.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> SendEmail(string to, string subject, string message)
        {
            // Try to send the message
            try
            {
                // Attempt to send the message async
                await Task.Run(() => { Client.SendAsync(SenderEmail, to, subject, message, null); });

                // Return true result
                return true;
            }
            // If failed...
            catch
            {
                // Return false result
                return false;
            }
        }
    }
}
