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
using System.Security.Cryptography;

namespace BDStored
{
    public partial class FrmUsuario : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\BDStored\\BDStored\\DataStored.mdf;Integrated Security=True");
        public FrmUsuario()
        {
            InitializeComponent();
        }

        public void CarregaDgv()
        {
            String str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\BDStored\\BDStored\\DataStored.mdf;Integrated Security=True";
            String query = "select * from usuario";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable cliente = new DataTable();
            da.Fill(cliente);
            dgvUsuario.DataSource = cliente;
            con.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("InserirUsuario", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@login", SqlDbType.NChar).Value = txtLogin.Text.Trim();
            cmd.Parameters.AddWithValue("@senha", SqlDbType.NChar).Value = txtSenha.Text.Trim();
            cmd.ExecuteNonQuery();
            CarregaDgv();
            MessageBox.Show("Usuário Cadastrado com sucesso!", "Cadastro de Usuário");
            txtLogin.Text = "";
            txtSenha.Text = "";
            con.Close();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            CarregaDgv();
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
                SqlCommand cmd = new SqlCommand("AtualizarUsuario", con);
                cmd.Parameters.AddWithValue("@Id", this.txtId.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", this.txtLogin.Text);
                cmd.Parameters.AddWithValue("@senha", this.txtSenha.Text);
                cmd.ExecuteNonQuery();
                CarregaDgv();
                MessageBox.Show("Usuário atualizado com sucesso!", "Atualização de Usuário");
                txtId.Text = "";
                txtLogin.Text = "";
                txtSenha.Text = "";
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
                SqlCommand cmd = new SqlCommand("ExcluirUsuario", con);
                cmd.Parameters.AddWithValue("@Id", this.txtId.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                CarregaDgv();
                MessageBox.Show("Usuário excluído com sucesso!", "Exclusão de Usuário");
                txtId.Text = "";
                txtLogin.Text = "";
                txtSenha.Text = "";
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtLogin.Text = "";
            txtSenha.Text = "";
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("LocalizarUsuario", con);
                cmd.Parameters.AddWithValue("@login", this.txtLogin.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtId.Text = rd["Id"].ToString();
                    txtLogin.Text = rd["login"].ToString();
                    txtSenha.Text = rd["senha"].ToString();
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

        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvUsuario.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtLogin.Text = row.Cells[1].Value.ToString();
                txtSenha.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}
