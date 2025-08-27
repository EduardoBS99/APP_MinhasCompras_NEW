using APP_MinhasCompras_NEW.Helpers;

namespace APP_MinhasCompras_NEW
{
    public partial class App : Application
    {
        // Instância única do banco de dados (singleton)
        static SQLiteDatabaseHelper _db;

        // Propriedade pública para acessar o banco de dados
        public static SQLiteDatabaseHelper Db
        {
            get
            {
                // Se ainda não existe instância, cria uma
                if (_db == null)
                {
                    // Define o caminho físico do banco .db3 no armazenamento local do app
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");

                    // Cria a instância do banco de dados
                    _db = new SQLiteDatabaseHelper(path);
                }

                // Retorna sempre a mesma instância do banco
                return _db;
            }
        }

        // Construtor principal do App
        public App()
        {
            InitializeComponent();

            // Define a página inicial do app como ListaProduto (dentro de uma NavigationPage)
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
