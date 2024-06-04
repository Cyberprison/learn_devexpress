using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace learn_devexpress
{
    public class sqlQuery
    {
        //private readonly string MyConn = Properties.Settings.Default.connSql;
        private readonly string MyConn = @"Data Source=DESKTOP-QOLE0OQ;Initial Catalog=learn_devexpress;Integrated Security=True";

        public async Task<DataTable> GetProducts()
        {
            DataTable result = new DataTable("GetProducts");

            try
            {
                using (SqlConnection con = new SqlConnection(MyConn))
                {
                    using (SqlCommand comm = new SqlCommand("procProductList", con))
                    {
                        comm.CommandType = CommandType.StoredProcedure;

                        await con.OpenAsync();

                        using (var reader = await comm.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            result.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }
    }
}