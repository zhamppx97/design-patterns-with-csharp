using System;

class AdapterPattern
{
	// Existing way request are implemented
	class Adaptee
	{
		// Provide full precision
		public double SpecificRequest (double a, double b)
		{
			return a / b;
		}
	}

	// Request standard for requests
	interface ITarget
	{
		// Rough estimate required
		string Request(int i);
	}

	// Implementing the required standard via Adaptee
	class Adapter : Adaptee, ITarget
	{
		public string Request(int i)
		{
			return "Rough estimate is " + (int)Math.Round(SpecificRequest(i, 3));
		}
	}

	class ClassClient
	{
		static void Client()
		{
			Adaptee first = new Adaptee();
			Console.Write("Before the new standard\nPrecise reading: ");
			Console.WriteLine(first.SpecificRequest(5, 3));

			ITarget second = new Adapter();
			Console.WriteLine("\nMoving to the new standard");
			Console.WriteLine(second.Request(5));
		}
	}
}
