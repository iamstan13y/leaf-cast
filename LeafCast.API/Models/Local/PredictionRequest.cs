namespace LeafCast.API.Models.Local;

public class PredictionRequest
{
    public int TobaccoGradeId { get; set; }
    public int Year { get; set; }
    public decimal ActualPrice { get; set; }
    public decimal PredictedPrice { get; set; }
}