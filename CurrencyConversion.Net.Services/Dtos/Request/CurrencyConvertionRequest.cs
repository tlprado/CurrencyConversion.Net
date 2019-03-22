namespace CurrencyConversion.Net.Services.Dtos.Request
{
    public class CurrencyConvertionRequest
    {
        public string CurrencyCodeFrom { get; set; }
        public string CurrencyCodeTo { get; set; }
        public decimal CurrencyValueFrom { get; set; }
    }
}
