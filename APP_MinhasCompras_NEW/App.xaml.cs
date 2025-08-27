namespace APP_MinhasCompras_NEW
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new Views.ListaProduto());
        }

        
    }
}