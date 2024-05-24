using LeafCast.Services;
using LeafCast.ViewModels;

namespace LeafCast;

public partial class StatsPage : ContentPage
{
    private async Task InitializeAsync()
    {
        var httpClient = new HttpClient();
        var httpService = new HttpService(httpClient);
        var viewModel = new TopGradesViewModel
        {
            HttpService = httpService
        };

        await viewModel.LoadDataAsync();
        BindingContext = viewModel;
    }

    public StatsPage()
    {
        InitializeComponent();
        InitializeAsync().ConfigureAwait(false);

        var backButtonGestureRecognizer = new TapGestureRecognizer();
        backButtonGestureRecognizer.Tapped += async (s, e) =>
        {
            await Navigation.PushAsync(new DashboardPage());
        };

        backButton.GestureRecognizers.Add(backButtonGestureRecognizer);
    }
}