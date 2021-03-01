using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBRQConsole
{
	interface ITrade 
	{
		double Value { get; set; }
		string ClientSector { get; set; }
		string Category { get; }
	}
}
