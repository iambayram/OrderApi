using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _NETCHALLENGE.Models
{
	public class CarrierConfiguration
	{
        [Key]
		public int CarrierConfigurationId { get; set; }

        public int CarrierMaxDesi { get; set; }

        public int CarrierMinDesi{ get; set; }

        public decimal CarrierCost { get; set; }

        [ForeignKey("CarrierId")]
        public Carrier carrierId { get; set; }

    }
}

