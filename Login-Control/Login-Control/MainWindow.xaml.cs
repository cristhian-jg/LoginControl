using System.Windows;
using User_Control;

namespace Login_Control
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void LoginPanel_LoginIn(object sender, RoutedEventArgs e)
        {
            RoutedLoginEventArgs routed = e as RoutedLoginEventArgs;
            if (routed != null)
            {
                if (routed.Result.Equals(LoginResult.Ok))
                {
                    MessageBox.Show("La contraseña es correcta. Bienvenido" + routed.Usuario + "\nResultado [" + routed.Result + "]");
                }
                else if (routed.Result.Equals(LoginResult.Fail))
                {
                    MessageBox.Show("La contraseña es incorrecta. \nResultado [" + routed.Result + "]. Vuelve a intentarlo...");
                }
                else if (routed.Result.Equals(LoginResult.Canceled))
                {
                    MessageBox.Show("Se ha cancelado la operación... \nResultado [" + routed.Result + "]");
                }
            }
        }
    }
}
