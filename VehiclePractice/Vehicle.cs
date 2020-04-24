using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclePractice
{
    public abstract class Vehicle
    {
		private string vinNumber;
		private int year;
		private string make;
		private string model;
		private string color;
		private int mPG;

		public Vehicle(string v, int year, string make, string model, string color, int mpg)
		{
			vinNumber = v;
			this.year = year;
			this.make = make;
			this.model = model;
			this.color = color;
			this.mPG = mpg;
		}

		public string VinNumber
		{
			get { return vinNumber; }
			set { vinNumber = value; }
		}

		public int Year
		{
			get { return year; }
			set { year = value; }
		}

		public string Make
		{
			get { return make; }
			set { make = value; }
		}

		public string Model
		{
			get { return model; }
			set { model = value; }
		}

		public string Color
		{
			get { return color; }
			set { color = value; }
		}

		public int MPG
		{
			get { return mPG; }
			set { mPG = value; }
		}

		public double MilesRemaining(double gallonsRemaining)
		{
			return Math.Round((this.mPG * gallonsRemaining), 2);
		}

		public override string ToString()
		{
			return "Vin #: " + vinNumber + "\nYear: " + year + "\nMake: " + make + "\nModel: " + model + "\nColor: " + color + "\n Miles/Gallon: " + mPG;
		}

	}
}
