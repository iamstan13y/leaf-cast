namespace LeafCast;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
        InitializeComponent();

        var loginUpTapGestureRecognizer = new TapGestureRecognizer();
        loginUpTapGestureRecognizer.Tapped += async (s, e) =>
        {
            await Navigation.PushAsync(new LoginPage());
        };

        loginLabel.GestureRecognizers.Add(loginUpTapGestureRecognizer);
    }
}