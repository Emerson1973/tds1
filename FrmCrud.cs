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
    public partial class FrmCrud : Form
    {
        SqlConnection con = new SqlConnection("Data Source=senaiaula.database.windows.net;Initial Catalog=aula;Persist Security Info=True;User ID=emerson;Password=@maral1973");
        public FrmCrud()
        {
            InitializeComponent();
        }

        public void CarregaDgv()
        {
            String str = "Data Source=senaiaula.database.windows.net;Initial Catalog=aula;Persist Security Info=True;User ID=emerson;Password=@maral1973";
            String query = "select * from cliente";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable cliente = new DataTable();
            da.Fill(cliente);
            dgvCliente.DataSource = cliente;
            con.Close();
        }

        private void FrmCrud_Load(object sender, EventArgs e)
        {
            CarregaDgv();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Inserir", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cpf", SqlDbType.NChar).Value = txtCpf.Text.Trim();
            cmd.Parameters.AddWithValue("@nome", SqlDbType.NChar).Value = txtNome.Text.Trim();
            cmd.Parameters.AddWithValue("@endereco", SqlDbType.NChar).Value = txtEndereco.Text.Trim();
            cmd.Parameters.AddWithValue("@celular", SqlDbType.NChar).Value = txtCelular.Text.Trim();
            cmd.Parameters.AddWithValue("@email", SqlDbType.NChar).Value = txtEmail.Text.Trim();
            cmd.ExecuteNonQuery();
            CarregaDgv();
            MessageBox.Show("Cliente Cadastrado com sucesso!", "Cadastro de Cliente");
            txtCpf.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            con.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Atualizar", con);
                cmd.Parameters.AddWithValue("@cpf", this.txtCpf.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", this.txtNome.Text);
                cmd.Parameters.AddWithValue("@endereco", this.txtEndereco.Text);
                cmd.Parameters.AddWithValue("@celular", this.txtCelular.Text);
                cmd.Parameters.AddWithValue("@email", this.txtEmail.Text);
                cmd.ExecuteNonQuery();
                CarregaDgv();
                MessageBox.Show("Cliente Atualizado com sucesso!", "Atualização de Cliente");
                txtCpf.Text = "";
                txtNome.Text = "";
                txtEndereco.Text = "";
                txtCelular.Text = "";
                txtEmail.Text = "";
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Excluir", con);
                cmd.Parameters.AddWithValue("@cpf", this.txtCpf.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                CarregaDgv();
                MessageBox.Show("Cliente excluído com sucesso!", "Exclusão de Cliente");
                txtCpf.Text = "";
                txtNome.Text = "";
                txtEndereco.Text = "";
                txtCelular.Text = "";
                txtEmail.Text = "";
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
                SqlCommand cmd = new SqlCommand("Localizar", con);
                cmd.Parameters.AddWithValue("@cpf", this.txtCpf.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtCpf.Text = rd["cpf"].ToString();
                    txtNome.Text = rd["nome"].ToString();
                    txtEndereco.Text = rd["endereco"].ToString();
                    txtCelular.Text = rd["celular"].ToString();
                    txtEmail.Text = rd["email"].ToString();
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

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvCliente.Rows[e.RowIndex];
                txtCpf.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtEndereco.Text = row.Cells[2].Value.ToString();
                txtCelular.Text = row.Cells[3].Value.ToString();
                txtEmail.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCpf.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtCpf.Select();
        }
    }
}