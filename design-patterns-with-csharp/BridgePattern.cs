using System;

public class BridgePattern
{
	class Abstraction
	{
		readonly IBridge bridge;

		public Abstraction (IBridge implementation)
		{
			bridge = implementation;
		}

		public string Operation()
		{
			return "Abstraction" + " <<< BRIDGE >>> " + bridge.OperationImp();
		}
	}

	interface IBridge
	{
		string OperationImp();
	}

	class ImplementationA : IBridge
	{
		public string OperationImp()
		{
			return "ImplementationA";
		}
	}

	class ImplementationB : IBridge
	{
		public string OperationImp()
		{
			return "ImplementationB";
		}
	}

	public static void Client()
	{
		Console.WriteLine("Bridge Pattern\n");
		Console.WriteLine(new Abstraction(new ImplementationA()).Operation());
		Console.WriteLine(new Abstraction(new ImplementationB()).Operation());
	}
}
