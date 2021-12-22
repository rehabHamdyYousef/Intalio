using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IntalioTaskCore.Entities;

namespace IntalioTaskCore.IServices
{
    public interface ICountryCurrencyRateService
    {

        Task<bool> ConfirmRate(countryCurrencyRate countryRate);
        List<countryCurrencyRate> GetAll();
    }
}
