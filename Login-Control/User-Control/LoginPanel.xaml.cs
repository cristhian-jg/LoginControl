using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace User_Control
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class LoginPanel : UserControl
    {
    
        #region Resultados
        public enum LoginResult
        {
            Ok,
            Fail,
            Canceled
        }
        #endregion

        public static readonly string usuario = "Cristhian";
        public static readonly string contrasenya = "02mK2d%s";

        public static readonly System.Windows.RoutedEvent ReturnIdentifyLogin
            = System.Windows.EventManager.RegisterRoutedEvent(
                "Identify Login",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(LoginPanel)
                );

        public LoginPanel()
        {
            InitializeComponent();
        }

        static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        private void onClickLogin(object sender, RoutedEventArgs e)
        {
            bool validado = false;
            string input;

            if (tbUsuario.Text.Equals(usuario))
            {
                input = Hash(tbContrasenya.Text);

                if (input == contrasenya)
                {
                    validado = true;
                }
                
            }
        }
    }
}
