using PhoneStore.Models;
using PhoneStore.Services;

namespace PhoneStore.ViewModels;

public class PhoneCurrenciesViewModel
{
    public Phone Phone { get; set; }
    public List<CurrencyRates> CurrencyRatesList { get; set; }
}