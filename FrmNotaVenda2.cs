using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BDStored
{
    public partial class FrmNotaVenda2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=senaiaula.database.windows.net;Initial Catalog=aula;Persist Security Info=True;User ID=emerson;Password=@maral1973");
        public FrmNotaVenda2()
        {
            InitializeComponent();
        }

        private void FrmNotaVenda2_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(id_venda) as ultimo from tb_venda", con);
            int ultimo = (int)cmd.ExecuteScalar();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                txbUltima.Text = rd["ultimo"].ToString();
            }
        }
    }
}
