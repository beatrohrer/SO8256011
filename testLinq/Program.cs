using System.Data.Linq.Mapping;

namespace test
{
	static class Program
	{
		static void Main(string[] args)
		{
			var db = new DataClasses1DataContext(@"Data Source=");
			var testTableRecord1 = new testTable();
			var testTableRecord2 = new testTable();
			db.Connection.Open();
			db.GetTable<testTable>().InsertOnSubmit(testTableRecord1);
			db.SubmitChanges();
			db.GetTable<testTable>().InsertOnSubmit(testTableRecord2);
			db.SubmitChanges();
		}
	}

	[Database(Name = "TestDB")]
	public class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		public DataClasses1DataContext(string fileOrServerOrConnection) : base(fileOrServerOrConnection) { }

		void InserttestTable(testTable instance)
		{
			using(var cmd = Connection.CreateCommand())
			{
				cmd.CommandText = "SELECT NEXT VALUE FOR [dbo].[seq_PK_testTable] as NextId";
				cmd.Transaction = Transaction;
				instance.id = (int)cmd.ExecuteScalar();
				ExecuteDynamicInsert(instance);
			}
		}
	}

	[Table(Name = "dbo.testTable")]
	public class testTable
	{
		[Column(DbType = "Int NOT NULL", IsPrimaryKey = true)]
		public int id;
	}
}