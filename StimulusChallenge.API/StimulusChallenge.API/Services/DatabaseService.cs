using System;
using System.Data;

using Microsoft.Extensions.Configuration;

using MySql.Data.MySqlClient;

using StimulusChallenge.API.Models;

namespace StimulusChallenge.API.Services
{
    public class DatabaseService : IDatabaseService
    {
        public Stats GetStats(IConfiguration config)
        {
            var result = new Stats();
            
            using (var conn = new MySqlConnection(config.GetConnectionString("DefaultConnection")))
            {
                const string command = "CALL stimuluschallenge.get_stats;";
                
                using (var sqlCmd = new MySqlCommand(command, conn))
                {
                    var smallBiz = sqlCmd.Parameters.Add("@TotalSmallBiz", MySqlDbType.Int32);
                    smallBiz.Direction = ParameterDirection.Output;
                    
                    var nonProfit = sqlCmd.Parameters.Add("@TotalNonProfit", MySqlDbType.Int32);
                    nonProfit.Direction = ParameterDirection.Output;
                    
                    var count = sqlCmd.Parameters.Add("@TotalPledges", MySqlDbType.Int32);
                    count.Direction = ParameterDirection.Output;
                    
                    conn.Open();
                    sqlCmd.ExecuteReader();
                    
                    result.SmallBizTotal = Convert.ToInt32(smallBiz.Value);
                    result.NonProfitTotal = Convert.ToInt32(nonProfit.Value);
                    result.PledgeTotal = Convert.ToInt32(count.Value);
                }
            }
            
            return result;
        }

        public int SavePledge(IConfiguration config, Pledge pledge)
        {
            var result = 0;

            using (var conn = new MySqlConnection(config.GetConnectionString("DefaultConnection")))
            {
                const string command = "INSERT INTO stimuluschallenge.Pledge (Name, Email, ZipCode, NonProfit, SmallBiz) VALUES (@Name, @Email, @ZipCode, @NonProfit, @SmallBiz);";

                using (var sqlCmd = new MySqlCommand(command, conn))
                {
                    sqlCmd.Parameters.AddWithValue("@Name", pledge.Name);
                    sqlCmd.Parameters.AddWithValue("@Email", pledge.Email);
                    sqlCmd.Parameters.AddWithValue("@ZipCode", pledge.ZipCode);
                    sqlCmd.Parameters.AddWithValue("@NonProfit", pledge.NonProfit);
                    sqlCmd.Parameters.AddWithValue("@SmallBiz", pledge.SmallBiz);

                    var retParam = sqlCmd.Parameters.Add("@ReturnVal", MySqlDbType.Int32);
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