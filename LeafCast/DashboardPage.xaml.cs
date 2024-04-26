using LeafCast.Services;
using LeafCast.ViewModels;
using System.ComponentModel;

namespace LeafCast;

public partial class DashboardPage : ContentPage
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

    public DashboardPage()
	{
        InitializeComponent();
        InitializeAsync().ConfigureAwait(false);

        var viewMoreGestureRecognizer = new TapGestureRecognizer();
        viewMoreGestureRecognizer.Tapped += async (s, e) =>
        {
            await Navigation.PushAsync(new StatsPage());
        };

        viewMoreButton.GestureRecognizers.Add(viewMoreGestureRecognizer);
    }
}