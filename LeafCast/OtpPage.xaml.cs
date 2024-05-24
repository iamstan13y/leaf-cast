using LeafCast.Services;

namespace LeafCast;

public partial class OtpPage : ContentPage
{
    private readonly HttpService _httpService;
    public OtpPage()
    {
        InitializeComponent();

        var httpClient = new HttpClient();
        var httpService = new HttpService(httpClient);

        _httpService = httpService;

        signUpButton.Clicked += SignUpButton_Clicked;
    }

    private async void SignUpButton_Clicked(object? sender, EventArgs e)
    {
        activityIndicator.IsRunning = true;
        activityIndicator.IsVisible = true;

        activityIndicator.IsRunning = false;
        activityIndicator.IsVisible = false;

        await DisplayAlert("Success", "Account successfully verified", "OK");
        await Navigation.PushAsync(new LoginPage());

    }
}