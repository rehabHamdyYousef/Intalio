using IntalioTaskCore.Entities;
using IntalioTaskCore.IReposatory;
using IntalioTaskCore.IServices;
using System;
using System.Collections.Generic;

namespace IntalioTaskService
{
    public class countriesService : ICountryService
    {
        ICountryReposatory _countryReposatory;
        public countriesService(ICountryReposatory countryReposatory)
        {
            _countryReposatory = countryReposatory;
        }
        public List<countries> GetAllCountry()
        {
            try
            {
                var result = _countryReposatory.GetAllCountry();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
