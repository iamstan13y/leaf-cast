/* Unmerged change from project 'LeafCast (net8.0-maccatalyst)'
Before:
using LiveChartsCore;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using LeafCast.Services;
using LeafCast.Models.Data;
After:
using CommunityToolkit.Mvvm.ComponentModel;
using LeafCast.Models.Data;
using LeafCast.Services;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.Models.Data;
*/

/* Unmerged change from project 'LeafCast (net8.0-ios)'
Before:
using LiveChartsCore;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using LeafCast.Services;
using LeafCast.Models.Data;
After:
using CommunityToolkit.Mvvm.ComponentModel;
using LeafCast.Models.Data;
using LeafCast.Services;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.Models.Data;
*/

/* Unmerged change from project 'LeafCast (net8.0-windows10.0.19041.0)'
Before:
using LiveChartsCore;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using LeafCast.Services;
using LeafCast.Models.Data;
After:
using CommunityToolkit.Mvvm.ComponentModel;
using LeafCast.Models.Data;
using LeafCast.Services;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.Models.Data;
*/

namespace LeafCast;

public partial class PredictionsPage : ContentPage
{
    public PredictionsPage()
    {
        InitializeComponent();

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
        new Prediction { Id = "C2LV", PredictedPrice = 5.39M, ActualPrice = 5.24M, Year = 2019 },
        new Prediction { Id = "C2LV", PredictedPrice = 5.42M, ActualPrice = 5.31M, Year = 2020 },
        new Prediction { Id = "C2LV", PredictedPrice = 5.45M, ActualPrice = 5.29M, Year = 2021 },
        new Prediction { Id = "C2LV", PredictedPrice = 5.48M, ActualPrice = 5.36M, Year = 2022 },
        new Prediction { Id = "C2LV", PredictedPrice = 5.51M, ActualPrice = 5.43M, Year = 2023 },
        new Prediction { Id = "C2LV", PredictedPrice = 5.54M, ActualPrice = 5.47M, Year = 2024 },

        //ID: B2MD
        new Prediction { Id = "B2MD", PredictedPrice = 3.45M, ActualPrice = 3.39M, Year = 2019 },
        new Prediction { Id = "B2MD", PredictedPrice = 3.48M, ActualPrice = 3.41M, Year = 2020 },
        new Prediction { Id = "B2MD", PredictedPrice = 3.51M, ActualPrice = 3.45M, Year = 2021 },
        new Prediction { Id = "B2MD", PredictedPrice = 3.54M, ActualPrice = 3.49M, Year = 2022 },
        new Prediction { Id = "B2MD", PredictedPrice = 3.57M, ActualPrice = 3.52M, Year = 2023 },
        new Prediction { Id = "B2MD", PredictedPrice = 3.60M, ActualPrice = 3.55M, Year = 2024 },

        //ID: C4EV
        new Prediction { Id = "C4EV", PredictedPrice = 1.93M, ActualPrice = 1.88M, Year = 2019 },
        new Prediction { Id = "C4EV", PredictedPrice = 1.97M, ActualPrice = 1.91M, Year = 2020 },
        new Prediction { Id = "C4EV", PredictedPrice = 2.01M, ActualPrice = 1.95M, Year = 2021 },
        new Prediction { Id = "C4EV", PredictedPrice = 2.05M, ActualPrice = 2.00M, Year = 2022 },
        new Prediction { Id = "C4EV", PredictedPrice = 2.09M, ActualPrice = 2.04M, Year = 2023 },
        new Prediction { Id = "C4EV", PredictedPrice = 2.13M, ActualPrice = 2.08M, Year = 2024 },

        //ID: L3OJA
        new Prediction { Id = "L3OJA", PredictedPrice = 2.54M, ActualPrice = 2.72M, Year = 2019 },
        new Prediction { Id = "L3OJA", PredictedPrice = 2.58M, ActualPrice = 2.66M, Year = 2020 },
        new Prediction { Id = "L3OJA", PredictedPrice = 2.62M, ActualPrice = 2.60M, Year = 2021 },
        new Prediction { Id = "L3OJA", PredictedPrice = 2.66M, ActualPrice = 2.58M, Year = 2022 },
        new Prediction { Id = "L3OJA", PredictedPrice = 2.70M, ActualPrice = 2.54M, Year = 2023 },
        new Prediction { Id = "L3OJA", PredictedPrice = 2.74M, ActualPrice = 2.50M, Year = 2024 },

        //ID: C4OFA
        new Prediction { Id = "C4OFA", PredictedPrice = 3.62M, ActualPrice = 3.49M, Year = 2019 },
        new Prediction { Id = "C4OFA", PredictedPrice = 3.68M, ActualPrice = 3.55M, Year = 2020 },
        new Prediction { Id = "C4OFA", PredictedPrice = 3.74M, ActualPrice = 3.61M, Year = 2021 },
        new Prediction { Id = "C4OFA", PredictedPrice = 3.80M, ActualPrice = 3.67M, Year = 2022 },
        new Prediction { Id = "C4OFA", PredictedPrice = 3.86M, ActualPrice = 3.73M, Year = 2023 },
        new Prediction { Id = "C4OFA", PredictedPrice = 3.92M, ActualPrice = 3.79M, Year = 2024 },

        //ID: C5L
        new Prediction { Id = "C5L", PredictedPrice = 5.05M, ActualPrice = 5.19M, Year = 2019 },
        new Prediction { Id = "C5L", PredictedPrice = 5.10M, ActualPrice = 5.25M, Year = 2020 },
        new Prediction { Id = "C5L", PredictedPrice = 5.15M, ActualPrice = 5.31M, Year = 2021 },
        new Prediction { Id = "C5L", PredictedPrice = 5.20M, ActualPrice = 5.37M, Year = 2022 },
        new Prediction { Id = "C5L", PredictedPrice = 5.25M, ActualPrice = 5.43M, Year = 2023 },
        new Prediction { Id = "C5L", PredictedPrice = 5.30M, ActualPrice = 5.49M, Year = 2024 },
    ];
        SelectedItem = Predictions[0];
    }


    public List<Prediction> Predictions { get; set; }
    public Prediction SelectedItem { get; set; }
    public List<string> Grades { get; set; }
    public string SelectedGrade { get; set; }
    public List<string> Years { get; set; }
    public int SelectedYear { get; set; }

    public void YearPicker_SelectedIndexChanged(object sender, EventArgs e) => UpdatePredictedPrice();

    private void UpdatePredictedPrice()
    {
        var prediction = Predictions.FirstOrDefault(p => p.Id == drpGrade.SelectedItem && p.Year == (int)drpYear.SelectedItem);

        if (prediction != null)
        {
            predictedPrice.Text = $"${prediction.PredictedPrice:0.00}";
            actualPrice.Text = $"${prediction.ActualPrice:0.00}";
        }
        else
        {
            predictedPrice.Text = "N/A";
            actualPrice.Text = "N/A";
        }
    }
}