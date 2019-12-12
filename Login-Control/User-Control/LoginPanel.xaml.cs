using System;
using System.ComponentModel;
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

        public LoginPanel()
        {
            InitializeComponent();
        }

        #region Resultados
        public enum LoginResult
        {
            Ok,
            Fail,
            Canceled
        }
        #endregion

        public LoginResult _result;
        public string _login;
        public string _password;

        public LoginResult Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        [Category("Inicio sesión")]
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }

        [Category("Inicio sesión")]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _login = value;
            }
        }

        /**
         * Registro del evento enrutado en el
         * EventManager, al que se le pasa nombre, propagación, 
         * tipo y propietario.
         * */
        public static readonly RoutedEvent LoginInEvent =
            EventManager.RegisterRoutedEvent(
                "LoginInEvent",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(LoginPanel)
                );

        /**
         * Definición del evento enrutado 
         * de iniciar sesión
         * */
        public event RoutedEventHandler LoginIn
        {
            add
            {
                AddHandler(LoginInEvent, value);
            }
            remove
            {
                RemoveHandler(LoginInEvent, value);
            }
        }

        /**
         * Metodo que lanzará el evento
         * @return void
         * */
        void RaisesLoginInEvent()
        {
            RoutedEventArgs args =
                new RoutedEventArgs(LoginPanel.LoginInEvent);
            RaiseEvent(args);
        }

        /**
         * Metodo que comprueba la contraseña mediante hash con SHA1.
         * @return string
         * */
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

            if (tbUsuario.Text.Equals(_login))
            {
                if (Hash(tbContrasenya.Text).Equals(Hash(_password)))
                {
                    _result = LoginResult.Ok;
                }
                else _result = LoginResult.Fail;
                
            }
            else _result = LoginResult.Fail;
        }

        private void onClickCancelar(object sender, RoutedEventArgs e)
        {
            _result = LoginResult.Canceled;
        }
    }
}