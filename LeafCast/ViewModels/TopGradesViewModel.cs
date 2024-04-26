using LiveChartsCore;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using LeafCast.Services;

namespace LeafCast.ViewModels;

public partial class TopGradesViewModel : ObservableObject
{
    private IHttpService _httpService;

    public TopGradesViewModel()
    {
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
            Values = new double[] { 4720495.94, 3248698.67, 1461244.57, 9113863.2, 4798538.38}
        },
        new ColumnSeries<double>
        {
            Name = "Imports (USD)",
            Values = new double[] { 8576220.92, 7295713.69, 2276123.69, 11127734.07, 8483738.46}
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
}
