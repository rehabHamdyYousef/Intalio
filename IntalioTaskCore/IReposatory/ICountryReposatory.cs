using IntalioTaskCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntalioTaskCore.IReposatory
{
    public interface ICountryReposatory
    {
        List<countries> GetAllCountry();
        countries GetById(int Id);
    }
}
