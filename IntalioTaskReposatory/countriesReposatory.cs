using IntalioTaskCore.Entities;
using IntalioTaskCore.IReposatory;
using IntalioTaskDB.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntalioTaskReposatory
{
    public class countriesReposatory : ICountryReposatory
    {
        intalioContext _intcontext;
        public countriesReposatory(intalioContext context)
        {
            _intcontext = context;
        }
        public List<countries> GetAllCountry()
        {
            var result = _intcontext.Countries.ToList();
            return result;
        }

        public countries GetById(int Id)
        {
            return _intcontext.Countries.Where(x => x.country_code == Id).FirstOrDefault();
        }
    }
}
