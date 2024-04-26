using LiveChartsCore;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using LeafCast.Services;
using LeafCast.Models.Data;

namespace LeafCast.ViewModels;

public partial class TopGradesViewModel : ObservableObject
{
    private IHttpService _httpService;

    public TopGradesViewModel()
    {
        Grades = [
            "A1E",
            "A1EA",
            "B1",
            "B2MD",
            "C2LV",
            "L3OJA",
            "C4EV",
            "C4OFA",
            "C5L",
            "H4R"
        ];

        Years = [
            "2024",
            "2023",
            "2022",
            "2021",
            "2020",
            "2019"

        ];
        SelectedGrade = Grades[0];
        Predictions =
    [
        new Prediction { Id = 1, PredictedPrice = 2.09M, ActualPrice = 2.33M, Year = 2023 },
        new Prediction { Id = 2, PredictedPrice = 3.15M, ActualPrice = 3.08M, Year = 2020 },
        new Prediction { Id = 3, PredictedPrice = 4.27M, ActualPrice = 4.51M, Year = 2024 },
        new Prediction { Id = 4, PredictedPrice = 1.82M, ActualPrice = 1.76M, Year = 2022 },
        new Prediction { Id = 5, PredictedPrice = 5.39M, ActualPrice = 5.24M, Year = 2021 },
        new Prediction { Id = 6, PredictedPrice = 2.54M, ActualPrice = 2.72M, Year = 2020 },
        new Prediction { Id = 7, PredictedPrice = 4.81M, ActualPrice = 4.97M, Year = 2019 },
        new Prediction { Id = 8, PredictedPrice = 1.93M, ActualPrice = 1.88M, Year = 2023 },
        new Prediction { Id = 9, PredictedPrice = 3.62M, ActualPrice = 3.49M, Year = 2022 },
        new Prediction { Id = 10, PredictedPrice = 5.05M, ActualPrice = 5.19M, Year = 2021 }
    ];
        SelectedItem = Predictions[0];
    }

    public IHttpService HttpService
    {
        get { return _httpService; }
        set
        {
            _httpService = value;
            LoadDataAsync();
        }
    }


    public ISeries[] TrendSeries { get; set; } =
    [
        new ColumnSeries<double>
        {
            Name = "Exports (USD)",
            Values = new double[] { 4720495.94, 3248698.67, 1461244.57, 9113863.2, 4798538.38 }
        },
        new ColumnSeries<double>
        {
            Name = "Imports (USD)",
            Values = new double[] { 8576220.92, 7295713.69, 2276123.69, 11127734.07, 8483738.46 }
        }
    ];

    public Axis[] XAxes { get; set; } =
    [
        new Axis
        {
            Labels = new string[] { "2019", "2020", "2021", "2022", "2023" },
            LabelsRotation = 0,
            SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
            SeparatorsAtCenter = false,
            TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),
            TicksAtCenter = true,
            ForceStepToMin = true,
            MinStep = 10000000
        }
    ];

    public async Task LoadDataAsync()
    {
        if (_httpService == null)
            return;

        var result = await _httpService.GetTopGradesAsync();

        if (result.Success)
        {
            var outer = 0;
            var data = result.Data;

            Series = data.Select((entry, index) =>
            {
                var series = new PieSeries<decimal>
                {
                    Name = entry.Key,
                    Values = new List<decimal> { entry.Value },
                    OuterRadiusOffset = outer
                };
                outer += 50;

                series.DataLabelsPaint = new SolidColorPaint(SKColors.White)
                {
                    SKTypeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold)
                };

                series.ToolTipLabelFormatter = point =>
                {
                    var pv = point.Coordinate.PrimaryValue;
                    return $"{entry.Key}: {pv}%"; // Customize the tooltip as needed
                };

                series.DataLabelsFormatter = point =>
                {
                    var pv = point.Coordinate.PrimaryValue;
                    return $"{entry.Key}: {pv}%"; // Customize the data labels as needed
                };

                return series;
            }).ToList();
        }
    }

    public async Task LoadMarketTrendsAsync()
    {

    }

    public IEnumerable<ISeries> Series { get; set; }

    public List<Prediction> Predictions { get; set; }
    public Prediction SelectedItem { get; set; }
    public List<string> Grades { get; set; }
    public string SelectedGrade { get; set; }
    public List<string> Years { get; set; }
    public string SelectedYear { get; set; }
}
