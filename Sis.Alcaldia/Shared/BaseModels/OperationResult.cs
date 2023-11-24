using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpa.Alcadia.Shared.BaseModels
{
	public class OperationResult<T> where T : class
	{
		public bool Status { get; set; }
		public T Data { get; set; }
		public IDictionary<string, dynamic> Metadata { get; set; }
		public string Message { get; set; }
	}
}
