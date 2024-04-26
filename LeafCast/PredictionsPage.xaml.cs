using LiveChartsCore;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using LeafCast.Services;
using LeafCast.Models.Data;


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


    public List<Prediction> Predictions { get; set; }
    public Prediction SelectedItem { get; set; }
    public List<string> Grades { get; set; }
    public string SelectedGrade { get; set; }
    public List<int> Years { get; set; }
    public int SelectedYear { get; set; }
    public void YearPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdatePredictedPrice();
    }

    private void UpdatePredictedPrice()
    {
        if (string.IsNullOrEmpty(SelectedGrade) || SelectedYear == 0)
        {
            predictedPrice.Text = "0.00"; // Set default value if no selection
            return;
        }

        // Find the prediction matching the selected grade and year
        var prediction = Predictions.FirstOrDefault(p => p.Id == SelectedGrade && p.Year == SelectedYear);

        if (prediction != null)
        {
            predictedPrice.Text = prediction.PredictedPrice.ToString("0.00"); // Display predicted price
        }
        else
        {
            predictedPrice.Text = "N/A"; // Display "N/A" if no matching prediction found
        }
    }
}