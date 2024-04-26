using LiveChartsCore;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView.Extensions;
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

    public IEnumerable<ISeries> Series { get; set; }
}
