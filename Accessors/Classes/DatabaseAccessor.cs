using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Accessors.Classes
{
    public class DatabaseAccessor
    {
        private const string ConnectionString = "Server=localhost\\sqlexpress; Database=CSCE361; Trusted_Connection=True; Encrypt=false;";

        internal static DataTable ExecuteQuery(string query, List<SqlParameter> parameters = null!)
        {
            var dbTable = new DataTable();
            using var conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();
                using var cmd = new SqlCommand(query, conn);
                if (!parameters.IsNullOrEmpty())
                    cmd.Parameters.AddRange(parameters.ToArray());
                using var reader = cmd.ExecuteReader();
                dbTable.Load(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
            return dbTable;
        }

        public static int ExecuteNonQuery(string query, List<SqlParameter> parameters = null!)
        {
            using var conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();

                using var cmd = new SqlCommand(query, conn);
                if (!parameters.IsNullOrEmpty())
                    cmd.Parameters.AddRange(parameters.ToArray());
                var rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }

        public bool TestConnection()
        {
            using var conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
    }
}
