using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _NETCHALLENGE.Models
{
	public class Order
	{
        [Key]
		public int OrderId { get; set; }

        [Required]
        public int OrderDesi { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderCarierCost { get; set; }

        [ForeignKey("CarrierId")]
        public Carrier CarrierId { get; set; }
    }
}

