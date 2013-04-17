using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorldApp.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			Form1 form1 = new Form1();
			form1.serializeXmlButton_Click(null, null);
			form1.serializeBurstBinary_Click(null, null);
			form1.serializeSizeOptimizedBinary_Click(null, null);

			return;
		}
	}
}
