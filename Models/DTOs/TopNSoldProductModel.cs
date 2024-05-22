namespace MAFTLECOME.Models.DTOs
{
    public record TopNSoldProductModel(string ProductName, decimal Price, int TotalUnitSold);
    public record TopNSoldProductsVm(DateTime StartDate, DateTime EndDate, IEnumerable<TopNSoldProductModel> TopNSoldProducts);
}
