﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
	public class Outlet
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Region { get; set; }
		public float Profit { get; set; }
	}
}
