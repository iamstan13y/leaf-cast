﻿namespace LeafCast;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

        var signUpTapGestureRecognizer = new TapGestureRecognizer();
        signUpTapGestureRecognizer.Tapped += async (s, e) =>
        {
            await Navigation.PushAsync(new SignUpPage());
        };

        signUpLabel.GestureRecognizers.Add(signUpTapGestureRecognizer);

        var loginTapGestureRecognizer = new TapGestureRecognizer();
        loginTapGestureRecognizer.Tapped += async (s, e) =>
        {
            await Navigation.PushAsync(new DashboardPage());
        };

        loginButton.GestureRecognizers.Add(loginTapGestureRecognizer);
    }
}