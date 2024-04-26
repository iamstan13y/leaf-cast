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
    }
}