using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Maximum length of Symbol: 30")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(30, ErrorMessage = "Maximum length of Symbol: 30")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 100000000)]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.001, 10000)]
        public decimal Dividend { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Maximum length of Industry: 30")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(0.001, 10000)]
        public decimal LastDiv { get; set; }

        [Required]
        [Range(1, 100000000000)]
        public long MarketCap { get; set; }
    }
}
