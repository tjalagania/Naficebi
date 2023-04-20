using NaficebiLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.DataBaseAccessLayer
{
    public class MsAccessDb : IMsAccessDb<PrincipalModel>
    {
        private string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";

        public readonly string? _db;

        public MsAccessDb(string db)
        {
            _db = db;
            ConnectionString = @$"{ConnectionString}{_db}";

        }
        public async Task<IEnumerable<PrincipalModel>> GetAccessTablesAsync()
        {
            List<PrincipalModel> list = new List<PrincipalModel>();
            return await Task.Run(async () =>
            {
                using (OleDbConnection con = new(ConnectionString))
                {


                    con.Open();
                    OleDbCommand com = con.CreateCommand();
                    com.CommandText = "Select * From court";
                    OleDbDataReader reader = (OleDbDataReader)await com.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        PrincipalModel prModel = new PrincipalModel()
                        {
                            PV_NUNMBER = reader[0].ToString(),
                            LAST = reader[1].ToString(),
                            FIRST = reader[2].ToString(),
                            BIRTH_DATE = reader[3].ToString(),
                            BP_FULL_ADDRESS = reader[4].ToString(),
                        };
                        list.Add(prModel);
                    }
                    return list;
                }
            });


  
        }
        ~MsAccessDb()
        {
            GC.Collect();
        }
    }
}
