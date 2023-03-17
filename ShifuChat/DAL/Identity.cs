using System;
using ShifuChat.DAL.Models;
using ShifuChat.DAL.Helper;
using Dapper;
using Npgsql;
using Microsoft.Data.Sql;

namespace ShifuChat.DAL
{
    public class Identity : IIdentity
    {
        public async Task<int> CreateUser(UserModel model)
        {
            using (var connection = new NpgsqlConnection(Helper.DbHelper.conectString))
            {
              await connection.OpenAsync();

                string sqlResponse =
                 @"insert into users (Firstname, SecondName, Phone,
                 Email, Profession, Salt, Password) 
                 values(@FirstName, @SecondName, @Phone,
                 @Email, @Profession, @Salt, @Password)";

                 return await connection.ExecuteAsync(sqlResponse, model);
            }
        }

        public async Task<UserModel> GetUser(int id)
        {
            using (var connection = new NpgsqlConnection(Helper.DbHelper.conectString))
            {
                await connection.OpenAsync();

                return await connection.QueryFirstOrDefaultAsync<UserModel>(
                @"Select FirstName, SecondName,
                Phone, Email, Profession, Password, Salt
                From Users where Id = @id", new { id = id }) ?? new UserModel();
            }
        }

        public async Task<UserModel> GetUser(string email)
        {
            using (var connection = new NpgsqlConnection(Helper.DbHelper.conectString))
            {
                await connection.OpenAsync();

                return await connection.QueryFirstOrDefaultAsync<UserModel>(
                @"Select FirstName, SecondName,
                Phone, Email, Profession, Password, Salt
                From Users where Email = @email", new { email = email }) ?? new UserModel();

            }
        }    
    }
}

