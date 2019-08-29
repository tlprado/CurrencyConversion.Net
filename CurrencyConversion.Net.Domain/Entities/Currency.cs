using System;

namespace CurrencyConversion.Net.Domain.Entities
{
    public class Currency
    {
        public string Name { get; private set; }
        public string Code { get; private set; }

        public Currency(string name, string code)
        {
            SetName(name);
            SetCode(code);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException("O nome da moeda não pode ser informado");

            Name = name;
        }

        public void SetCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new InvalidOperationException("O código da moeda não pode ser informado");

            Code = code;
        }

        public decimal CurrencyConvert(decimal rateDolarFrom, decimal rateDolarTo, decimal currencyValueFrom)
        {
            if (rateDolarFrom == 0 || rateDolarTo == 0 || currencyValueFrom == 0)
                throw new InvalidOperationException("Serviço para consultar taxas esta com problemas!");

            var currencyDolarValueFrom = currencyValueFrom / rateDolarFrom;
            var convertedValue = currencyDolarValueFrom * rateDolarTo;

            return Math.Round(convertedValue, 2);
        }
    }
}
