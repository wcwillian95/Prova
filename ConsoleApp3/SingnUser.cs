namespace ConsoleApp3
{
    internal class SingnUser
    {
        private string _nome;
        private string _sexo;
        private int _idade;
        private string _email;
        private float _irmaos;
        public string Nome
        {
            get { return _nome; }
            set { this._nome = value; }
        }

        public string Sexo
        {
            get { return _sexo; }
            set { this._sexo = value; }
        }
        public string Email
        {
            get { return _email; }
            set { this._email = value; }
        }
        public int Idade
        {
            get { return _idade; }
            set { this._idade = value; }

        }
        public float qtdIrmaos
        {
            get { return _irmaos; }
            set { this._irmaos = value; }

        }

    }
}