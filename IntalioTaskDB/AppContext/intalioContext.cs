using IntalioTaskCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntalioTaskDB.AppContext
{
    public class intalioContext: DbContext
    {
        public intalioContext(DbContextOptions<intalioContext> options) : base(options) { }
        public DbSet<countries> Countries { get;set; }
        public DbSet<countryCurrencyRate> countryCurrencyRates { get; set; }
    }
}
