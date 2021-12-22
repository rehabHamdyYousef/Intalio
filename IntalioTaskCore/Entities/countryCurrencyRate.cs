using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IntalioTaskCore.Entities
{
   public class countryCurrencyRate
    {
      [Key]
      public int ID { get; set; }
      public string USDRate { get; set; }
      public string EURRate { get; set; }
      public int country_code { get; set; }
      [ForeignKey(nameof(country_code))]
      public virtual countries Countries { get; set; }


    }
}
