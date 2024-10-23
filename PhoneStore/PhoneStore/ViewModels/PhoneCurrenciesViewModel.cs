using PhoneStore.Models;
using PhoneStore.Services;

namespace PhoneStore.ViewModels;

public class PhoneCurrenciesViewModel
{
    public Phone Phone { get; set; }
    public List<CurrencyRates> CurrencyRatesList { get; set; }
    public List<Review> Reviews { get; set; }
    public double? AverageGrade { get; set; }
}