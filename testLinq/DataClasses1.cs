namespace testLinq
{
	partial class DataClasses1DataContext
	{
		partial void InserttestTable(testTable instance)
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
}