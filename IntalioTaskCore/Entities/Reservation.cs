using System;
using System.Collections.Generic;
using System.Text;

namespace IntalioTaskCore.Entities
{
    public class Reservation
    {
        public string result { get; set; }
        public string documentation { get; set; }
        public string terms_of_use { get; set; }
        public string time_last_update_unix { get; set; }
        public string time_last_update_utc { get; set; }
        public string time_next_update_unix { get; set; }
        public string time_next_update_utc { get; set; }
        public string base_code { get; set; }
        public conversion_rate conversion_rates { get; set; }
    }
}
