using System;
using System.Transactions;

namespace ShifuTest.Reference
{
	public class Helper
	{
		public static TransactionScope CreateTransactionScope(int second = 1)
		{
			return new TransactionScope(
				TransactionScopeOption.Required,
				new TimeSpan(0,0,second),
				TransactionScopeAsyncFlowOption.Enabled
				);
		}
	}
}

