using System;
namespace ShifuChat.BL.CryptoPub
{
	public interface ICryptoWorker
	{
		public string HashPassword(string password, string sault);
		////maybe more,want you think?
	}
}

