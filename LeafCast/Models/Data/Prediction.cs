namespace LeafCast.Models.Data;

public class Prediction
{
    public int Id { get; set; }
    public int TobaccoGradeId { get; set; }
    public int Year { get; set; }
    public decimal ActualPrice { get; set; }
    public decimal PredictedPrice { get; set; }
    public TobaccoGrade? TobaccoGrade { get; set; }
}