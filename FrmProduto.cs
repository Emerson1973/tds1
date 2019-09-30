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
    public partial class FrmProduto : Form
    {
        SqlConnection con = new SqlConnection("Data Source=senaiaula.database.windows.net;Initial Catalog=aula;Persist Security Info=True;User ID=emerson;Password=@maral1973");
        public FrmProduto()
        {
            InitializeComponent();
        }

        public void CarregaDgvProduto()
        {
            String str = "Data Source=senaiaula.database.windows.net;Initial Catalog=aula;Persist Security Info=True;User ID=emerson;Password=@maral1973";
            String query = "select * from produto";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable produto = new DataTable();
            da.Fill(produto);
            dgvProduto.DataSource = produto;
            con.Close();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            CarregaDgvProduto();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("InserirProd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nome", SqlDbType.NChar).Value = txtNome.Text.Trim();
            cmd.Parameters.AddWithValue("@tipo", SqlDbType.NChar).Value = txtTipo.Text.Trim();
            cmd.Parameters.AddWithValue("@quantidade", SqlDbType.NChar).Value = txtQuantidade.Text.Trim();
            cmd.Parameters.AddWithValue("@valor", SqlDbType.Decimal).Value = Decimal.Parse(txtValor.Text);
            cmd.ExecuteNonQuery();
            CarregaDgvProduto();
            MessageBox.Show("Produto Cadastrado com sucesso!", "Cadastro de Produto");
            txtId.Text = "";
            txtNome.Text = "";
            txtTipo.Text = "";
            txtQuantidade.Text = "";
            txtValor.Text = "";
            con.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AtualizarProd", con);
                cmd.Parameters.AddWithValue("@Id", this.txtId.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", this.txtNome.Text);
                cmd.Parameters.AddWithValue("@tipo", this.txtTipo.Text);
                cmd.Parameters.AddWithValue("@quantidade", this.txtQuantidade.Text);
                cmd.Parameters.AddWithValue("@valor", Decimal.Parse(this.txtValor.Text));
                cmd.ExecuteNonQuery();
                CarregaDgvProduto();
                MessageBox.Show("Produto atualizado com sucesso!", "Atualização de Produto");
                txtId.Text = "";
                txtNome.Text = "";
                txtTipo.Text = "";
                txtQuantidade.Text = "";
                txtValor.Text = "";
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("LocalizarProd", con);
                cmd.Parameters.AddWithValue("@Id", this.txtId.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtId.Text = rd["Id"].ToString();
                    txtNome.Text = rd["nome"].ToString();
                    txtTipo.Text = rd["tipo"].ToString();
                    txtQuantidade.Text = rd["quantidade"].ToString();
                    txtValor.Text = rd["valor"].ToString();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado!", "Erro de Registro");
                }
            }
            finally
            {

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ExcluirProd", con);
                cmd.Parameters.AddWithValue("@Id", this.txtId.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                CarregaDgvProduto();
                MessageBox.Show("Produto excluído com sucesso!", "Exclusão de Produto");
                txtId.Text = "";
                txtNome.Text = "";
                txtTipo.Text = "";
                txtQuantidade.Text = "";
                txtValor.Text = "";
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtTipo.Text = "";
            txtQuantidade.Text = "";
            txtValor.Text = "";
        }

        private void dgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvProduto.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtTipo.Text = row.Cells[2].Value.ToString();
                txtQuantidade.Text = row.Cells[3].Value.ToString();
                txtValor.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}
