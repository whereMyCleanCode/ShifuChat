using System;
namespace ShifuChat.BL.CryptoPub
{
	public interface ICryptoWorker
	{
		public string HashPassword(string password, string sault);
        public string GetCryptoImage(string imageFile);
        ////maybe more,want you think?
    }
}

