using Xunit;
using System;
using FluentAssertions;
using CurrencyConversion.Net.Domain.Entities;

namespace CurrencyConversion.Net.Tests.Domain
{
    public class CurrencyTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("", "USD")]
        [InlineData("Real Brasileiro", "")]
        public void ShouldReturningExceptionIfAttributeIsInvalid(string name, string code)
        {
            Action act = () => { new Currency(name, code); };
            act.Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 100)]
        [InlineData(2, 0, 100)]
        [InlineData(2, 1, 0)]
        public void ShouldReturningExceptionIfValuesConvertionIsInvalid(decimal rateDolarFrom, decimal rateDolarTo, decimal currencyValueFrom)
        {
            var currency = new Currency("Dolar", "USD");
            decimal valueTo = 0;

            Action act = () => { valueTo = currency.CurrencyConvert(rateDolarFrom, rateDolarTo, currencyValueFrom); };
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ShouldNotReturnConvertValueEqualZero()
        {
            var currency = new Currency("Euro", "EUR");

            decimal rateDolarFrom = 3.890404m;
            decimal rateDolarTo = 0.885595m;
            decimal currencyValueFrom = 100;

            decimal valueTo = currency.CurrencyConvert(rateDolarFrom, rateDolarTo, currencyValueFrom);

            valueTo.Should().NotBe(0);
        }
    }
}
