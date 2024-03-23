namespace LeafCast
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new DashboardPage();//new NavigationPage(new SplashScreenPage());
        }
    }
}
