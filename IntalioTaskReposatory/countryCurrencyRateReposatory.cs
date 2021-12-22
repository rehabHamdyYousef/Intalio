using System;
using System.Collections.Generic;
using System.Text;
using IntalioTaskCore.Entities;
using IntalioTaskCore.IReposatory;
using IntalioTaskDB.AppContext;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace IntalioTaskReposatory
{
    public class countryCurrencyRateReposatory : ICountryCurrencyRateReposatory
    {
        intalioContext _context;
        public countryCurrencyRateReposatory(intalioContext context)
        {
            _context = context;
        }
        public bool AddRate(countryCurrencyRate countryRate)
        {
            try
            {
                _context.countryCurrencyRates.Add(countryRate);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex) { return false; }
        }

        public bool CheckCountry(int Id)
        {
            var result = _context.countryCurrencyRates.Any(o => o.country_code == Id);
            return result;
        }
        public bool EditRate(countryCurrencyRate countryRate)
        {
            try
            {
                var result = _context.countryCurrencyRates.Where(x => x.country_code == countryRate.country_code).FirstOrDefault();
                result.country_code = countryRate.country_code;
                result.USDRate = countryRate.USDRate;
                result.EURRate = countryRate.EURRate;
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex) { return false; }
        }
        public List<countryCurrencyRate> GetAll()
        {
            var result = _context.countryCurrencyRates.Where(m => m.ID != default).Include("Countries").ToList();
            
            return result;
        }



    }
}
