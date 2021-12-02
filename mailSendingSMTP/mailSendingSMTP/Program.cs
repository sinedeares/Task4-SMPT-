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
            Console.WriteLine("Введите логин от почты (сам адрес): ");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль от почты: ");
            string password = Console.ReadLine();
            smtp.Credentials = new NetworkCredential(login, password); //аутентификационные данные отправителя 
            Console.WriteLine("Введите имя отправителя: ");
            string userName = Console.ReadLine();
            MailAddress from = new MailAddress(login, userName); //От кого (Почта, имя)
            Console.WriteLine("Введите почту получателя: ");
            string receiverMail = Console.ReadLine();
            MailAddress to = new MailAddress(receiverMail); //Кому
            MailMessage message = new MailMessage(from, to);
            Console.WriteLine("Введите расположение файла (в формате C:\\...\\Имя_файла.разрешение: ");
            string attachment = Console.ReadLine();
            message.Attachments.Add(new Attachment(attachment)); //Вложение
            Console.WriteLine("Введите тему письма: ");
            string mailTheme = Console.ReadLine();
            message.Subject = mailTheme; //Тема письма
            Console.WriteLine("Введите содержание письма: ");
            string mailText = Console.ReadLine();
            message.Body = mailText; //Текст письма
            smtp.EnableSsl = true; //Отправка по протоколу SSL или нет
            char letter = 'y';
            Console.WriteLine("Отправить письмо? y/n: ");
            if (letter == 'y')
            {
                smtp.Send(message);
            }
            Console.Read();
        }


    }
}
