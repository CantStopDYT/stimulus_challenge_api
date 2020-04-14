using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using StimulusChallenge.API.Models;

namespace StimulusChallenge.API.Services
{
    public class DatabaseService : IDatabaseService
    {
        public Stats GetStats(IConfiguration config)
        {
            var result = new Stats();

            //TODO: Actually call the DB...
            
            return result;
        }

        public int SavePledge(IConfiguration config, Pledge pledge)
        {
            var result = 0;

            using (var conn = new SqlConnection(config.GetConnectionString("DefaultConnection")))
            {
                const string command = "INSERT INTO Pledge (Name, Email, ZipCode, NonProfit, SmallBiz) VALUES (@Name, @Email, @ZipCode, @NonProfit, @SmallBiz);";

                using (var sqlCmd = new SqlCommand(command, conn))
                {
                    sqlCmd.Parameters.AddWithValue("@Name", pledge.Name);
                    sqlCmd.Parameters.AddWithValue("@Email", pledge.Email);
                    sqlCmd.Parameters.AddWithValue("@ZipCode", pledge.ZipCode);
                    sqlCmd.Parameters.AddWithValue("@NonProfit", pledge.NonProfit);
                    sqlCmd.Parameters.AddWithValue("@SmallBiz", pledge.SmallBiz);

                    var retParam = sqlCmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    retParam.Direction = ParameterDirection.ReturnValue;
                    
                    conn.Open();
                    sqlCmd.ExecuteReader();
                    result = Convert.ToInt32(retParam.Value);
                }
            }
            
            return result;
        }
    }
}