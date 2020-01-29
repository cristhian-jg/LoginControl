using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Modelo;
using HashGenerator;

namespace User_Control
{

    #region Resultados
    public enum LoginResult
    {
        Ok,
        Fail,
        Canceled
    }
    #endregion

    #region Clase user control
    public partial class LoginPanel : UserControl
    {

        private List<Usuario> listaUsuarios;

        public LoginPanel()
        {
            InitializeComponent();
            GenerateUsers();
        }

        public static readonly RoutedEvent LogInEvent =
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
                AddHandler(LogInEvent, value);
            }
            remove
            {
                RemoveHandler(LogInEvent, value);
            }
        }

        /**
         * Metodo que lanzará el evento
         * @return void
         * */
        void RaiseLogInEvent(string usuario, LoginResult result)
        {
            RoutedLoginEventArgs routedLoginEventArgs =
                 new RoutedLoginEventArgs(LogInEvent, usuario, result);
            RaiseEvent(routedLoginEventArgs);
        }

        private void onClickLogin(object sender, RoutedEventArgs e)
        {
            bool validado = false;
            string usuario = tbUsuario.Text;
            string contrasenya = tbContrasenya.Password;
            string hash = HGenerator.generateHash(contrasenya);

            foreach (Usuario u in listaUsuarios)
            {
                if (u.Hash == hash)
                {
                    validado = true;
                    RaiseLogInEvent(usuario, LoginResult.Ok);
                }
            }
            if (!validado)
            {
                RaiseLogInEvent(usuario, LoginResult.Fail);
            }
        }

        private void onClickCancelar(object sender, RoutedEventArgs e)
        {
            RaiseLogInEvent(tbUsuario.Text, LoginResult.Canceled);
            tbUsuario.Text = "";
            tbContrasenya.Password = "";
        }


        void GenerateUsers()
        {

            listaUsuarios = new List<Usuario>();
            listaUsuarios.Add(new Usuario("Cristhian", "03mr7i21"));
            listaUsuarios.Add(new Usuario("Alvaro", "2756djs"));

        }
    }
    #endregion

    #region Clase RoutedEventArgs
    public class RoutedLoginEventArgs : RoutedEventArgs
    {

        private string usuario; public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }

        private LoginResult result; public LoginResult Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }

        public RoutedLoginEventArgs(RoutedEvent routedEvent, string usuario, LoginResult result) : base(routedEvent)
        {
            this.usuario = usuario;
            this.result = result;
        }
    }
    #endregion
}