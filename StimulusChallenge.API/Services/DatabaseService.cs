using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using Microsoft.Extensions.Configuration;

using StimulusChallenge.API.Models;

namespace StimulusChallenge.API.Services
{
    public class DatabaseService : IDatabaseService
    {
        public Stats GetStats(IConfiguration config)
        {
            var objectList = new List<Stats>();
            
            using (var conn = new SqlConnection(config.GetConnectionString("MyDbConnection")))
            {
                const string command = "CALL stimuluschallenge.get_stats;";
                
                using (var sqlCmd = new SqlCommand(command, conn))
                {
                    conn.Open();
                    var reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var resultObj = new Stats
                        {
                            SmallBizTotal = Convert.ToInt32(reader["TotalSmallBiz"]),
                            NonProfitTotal = Convert.ToInt32(reader["TotalNonProfit"]),
                            PledgeTotal = Convert.ToInt32(reader["TotalPledges"])
                        };
                        
                        objectList.Add(resultObj);
                    }
                }
            }
            
            return objectList.First();
        }

        public int SavePledge(IConfiguration config, Pledge pledge)
        {
            var result = 0;

            using (var conn = new SqlConnection(config.GetConnectionString("MyDbConnection")))
            {
                const string command = "INSERT INTO Pledge (Name, Email, ZipCode, NonProfit, SmallBiz) VALUES (@Name, @Email, @ZipCode, @NonProfit, @SmallBiz);";

                using (var sqlCmd = new SqlCommand(command, conn))
                {
                    sqlCmd.Parameters.AddWithValue("@Name", pledge.Name);
                    sqlCmd.Parameters.AddWithValue("@Email", pledge.Email);
                    sqlCmd.Parameters.AddWithValue("@ZipCode", pledge.ZipCode);
                    sqlCmd.Parameters.AddWithValue("@NonProfit", pledge.NonProfit);
                    sqlCmd.Parameters.AddWithValue("@SmallBiz", pledge.SmallBiz);

                    //var retParam = sqlCmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    //retParam.Direction = ParameterDirection.ReturnValue;
                    
                    conn.Open();
                    sqlCmd.ExecuteReader();
                    //result = Convert.ToInt32(retParam.Value);
                }
            }
            
            return result;
        }
    }
}