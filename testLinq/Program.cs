using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testLinq
{
	static class Program
	{
		static void Main(string[] args)
		{
			var db = new DataClasses1DataContext(@"");
			var testTableRecord1 = new testTable()
			{
				a = 1,
			};

			var testTableRecord2 = new testTable()
			{
				a = 2,
			};

			db.Connection.Open();
			db.testTables.InsertOnSubmit(testTableRecord1);
			db.SubmitChanges();
			
			db.testTables.InsertOnSubmit(testTableRecord2);
			db.SubmitChanges();
			Console.WriteLine($"id1: {testTableRecord1.id}");
			Console.WriteLine($"id2: {testTableRecord2.id}");
		}
	}
}
