namespace ShifuTest;

using System.Transactions;
using Reference;
using ShifuChat;
using ShifuChat.BL;

public class IdentityTest: Reference.BaseTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        using (TransactionScope transactionScope = Helper.CreateTransactionScope())
        {
            string email = Guid.NewGuid().ToString() + "test.com";

            var emailValidateResult = await _identityUser.ValidateUser(email);
            Assert.IsNull(emailValidateResult);

            int id = await _identityUser.Create(
            new ShifuChat.DAL.Models.UserModel()
            {
                 Email = email,
                 Password = "qwerty",
            });
            Assert.Greater(id, 0);

            emailValidateResult = await _identityUser.ValidateUser(email);
            Assert.IsNotNull(emailValidateResult);

        }
        Assert.Pass();
    }
}
