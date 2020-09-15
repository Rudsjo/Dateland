namespace Dateland.Core.Services
{
    // Required namespaces
    using System.Net.Mail;
    using System.Threading.Tasks;

    /// <summary>
    /// Email service tha can be used while developing the application
    /// </summary>
    public class MockEmailService : IEmailService
    {
        /// <summary>
        /// <see cref="IEmailService.Client"/>
        /// </summary>
        public SmtpClient Client  => null;

        /// <summary>
        /// <see cref="IEmailService.HostAddress"/>
        /// </summary>
        public string HostAddress => string.Empty;

        /// <summary>
        /// <see cref="IEmailService.Port"/>
        /// </summary>
        public int Port => 0;

        /// <summary>
        /// <see cref="IEmailService.SenderEmail"/>
        /// </summary>
        public string SenderEmail => string.Empty;

        /// <summary>
        /// Pretends to send an email
        /// </summary>
        /// <param name="to">The receiever.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Task<bool> SendEmail(string to, string subject, string message)
        {
            // Print out developer message
            System.Console.WriteLine("To: {to}:\nSubject: {subject}\nMessage: {message}");

            // Return true result always
            return Task.FromResult(true);
        }
    }
}
