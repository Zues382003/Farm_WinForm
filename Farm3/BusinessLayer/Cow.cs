using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.BusinessLayer
{
	internal class Cow : Animal
	{
		public Cow(int quantity)
		{
			this.Quantity = quantity;
			this.Name = "Cow";
		}

		public override string MakeSound()
		{
			return "Moo";
		}

		public override int GiveMilk()
		{
			Random rand = new Random();
			return rand.Next(0, 21); 
		}

		public override int Reproduce()
		{
			Random rand = new Random();
			return rand.Next(1, 5); 
		}
	}

}
