using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
	public class OutletDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Region { get; set; }
		public float Profit { get; set; }

        public OutletDTO() { }
        public OutletDTO(OutletDTO outl)
        {
            Id = outl.Id;
            Name = outl.Name;
            Region = outl.Region;
            Profit = outl.Profit;
        }
    }
}
