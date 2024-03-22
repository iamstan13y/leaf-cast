namespace LeafCast;

public partial class SplashScreen : ContentPage
{
	public SplashScreen()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(TimeSpan.FromSeconds(2));
        await Navigation.PushAsync(new LoginPage());
    }
}