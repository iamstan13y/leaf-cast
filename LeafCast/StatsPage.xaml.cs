using LeafCast.Services;
using LeafCast.ViewModels;

namespace LeafCast;

public partial class StatsPage : ContentPage
{
	public StatsPage()
	{
		InitializeComponent();

        //var httpClient = new HttpClient();
        //var httpService = new HttpService(httpClient);
        //InitializeComponent();
        //var viewModel = new TopGradesViewModel
        //{
        //    HttpService = httpService
        //};

        BindingContext = new TopGradesViewModel();
    }
}