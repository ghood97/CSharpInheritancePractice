using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclePractice
{
    class Truck : Vehicle
    {
		private bool towPackage;
		private int numWheels;

		public Truck(string v, int year, string make, string model, string color, int mpg, bool tow, int wheels)
			: base(v, year, make, model, color, mpg)
		{
			this.towPackage = tow;
			this.numWheels = wheels;
		}

		public bool TowPackage
		{
			get { return towPackage; }
			set { towPackage = value; }
		}

		public int NumWheels
		{
			get { return numWheels; }
			set { numWheels = value; }
		}

		public override string ToString()
		{
			return base.ToString() + "\nTow package?: " + (towPackage ? "Yes" : "No") + "\nNumber of wheels: " + numWheels;
		}


	}
}
