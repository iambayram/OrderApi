using System;
using System.ComponentModel.DataAnnotations;

namespace _NETCHALLENGE.Models
{
	public class Carrier
	{
        [Key]
		public int CarrierId { get; set; }

        public string CarrierName { get; set; }

        public bool CarrierisActive { get; set; }

        public int CarrierPlusDesiCost { get; set; }

        public int CarrierConfigurationId { get; set; }

    }
}

