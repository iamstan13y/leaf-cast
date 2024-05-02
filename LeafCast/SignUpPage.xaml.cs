using LeafCast.Models.Local;
using LeafCast.Services;

namespace LeafCast;

public partial class SignUpPage : ContentPage
{
    private readonly HttpService _httpService;
    public SignUpPage()
    {
        InitializeComponent();

        var httpClient = new HttpClient();
        var httpService = new HttpService(httpClient);
        
        _httpService = httpService;

        var loginUpTapGestureRecognizer = new TapGestureRecognizer();
        loginUpTapGestureRecognizer.Tapped += async (s, e) =>
        {
            await Navigation.PushAsync(new LoginPage());
        };

        loginLabel.GestureRecognizers.Add(loginUpTapGestureRecognizer);

        signUpButton.Clicked += SignUpButton_Clicked;
    }

    private async void SignUpButton_Clicked(object? sender, EventArgs e)
    {
        activityIndicator.IsRunning = true;
        activityIndicator.IsVisible = true;

        var signUpData = new CreateAccountRequest
        {
            FullName = fullName.Text,
            PhoneNumber = phoneNumber.Text,
            UserName = username.Text,
            Password = password.Text
        };

        var response = await _httpService.CreateAccountAsync(signUpData);

        activityIndicator.IsRunning = false;
        activityIndicator.IsVisible = false;

        if (response.Success)
        {
            await DisplayAlert("Success", "Account created successfully", "OK");
            await Navigation.PushAsync(new OtpPage());
        }
        else
        {
            await DisplayAlert("Error", "Account creation failed", "OK");
        }
    }
}