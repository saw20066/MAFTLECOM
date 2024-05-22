using Humanizer.Localisation;

namespace MAFTLECOME.Models.DTOs
{
    public class ProductDisplayModel
    {
        public IEnumerable<Product> Products { get; set; }
      
        public string STerm { get; set; } = "";
      
    }
}
