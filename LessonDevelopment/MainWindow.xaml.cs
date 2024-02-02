using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LessonDevelopment
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

        private void btn_signIn_Click(object sender, RoutedEventArgs e)
        {
            //init
            string email = tbox_email.Text;
            string password = pbox_password.Password;
            var dateNow = DateTime.Now;
            //json
            User user = new User()
            {
                email = email,
                password = password,
                last_date = dateNow
            };

            var json = JsonConvert.SerializeObject(user);
            if (!Directory.Exists("Users")) Directory.CreateDirectory("Users");
            File.WriteAllText("Users/" + "alldata" + ".json", json);

            MessageBox.Show("It has saved");

            tbox_email.Clear();
            pbox_password.Clear();

        }
    }
    class User
    {
        public string email { get; set; }
        public string password { get; set; }
        public DateTime last_date { get; set; }
    }
}