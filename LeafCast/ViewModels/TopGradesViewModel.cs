using CommunityToolkit.Mvvm.ComponentModel;
using LeafCast.Models.Data;
using LeafCast.Services;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;

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
            2024,
            2023,
            2022,
            2021,
            2020,
            2019

        ];
        SelectedGrade = Grades[0];
        Predictions =
    [
         new Prediction { Id = "A1E", PredictedPrice = 2.09M, ActualPrice = 2.33M, Year = 2023 },
        new Prediction { Id = "A1E", PredictedPrice = 2.31M, ActualPrice = 2.35M, Year = 2019 },
        new Prediction { Id = "A1E", PredictedPrice = 2.13M, ActualPrice = 2.21M, Year = 2020 },
        new Prediction { Id = "A1E", PredictedPrice = 2.25M, ActualPrice = 2.29M, Year = 2021 },
        new Prediction { Id = "A1E", PredictedPrice = 2.18M, ActualPrice = 2.26M, Year = 2022 },
        new Prediction { Id = "A1E", PredictedPrice = 2.27M, ActualPrice = 2.33M, Year = 2024 },

        // ID: A1EA
        new Prediction { Id = "A1EA", PredictedPrice = 3.15M, ActualPrice = 3.08M, Year = 2020 },
        new Prediction { Id = "A1EA", PredictedPrice = 3.09M, ActualPrice = 3.12M, Year = 2019 },
        new Prediction { Id = "A1EA", PredictedPrice = 3.18M, ActualPrice = 3.10M, Year = 2021 },
        new Prediction { Id = "A1EA", PredictedPrice = 3.12M, ActualPrice = 3.07M, Year = 2022 },
        new Prediction { Id = "A1EA", PredictedPrice = 3.21M, ActualPrice = 3.16M, Year = 2023 },
        new Prediction { Id = "A1EA", PredictedPrice = 3.17M, ActualPrice = 3.09M, Year = 2024 },

        // ID: B1
        new Prediction { Id = "B1", PredictedPrice = 4.27M, ActualPrice = 4.51M, Year = 2024 },
        new Prediction { Id = "B1", PredictedPrice = 4.34M, ActualPrice = 4.46M, Year = 2019 },
        new Prediction { Id = "B1", PredictedPrice = 4.38M, ActualPrice = 4.45M, Year = 2020 },
        new Prediction { Id = "B1", PredictedPrice = 4.41M, ActualPrice = 4.48M, Year = 2021 },
        new Prediction { Id = "B1", PredictedPrice = 4.45M, ActualPrice = 4.55M, Year = 2022 },
        new Prediction { Id = "B1", PredictedPrice = 4.50M, ActualPrice = 4.58M, Year = 2023 },

        // ID: H4R
        new Prediction { Id = "H4R", PredictedPrice = 1.82M, ActualPrice = 1.76M, Year = 2022 },
        new Prediction { Id = "H4R", PredictedPrice = 1.79M, ActualPrice = 1.85M, Year = 2019 },
        new Prediction { Id = "H4R", PredictedPrice = 1.86M, ActualPrice = 1.80M, Year = 2020 },
        new Prediction { Id = "H4R", PredictedPrice = 1.90M, ActualPrice = 1.84M, Year = 2021 },
        new Prediction { Id = "H4R", PredictedPrice = 1.88M, ActualPrice = 1.82M, Year = 2023 },
        new Prediction { Id = "H4R", PredictedPrice = 1.83M, ActualPrice = 1.79M, Year = 2024 },

        // ID: C2LV
        new Prediction { Id = "C2LV", PredictedPrice = 5.39M, ActualPrice = 5.24M, Year = 2021 },
        new Prediction { Id = "C2LV", PredictedPrice = 5.42M, ActualPrice = 5.31M, Year = 2019 },
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

        //var result = await _httpService.GetTopGradesAsync();

        //if (result.Success)
        //{

        var outer = 0;
        var data = new Dictionary<string, decimal>
        {
            { "C2LV", 25.97M },
            { "L3OJA", 25.52M },
            { "C4OFA", 17.27M },
            { "A1EA", 16M },
            { "H4R", 15.24M }
        };


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
        //}
    }

    public async Task LoadMarketTrendsAsync()
    {

    }

    public IEnumerable<ISeries> Series { get; set; }

    public List<Prediction> Predictions { get; set; }
    public Prediction SelectedItem { get; set; }
    public List<string> Grades { get; set; }
    public string SelectedGrade { get; set; }
    public List<int> Years { get; set; }
    public int SelectedYear { get; set; }




    public ISeries[] PriceSeries { get; set; } =
    [
        new LineSeries<double>
        {
            Name = "A1E",
            Values = new ObservableCollection<double> { 2.35, 2.21, 2.29, 2.26, 2.33, 2.33 }
        },
        new LineSeries<double>
        {
            Name = "A1EA",
            Values = new ObservableCollection<double> { 3.12, 3.08, 3.10, 3.16, 3.07, 3.09 },
        },
        new LineSeries<double>
        {
            Name = "B1",
            Values = new ObservableCollection<double> { 4.34, 4.38, 4.41, 4.45, 4.51, 4.55 },
        },
        new LineSeries<double>
        {
            Name = "H4R",
            Values = new ObservableCollection<double> { 1.79, 1.80, 1.82, 1.84, 1.85, 1.79 },
        },
    ];

    public Axis[] PriceXAxes { get; set; } =
    [
        new Axis
        {
            CrosshairLabelsBackground = SKColors.DarkOrange.AsLvcColor(),
            CrosshairLabelsPaint = new SolidColorPaint(SKColors.DarkRed, 1),
            CrosshairPaint = new SolidColorPaint(SKColors.DarkOrange, 1),
            LabelsRotation = 45,
            Labels = new[]
        {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024"
        }
        }
    ];

    public Axis[] PriceYAxes { get; set; } =
[
    new Axis
    {
        MinLimit = 1,
        MaxLimit = 5,
        ForceStepToMin = true,
        MinStep = 1,
        Labeler = value => value.ToString("C"),
        CrosshairLabelsBackground = SKColors.DarkOrange.AsLvcColor(),
        CrosshairLabelsPaint = new SolidColorPaint(SKColors.DarkRed, 1),
        CrosshairPaint = new SolidColorPaint(SKColors.DarkOrange, 1),
        CrosshairSnapEnabled = true // snapping is also supported
    }
];

}