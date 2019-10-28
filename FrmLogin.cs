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
    public partial class FrmLogin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\BDStored\\BDStored\\DataStored.mdf;Integrated Security=True");
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usu = "select login, senha from usuario where login = @login and senha = @senha";
            SqlCommand cmd = new SqlCommand(usu, con);
            cmd.Parameters.AddWithValue("@login", SqlDbType.NChar).Value = txtLogin.Text.Trim();
            cmd.Parameters.AddWithValue("@senha", SqlDbType.NChar).Value = txtSenha.Text.Trim();
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataReader usuario = cmd.ExecuteReader();
            if (usuario.HasRows)
            {
                this.Hide();
                FrmPrincipal pri = new FrmPrincipal();
                pri.Show();
                con.Close();
            } else
            {
                MessageBox.Show("Login ou senha inválidos! Tente novamente.", "Erro");
                txtLogin.Text = "";
                txtSenha.Text = "";
                con.Close();
            }
        }
    }
}
