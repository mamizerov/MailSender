using System.Windows;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for SendEndWindow.xaml
    /// </summary>
    public partial class SendEndWindow : Window
    {
        public SendEndWindow()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
