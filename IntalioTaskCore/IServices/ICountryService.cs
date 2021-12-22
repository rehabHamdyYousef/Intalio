using IntalioTaskCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntalioTaskCore.IServices
{
    public interface ICountryService
    {
        List<countries> GetAllCountry();
    }
}
