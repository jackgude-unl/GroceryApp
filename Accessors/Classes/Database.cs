using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessors.Classes
{
    public class Database
    {
        private const string ConnectionString = "Server=localhost\\sqlexpress; Database=CSCE361; Trusted_Connection=True; Encrypt=false;";

        public Database() {}

        internal static DataTable ExecuteQuery(string query)
        {
            DataTable dbTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using SqlCommand cmd = new SqlCommand(query, conn);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    dbTable.Load(reader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
                return dbTable;
            }
        }

        public int ExecuteNonquery(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    using SqlCommand cmd = new SqlCommand(query, conn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return 0;
                }
            }
        }

        public bool TestConnection()
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
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
