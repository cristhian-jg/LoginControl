using HashGenerator;

namespace Modelo
{
    public class Usuario
    {
        private string nombre; public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        private string contrasenya; public string Contrasenya
        {
            get
            {
                return contrasenya;
            }
            set
            {
                contrasenya = value;
            }
        }

        private string hash; public string Hash
        {
            get
            {
                return hash;
            }
        }

        public Usuario(string nombre, string contrasenya, string hash)
        {
            this.nombre = nombre;
            this.contrasenya = contrasenya;
            this.hash = hash;
        }

        public Usuario(string nombre, string contrasenya)
        {
            this.nombre = nombre;
            this.contrasenya = contrasenya;
            this.hash = HGenerator.generateHash(contrasenya);
        }

    }
}
