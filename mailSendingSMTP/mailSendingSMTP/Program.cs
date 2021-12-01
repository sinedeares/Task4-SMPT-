/* Может потребоваться создание пароля для стороннего приложения, как было у меня с почтой mail, на других почтах так же нужно включать настройки, чтобы письма доходили (профилактика против спама, вредоносных рассылок и тд
 от компаний*/

using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace mailSendingSMTP
{
    class Program
    {
        static void Main(string[] args)
        {
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525); //для mail порт 2525, для яндекса 25, для гугла 465 (желательно) или 587
            smtp.Credentials = new NetworkCredential("*********@mail.ru", "*******************"); //аутентификационные данные отправителя 
            MailAddress from = new MailAddress("*********@mail.ru", "Кто-нибудь"); //От кого (Почта, имя)
            MailAddress to = new MailAddress("*****@mail.ru"); //Кому
            MailMessage message = new MailMessage(from, to);
            message.Attachments.Add(new Attachment("C:\\cat.jpg")); //Вложение
            message.Subject = "Тест"; //Тема письма
            message.Body = "Тест прошёл"; //Текст письма
            smtp.EnableSsl = true; //Отправка по протоколу SSL или нет
            smtp.Send(message);
            Console.Read();
        }


    }
}
