using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.BusinessLayer
{
	internal  class Animal
	{
		public int Quantity { get; set; } 
		public string Name { get; set; } 

		public virtual string MakeSound()
		{
			return "";
		}

		public virtual int GiveMilk()
		{
			return 0;
		}

		public virtual int Reproduce()
		{
			return 0;
		}
	}
}
