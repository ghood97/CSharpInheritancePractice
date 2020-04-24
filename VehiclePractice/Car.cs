using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclePractice
{
    class Car : Vehicle
    {
		private string type;
		private bool hatchback;

		public Car(string v, int year, string make, string model, string color, int mpg, string type, bool hatch)
			: base(v, year, make, model, color, mpg)
		{
			this.type = type;
			this.hatchback = hatch;
		}

		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		public bool Hatchback
		{
			get { return hatchback; }
			set { hatchback = value; }
		}

		public override string ToString()
		{
			return base.ToString() + "\nType: " + type + "\nHatchback?:" + (hatchback ? "Yes" : "No");
		}

	}
}
