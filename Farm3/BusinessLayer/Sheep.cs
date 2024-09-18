using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.BusinessLayer
{
	internal class Sheep : Animal
	{
		public Sheep(int quantity)
		{
			this.Quantity = quantity;
			this.Name = "Sheep";
		}

		public override string MakeSound()
		{
			return "Baa";
		}

		public override int GiveMilk()
		{
			Random rand = new Random();
			return rand.Next(0, 6); 
		}

		public override int Reproduce()
		{
			Random rand = new Random();
			return rand.Next(1, 4); 
		}
	}
}
