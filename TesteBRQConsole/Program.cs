using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBRQConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			string command = "i";
			List<ITrade> trades = new List<ITrade>();

			while (command.ToLower() == "i" || command.ToLower() == "e" || command.ToLower() == "d")
			{
				Trade.PrintTrades(trades);

				switch (command.ToLower())
				{
					case "i":
						trades.Add(Trade.InsertTrade());
						break;
					case "e":
						trades = Trade.EditTrade(trades);
						break;
					case "d":
						trades = Trade.DeleteTrade(trades);
						break;
				}

				command = Trade.GetCommand();
			}
		}
	}
}
