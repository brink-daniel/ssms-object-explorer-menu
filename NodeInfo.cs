using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMedic
{
	public class NodeInfo
	{
		public string Server { get; set; }
		public string Database { get; set; }
		public string Schema { get; set; }
		public string Table { get; set; }
		public string StoredProcedure { get; set; }

		public NodeInfo() { 
		
		}

	}
}
