namespace Dateland.Core
{
    // Required namespaces
    using System.Net.Mail;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for an email service
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        abstract SmtpClient Client { get; }

        /// <summary>
        /// Gets or sets the host address.
        /// </summary>
        /// <value>
        /// The host address.
        /// </value>
        abstract string HostAddress { get; }

        /// <summary>
        /// Gets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        abstract int Port { get; }

        /// <summary>
        /// Gets the sender email.
        /// </summary>
        /// <value>
        /// The sender email.
        /// </value>
        abstract string SenderEmail { get; }

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="to">The receiever.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        abstract Task<bool> SendEmail(string to, string subject, string message);
    }
}
