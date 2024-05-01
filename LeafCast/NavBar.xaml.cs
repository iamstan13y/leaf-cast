namespace LeafCast;

public partial class NavBar : ContentView
{
    public NavBar()
    {
        InitializeComponent();

        var viewMoreGestureRecognizer = new TapGestureRecognizer();
        viewMoreGestureRecognizer.Tapped += async (s, e) =>
        {
            await Navigation.PushAsync(new ProfileSettingsPage());
        };

        profileTab.GestureRecognizers.Add(viewMoreGestureRecognizer);

        var statsGestureRecognizer = new TapGestureRecognizer();
        statsGestureRecognizer.Tapped += async (s, e) =>
        {
            await Navigation.PushAsync(new PredictionsPage());
        };

        statsTab.GestureRecognizers.Add(statsGestureRecognizer);

        var dashGestureRecognizer = new TapGestureRecognizer();
        dashGestureRecognizer.Tapped += async (s, e) =>
        {
            await Navigation.PushAsync(new DashboardPage());
        };

        dashTab.GestureRecognizers.Add(dashGestureRecognizer);

        var xGestureRecognizer = new TapGestureRecognizer();
        xGestureRecognizer.Tapped += async (s, e) =>
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Exit", "Are you sure you want to exit the app?", "Yes", "No");
            if (answer)
            {
              

                // OR

                // Terminate the process
                 Environment.Exit(0);

                // OR

                // Call platform-specific code to exit the app
                // DependencyService.Get<IExitAppService>().ExitApp();
            }

        };

        x.GestureRecognizers.Add(xGestureRecognizer);
    }
}