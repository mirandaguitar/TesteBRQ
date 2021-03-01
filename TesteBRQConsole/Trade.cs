using System;
using System.Collections.Generic;

namespace TesteBRQConsole
{
	class Trade : ITrade
	{
		public double Value { get; set; }
		public string ClientSector { get; set; }
		public string Category
		{
			get
			{
				if (ClientSector.ToLower() == "private")
				{
					if (Value < 1000000)
						return "MEDIUMRISK";
					else
						return "HIGHRISK";
				} 
				else
				{
					if (Value < 1000000)
						return "LOWRISK";
					else
						return "MEDIUMRISK";
				}
			}
		}

		public static ITrade InsertTrade()
		{
			double value = 0.0;
			int sector = 0;
			ITrade trade = new Trade();

			do
			{
				Console.Write("Please, type the trade value: ");
			} while (!double.TryParse(Console.ReadLine(), out value));

			do
			{
				Console.Write("Please, type '1' for Private Sector or '2' for Public Sector: ");
			} while (!int.TryParse(Console.ReadLine(), out sector) && (sector != 1 && sector != 2));

			trade.Value = value;
			trade.ClientSector = sector == 1 ? "Private" : "Public";

			return trade;
		}

		private static int GetIndex(string action)
		{
			int index = 0;

			do
			{
				Console.Write("Type the index of the trade to {0}: ", action);
			} while (!int.TryParse(Console.ReadLine(), out index));

			return (index - 1);
		}

		public static List<ITrade> EditTrade(List<ITrade> trades)
		{
			ITrade trade = new Trade();
			int index = 0; 

			if (trades.Count > 0)
			{
				index = GetIndex("edit");
				trade = InsertTrade();
				trades[index] = trade;
			}
			else
				Console.WriteLine("Empty list!");

			return trades;
		}

		public static List<ITrade> DeleteTrade(List<ITrade> trades)
		{
			if (trades.Count > 0)
				trades.RemoveAt(GetIndex("delete"));
			else
				Console.WriteLine("Empty list!");

			return trades;
		}

		public static void PrintTrades(List<ITrade> trades)
		{
			int i = 0;

			if (trades.Count == 0)
				Console.WriteLine("The list of trades is empty!");
			else 
			{
				foreach (var t in trades)
				{
					Console.WriteLine((i + 1).ToString() + " - Value: $" + trades[i].Value.ToString() + ", Client Sector: " + trades[i].ClientSector + ", Category: " + trades[i].Category + ".");
					i++;
				}

				Console.ReadLine();
			}
		}

		public static string GetCommand()
		{
			string command = "";

			do
			{
				Console.WriteLine("Type 'I', if you want to add one more trade.");
				Console.WriteLine("Type 'E', if you want to list the trades and select one to edit.");
				Console.Write("Or type 'D', if you want to delete a trade in the list: ");
				command = Console.ReadLine();
			} while (command.ToLower() != "i" && command.ToLower() != "e" && command.ToLower() != "d");

			return command;
		}
	}
}
