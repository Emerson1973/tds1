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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void testeDeBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String str = "Data Source=senaiaula.database.windows.net;Initial Catalog=aula;Persist Security Info=True;User ID=emerson;Password=@maral1973";
                String query = "select * from cliente";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                DataSet ds = new DataSet();
                MessageBox.Show("Conectado ao Banco de Dados!", "Teste de Banco");
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadCliente frm = new FrmCadCliente();
            frm.Show();
        }

        private void cRUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCrud cru = new FrmCrud();
            cru.Show();
        }

        private void cRUDProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProduto pro = new FrmProduto();
            pro.Show();
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVenda ven = new FrmVenda();
            ven.Show();
        }
    }
}
