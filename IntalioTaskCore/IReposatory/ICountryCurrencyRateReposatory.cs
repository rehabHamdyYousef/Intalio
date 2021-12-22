using System;
using System.Collections.Generic;
using System.Text;
using IntalioTaskCore.Entities;
namespace IntalioTaskCore.IReposatory
{
    public interface ICountryCurrencyRateReposatory
    {
        bool AddRate(countryCurrencyRate countryRate);
        bool EditRate(countryCurrencyRate countryRate);
        List<countryCurrencyRate> GetAll();
         bool CheckCountry(int Id);
    }
}
