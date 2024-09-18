using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.BusinessLayer
{
	internal class Goat : Animal
{
    public Goat(int quantity)
	{
		this.Quantity = quantity;
		this.Name = "Goat";
	}

	public override string MakeSound()
	{
		return "Meh";
	}

	public override int GiveMilk()
	{
		Random rand = new Random();
		return rand.Next(0, 11); 
	}

	public override int Reproduce()
	{
		Random rand = new Random();
		return rand.Next(1, 4); 
	}
}
}
