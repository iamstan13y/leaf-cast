namespace LeafCast;

public partial class SplashScreenPage : ContentPage
{
	public SplashScreenPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(TimeSpan.FromSeconds(3));
        await Navigation.PushAsync(new LoginPage());
    }
}