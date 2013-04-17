using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorldApp.BusinessObjects
{
	public class RootContainer
	{
		/// <summary>
		/// Control signs (Tab, NewLine, \0) are also serialized
		/// </summary>
		public char[] SingleArrayOfChars { get; set; }





		/// <summary>
		/// Creates testdata.
		/// </summary>
		/// <returns></returns>
		public static RootContainer CreateFakeRoot()
		{
			var root = new RootContainer();

			root.SingleArrayOfChars = new char[] 
			{ 
			  'o'
			, '\t'	// mc++ Bug in mono <= 3.x.x
			, '\n'
			,(char)0 
			};
			
			return root;
		}

	}
}
