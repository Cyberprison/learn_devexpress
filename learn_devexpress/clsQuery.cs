using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace learn_devexpress
{
    public class clsQuery
    {
        private readonly string stCon = @"Data Source=DESKTOP-QOLE0OQ;Initial Catalog=learn_devexpress;Integrated Security=True";

        public List<ProductList> GetProductListReport()
        {
            DataTable result = new DataTable("GetProductListReport");

            List<ProductList> listprod = new List<ProductList>();

            try
            {
                using (SqlConnection con = new SqlConnection(stCon))
                {
                    using (SqlCommand com = new SqlCommand("dbo.procProductListReport", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;

                        con.Open();

                        using (var reader = com.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            result.Load(reader);
                        }
                    }
                }

                listprod = result.AsEnumerable().Select(m => new ProductList()
                {
                    typeName = m.Field<string>("typeName"),
                    productId = m.Field<int>("idProduct"),
                    productName = m.Field<string>("productName"),
                    Price = m.Field<int>("Price"),
                    barCode = m.Field<string>("barcode"),
                }).ToList();



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }

            return listprod;
        }
    }
}