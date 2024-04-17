namespace LeafCast.API.Models.Local;

public class PredictionRequest
{
    public int TobaccoGradeId { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
}