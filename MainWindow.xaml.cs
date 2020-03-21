using System.Windows;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mnHelp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnExit_Click(object sender, RoutedEventArgs e)
        {
            SendEndWindow sew = new SendEndWindow();
            sew.ShowDialog();
        }

        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            List<string> listStrMails = new List<string> { "maa15011974@gmail.com" };  // Список email'ов //кому мы отправляем письмо
            string strPassword = txtPassword.Password.Trim();  // для WinForms - string strPassword = passwordBox.Text;
            foreach (string mail in listStrMails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage("arsenal74@yandex.ru", mail))
                {
                    // Формируем письмо
                    mm.Subject = txtThema.Text.Trim(); // Заголовок письма
                    mm.Body = txtText.Text.Trim();       // Тело письма
                    mm.IsBodyHtml = false;           // Не используем html в теле письма
                                                     // Авторизуемся на smtp-сервере и отправляем письмо
                                                     // Оператор using гарантирует вызов метода Dispose, даже если при вызове 
                                                     // методов в объекте происходит исключение.
                    using (SmtpClient sc = new SmtpClient("smtp.mail.ru", 465))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential("arsenal74@yandex.ru", strPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                        }
                    }
                } //using (MailMessage mm = new MailMessage("sender@yandex.ru", mail))
            }
            MessageBox.Show("Работа завершена.");

        }
    }
}
