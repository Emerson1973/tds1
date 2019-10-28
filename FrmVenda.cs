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
    public partial class FrmVenda : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\BDStored\\BDStored\\DataStored.mdf;Integrated Security=True");
        public FrmVenda()
        {
            InitializeComponent();
        }

        public void CarregaCbxCliente()
        {
            string cli = "select cpf, nome from cliente";
            SqlCommand cmd = new SqlCommand(cli, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cli, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "nome");
            CbxCliente.ValueMember = "cpf";
            CbxCliente.DisplayMember = "nome";
            CbxCliente.DataSource = ds.Tables["nome"];
            con.Close();
        }

        public void CarregaCbxProduto()
        {
            string pro = "select Id, nome from produto";
            SqlCommand cmd = new SqlCommand(pro, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(pro, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "nome");
            CbxProduto.ValueMember = "Id";
            CbxProduto.DisplayMember = "nome";
            CbxProduto.DataSource = ds.Tables["nome"];
            con.Close();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void FrmVenda_Load(object sender, EventArgs e)
        {
            if(CbxCliente.DisplayMember == "")
            {
                CbxProduto.Enabled = false;
                TxtQuantidade.Enabled = false;
                TxtValor.Enabled = false;
                TxtValorTotal.Enabled = false;
                DgvVenda.Enabled = false;
                BtnNovoItem.Enabled = false;
                BtnFinalizar.Enabled = false;
                BtnExcluirItem.Enabled = false;
                BtnEditar.Enabled = false;
            }

            CarregaCbxCliente();
        }

        private void BtnNovaVenda_Click(object sender, EventArgs e)
        {
            CbxProduto.Enabled = true;
            TxtQuantidade.Enabled = true;
            TxtValor.Enabled = true;
            DgvVenda.Enabled = true;
            BtnNovoItem.Enabled = true;
            BtnFinalizar.Enabled = true;
            BtnExcluirItem.Enabled = true;
            BtnEditar.Enabled = true;
            CarregaCbxProduto();
            DgvVenda.Columns.Add("ID", "ID");
            DgvVenda.Columns.Add("Produto", "Produto");
            DgvVenda.Columns.Add("Quantidade", "Quantidade");
            DgvVenda.Columns.Add("Valor", "Valor");
            DgvVenda.Columns.Add("Total", "Total");
        }

        private void CbxProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Close();
            SqlCommand cmd = new SqlCommand("ValorProduto", con);
            cmd.Parameters.AddWithValue("@Id", CbxProduto.SelectedValue);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                TxtValor.Text = rd["valor"].ToString();
                txtId.Text = rd["Id"].ToString();
                con.Close();
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado!", "Erro de Registro");
            }
        }

        private void BtnNovoItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow item = new DataGridViewRow();
            item.CreateCells(DgvVenda);
            item.Cells[0].Value = txtId.Text;
            item.Cells[1].Value = CbxProduto.Text;
            item.Cells[2].Value = TxtQuantidade.Text;
            item.Cells[3].Value = TxtValor.Text;
            item.Cells[4].Value = Convert.ToDouble(TxtValor.Text)*Convert.ToDouble(TxtQuantidade.Text);
            DgvVenda.Rows.Add(item);

            CbxProduto.Text = "";
            TxtValor.Text = "";
            TxtQuantidade.Text = "";
            decimal soma = 0;
            foreach (DataGridViewRow dr in DgvVenda.Rows)
            soma += Convert.ToDecimal(dr.Cells[4].Value);
            TxtValorTotal.Text = Convert.ToString(soma);
        }

        private void DgvVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.DgvVenda.Rows[e.RowIndex];
            CbxProduto.Text = row.Cells[1].Value.ToString();
            TxtQuantidade.Text = row.Cells[2].Value.ToString();
            TxtValor.Text = row.Cells[3].Value.ToString();
            int linha = DgvVenda.CurrentRow.Index;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            int linha = DgvVenda.CurrentRow.Index;
            DgvVenda.Rows[linha].Cells[1].Value = CbxProduto.Text;
            DgvVenda.Rows[linha].Cells[2].Value = TxtQuantidade.Text;
            DgvVenda.Rows[linha].Cells[3].Value = TxtValor.Text;
            DgvVenda.Rows[linha].Cells[4].Value = Convert.ToDouble(TxtValor.Text) * Convert.ToDouble(TxtQuantidade.Text);
            decimal soma = 0;
            foreach (DataGridViewRow dr in DgvVenda.Rows)
            soma += Convert.ToDecimal(dr.Cells[4].Value);
            TxtValorTotal.Text = Convert.ToString(soma);
            CbxProduto.Text = "";
            TxtQuantidade.Text = "";
            TxtValor.Text = "";
        }

        private void BtnExcluirItem_Click(object sender, EventArgs e)
        {
            int linha = DgvVenda.CurrentRow.Index;
            DgvVenda.Rows.RemoveAt(linha);
            DgvVenda.Refresh();
            decimal soma = 0;
            foreach (DataGridViewRow dr in DgvVenda.Rows)
            soma += Convert.ToDecimal(dr.Cells[4].Value);
            TxtValorTotal.Text = Convert.ToString(soma);
            CbxProduto.Text = "";
            TxtQuantidade.Text = "";
            TxtValor.Text = "";
        }

        private void TxtValorTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtQuantidade_Leave(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("VerificaEstoque", con);
            cmd.Parameters.AddWithValue("@Id", CbxProduto.SelectedValue);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            int valor1 = 0;
            bool conversaoSucedida = int.TryParse(TxtQuantidade.Text, out valor1);
            if (rd.Read())
            {
                int valor2 = Convert.ToInt32(rd["quantidade"].ToString());

                if (valor1 > valor2)
                {
                    MessageBox.Show("Não tem quantidade suficiente em estoque!", "Estoque");
                    con.Close();
                    TxtQuantidade.Text = "";
                    TxtQuantidade.Focus();
                }
            }
            else
            {
                con.Close();
            }
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("InserirVenda", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@valor_pago", SqlDbType.Decimal).Value = Convert.ToDecimal(TxtValorTotal.Text);
            cmd.Parameters.AddWithValue("@id_pessoa", SqlDbType.NChar).Value = CbxCliente.SelectedValue;
            cmd.ExecuteNonQuery();
            string idvenda = "SELECT IDENT_CURRENT('tb_venda') AS id_venda";
            SqlCommand cmdvenda = new SqlCommand(idvenda, con);
            Int32 idvenda2 = Convert.ToInt32(cmdvenda.ExecuteScalar());
            foreach (DataGridViewRow dr in DgvVenda.Rows)
            {
                SqlCommand cmditens = new SqlCommand("InserirItens", con);
                cmditens.CommandType = CommandType.StoredProcedure;
                string ven = "update produto set quantidade = (quantidade - @quantidade2) from produto where Id = @id_produto2";
                SqlCommand cmditemvenda = new SqlCommand(ven, con);
                cmditemvenda.Parameters.AddWithValue("@quantidade2", SqlDbType.Int).Value = Convert.ToInt32(dr.Cells[2].Value);
                cmditemvenda.Parameters.AddWithValue("@id_produto2", SqlDbType.Int).Value = Convert.ToInt32(dr.Cells[0].Value);
                cmditens.Parameters.AddWithValue("@quantidade", SqlDbType.Int).Value = Convert.ToInt32(dr.Cells[2].Value);
                cmditens.Parameters.AddWithValue("@id_produto", SqlDbType.Int).Value = Convert.ToInt32(dr.Cells[0].Value);
                cmditens.Parameters.AddWithValue("@id_venda", SqlDbType.Int).Value = idvenda2;
                cmditens.Parameters.AddWithValue("@valor", SqlDbType.Decimal).Value = Convert.ToDecimal(dr.Cells[3].Value);
                cmditens.Parameters.AddWithValue("@valor_total", SqlDbType.Decimal).Value = Convert.ToDecimal(dr.Cells[4].Value);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                cmditens.ExecuteNonQuery();
                cmditemvenda.ExecuteNonQuery();
                con.Close();
            }
            DialogResult venda = MessageBox.Show("Venda realizada com sucesso! Deseja imprimir a nota?", "Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(venda == DialogResult.Yes)
            {
                //this.Close();
                //FrmNotaVenda2 ven = new FrmNotaVenda2();
                //ven.Show();
            }
            else if(venda == DialogResult.No)
            {
                this.Close();
            }
        }

        private void TxtQuantidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}