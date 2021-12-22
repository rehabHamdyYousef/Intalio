using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntalioTaskCore.Entities;
using IntalioTaskCore.IServices;
using Microsoft.AspNetCore.Mvc;

namespace IntalioTask.Controllers
{
    public class CountryController : Controller
    {
        //Country
        ICountryService _countryService;
        ICountryCurrencyRateService _countryCurrencyRateService;
        public CountryController(ICountryService countryService, ICountryCurrencyRateService countryRateService)
        {
            _countryService = countryService;
            _countryCurrencyRateService = countryRateService;
        }
        public ActionResult ViewPage()
        {
            ViewBag.countries = _countryService.GetAllCountry();
            return View();
        }
        [HttpGet]
        public JsonResult GetAllCountriesWithRate()
        {
            var result = _countryCurrencyRateService.GetAll();
            return Json(result);
        }
        public ActionResult ConfirmCountryCurrencyRate(countryCurrencyRate countryCurrenRate)
        {
            var result = _countryCurrencyRateService.ConfirmRate(countryCurrenRate);
            return RedirectToAction("ViewPage"); ;
        }
        
    }

}
