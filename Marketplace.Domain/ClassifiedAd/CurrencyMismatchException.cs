using System;

namespace Marketplace.Domain.ClassifiedAd
{
  public class CurrencyMismatchException : Exception
  {
    public CurrencyMismatchException(string message) : base(message)
    {
    }
  }
}