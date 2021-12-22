using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace IntalioTaskCore.Entities
{
    public class countries
    {
        [Key]
        public int country_code { get; set; }
        public string country_name { get; set; }
  //      public virtual ICollection<countryCurrencyRate> CountryRate { get; set; }
    }
}
