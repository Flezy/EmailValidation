using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EmailValidation;

namespace GUIForEmailValidation
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

        public void TestWithRandom(object sender, EventArgs e)
        {
            var rand = new Random();
            int number = rand.Next(1, 5);
            switch(number)
            {
                case 1:
                    Email.Text = "somebody@company.org";
                    break;
                case 2:
                    Email.Text = "юзер@екзампл.ком";
                    break;
                case 3:
                    Email.Text = "somebody@org";
                    break;
                case 4:
                    Email.Text = "notAnEmail";
                    break;
                default:
                    Email.Text = "somebody@company.org";
                    break;
            }
            ValidateEmail(sender, e);
        }

        public void ValidateEmail(object sender, EventArgs e)
        {
            var value = EmailValidator.Validate(Email.Text);
            var value2 = EmailValidator.Validate(Email.Text, true);
            var value3 = EmailValidator.Validate(Email.Text, false, true);
            var value4 = EmailValidator.Validate(Email.Text, true, true);
            Result.Text =
              $"Allowing both international and top level domains. Your email address is {(value4? "valid" : "invalid")}.\n" +
              $"Allowing just international addresses. Your email address is {(value3? "valid" : "invalid")}.\n" + 
              $"Allowing just top level domains. Your email address is {(value2? "valid" : "invalid")}.\n" +
              $"Do not allow either of these. Your email address is {(value ? "valid" : "invalid")}.";  
        }
    }
}
