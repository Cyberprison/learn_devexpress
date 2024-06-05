using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace learn_devexpress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            sqlQuery sql = new sqlQuery();

            Task<DataTable> res = sql.GetProducts();

            gridControl1.DataSource = await res;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ProductReport report = new ProductReport();

            clsQuery query = new clsQuery();

            List<ProductList> list = query.GetProductListReport();

            report.DataSource = list;
            report.Parameters["rManager"].Value = textEdit1.EditValue;

            report.RequestParameters = false;
            report.ShowPreview();

        }
    }
}
