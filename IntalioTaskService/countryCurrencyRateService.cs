using IntalioTaskCore.Entities;
using IntalioTaskCore.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using IntalioTaskCore.IReposatory;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using IntalioTaskCore.Helper;

namespace IntalioTaskService
{
    public class countryCurrencyRateService : ICountryCurrencyRateService
    {
        ICountryCurrencyRateReposatory _countryCurrencyReposatory;
        ICountryReposatory _countryReposatory;
        public countryCurrencyRateService(ICountryCurrencyRateReposatory countryRateReposatory, ICountryReposatory countryReposatory)
        {
            _countryCurrencyReposatory = countryRateReposatory;
            _countryReposatory = countryReposatory;
        }
        public async Task<bool> ConfirmRate(countryCurrencyRate countryRate)
        {
            try
            {
                // Check if Country Is Save Or Not 
                var result = _countryCurrencyReposatory.CheckCountry(countryRate.country_code);
                string countryname = _countryReposatory.GetById(countryRate.country_code).country_name;
                var CurrenyRate = await GetRatesOfCurrencies(countryname);
                countryRate.USDRate = CurrenyRate.USD;
                countryRate.EURRate = CurrenyRate.EUR;
                if (result) //Edit
                {
                    _countryCurrencyReposatory.EditRate(countryRate);
                }
                else //New
                {
                    _countryCurrencyReposatory.AddRate(countryRate);
                }
                return true;
            }
            catch(Exception ex) { return false; }

        }
        public List<countryCurrencyRate> GetAll()
        {
            try
            {
                var result = _countryCurrencyReposatory.GetAll();
                return result;
            }
            catch(Exception ex) { throw ex; }
        }
        
        private async Task<CurrencyRate> GetRatesOfCurrencies(string Country)
        {
            Reservation reservationList = new Reservation();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://v6.exchangerate-api.com/v6/8ab9cff3f1cc4a42307dc502/latest/"+ Country))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                }
            }
            var CurrencyRate = new CurrencyRate { USD = reservationList.conversion_rates.USD, EUR = reservationList.conversion_rates.EUR };
            return CurrencyRate;
        }

    }
}
