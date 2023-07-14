using System.Collections;
using System.Data;
using Microsoft.Data.SqlClient;

namespace newcontableapi.Utils
{
    public class CustomDataTable
    {
        private readonly string connString = "Server=localhost;Database=new_amigo_contable;Trusted_Connection=True; TrustServerCertificate=True; MultiSubnetFailover=True; user id=sa;password=@lerDev.sql; Integrated Security=false;";
        public bool ErrorStatus { get; private set; }
        public string? ErrorMsg { get; private set; }


        public async Task<DataTable> ExecuteAsync(string name, Hashtable hashtable)
        {
            DataTable resp = new();
            await using (var conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new(name, conn);

                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                IDictionaryEnumerator? el = hashtable.GetEnumerator();

                while (el.MoveNext())
                {
                    if (el.Value == null)
                    {
                        da.SelectCommand.Parameters.AddWithValue(el.Key.ToString(), DBNull.Value);
                    }
                    else
                    {
                        da.SelectCommand.Parameters.AddWithValue(el.Key.ToString(), el.Value);
                    }
                }

                try
                {
                    da.Fill(resp);
                    ErrorStatus = true;
                    ErrorMsg = "";
                }
                catch (SqlException ex)
                {
                    ErrorStatus = false;
                    ErrorMsg = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }

            return resp;
        }
    }
}