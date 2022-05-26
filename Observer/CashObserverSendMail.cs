using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;
using StockDP.Models;

namespace StockDP.Observer
{
    public class CashObserverSendMail : ICashObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public CashObserverSendMail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CashControl(Cash cash)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<CashObserverSendMail>>();


            var mailMessage = new MailMessage();

            var smtpClient = new SmtpClient("Sunucu bilgisi");

            mailMessage.From = new MailAddress("Gönderilecek E-mail girilecek");
            mailMessage.To.Add(new MailAddress("Alıcı E-mail girilecek"));

            mailMessage.Subject = "StockDP uyarı";
            mailMessage.Body = "<p>100 TL üzerinde </p>";
            mailMessage.IsBodyHtml = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("UserName", "Password");
            smtpClient.Send(mailMessage);
            logger.LogInformation("E-mail gönderildi");

            throw new NotImplementedException();
        }
    }
}
