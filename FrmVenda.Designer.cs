using System;

namespace BDStored
{
    partial class FrmVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblCliente = new System.Windows.Forms.Label();
            this.CbxCliente = new System.Windows.Forms.ComboBox();
            this.BtnNovaVenda = new System.Windows.Forms.Button();
            this.LblQuantidade = new System.Windows.Forms.Label();
            this.TxtQuantidade = new System.Windows.Forms.TextBox();
            this.CbxProduto = new System.Windows.Forms.ComboBox();
            this.LblProduto = new System.Windows.Forms.Label();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.LblValor = new System.Windows.Forms.Label();
            this.BtnNovoItem = new System.Windows.Forms.Button();
            this.DgvVenda = new System.Windows.Forms.DataGridView();
            this.TxtValorTotal = new System.Windows.Forms.TextBox();
            this.LblValorTotal = new System.Windows.Forms.Label();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.BtnSair = new System.Windows.Forms.Button();
            this.BtnExcluirItem = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.LblId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVenda)).BeginInit();
            this.SuspendLayout();
            // 
            // LblCliente
            // 
            this.LblCliente.AutoSize = true;
            this.LblCliente.Location = new System.Drawing.Point(13, 26);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.Size = new System.Drawing.Size(39, 13);
            this.LblCliente.TabIndex = 0;
            this.LblCliente.Text = "Cliente";
            // 
            // CbxCliente
            // 
            this.CbxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxCliente.FormattingEnabled = true;
            this.CbxCliente.Location = new System.Drawing.Point(58, 23);
            this.CbxCliente.Name = "CbxCliente";
            this.CbxCliente.Size = new System.Drawing.Size(315, 21);
            this.CbxCliente.TabIndex = 1;
            // 
            // BtnNovaVenda
            // 
            this.BtnNovaVenda.Location = new System.Drawing.Point(379, 21);
            this.BtnNovaVenda.Name = "BtnNovaVenda";
            this.BtnNovaVenda.Size = new System.Drawing.Size(117, 23);
            this.BtnNovaVenda.TabIndex = 2;
            this.BtnNovaVenda.Text = "Nova Venda";
            this.BtnNovaVenda.UseVisualStyleBackColor = true;
            this.BtnNovaVenda.Click += new System.EventHandler(this.BtnNovaVenda_Click);
            // 
            // LblQuantidade
            // 
            this.LblQuantidade.AutoSize = true;
            this.LblQuantidade.Location = new System.Drawing.Point(13, 138);
            this.LblQuantidade.Name = "LblQuantidade";
            this.LblQuantidade.Size = new System.Drawing.Size(62, 13);
            this.LblQuantidade.TabIndex = 3;
            this.LblQuantidade.Text = "Quantidade";
            // 
            // TxtQuantidade
            // 
            this.TxtQuantidade.Location = new System.Drawing.Point(81, 135);
            this.TxtQuantidade.Name = "TxtQuantidade";
            this.TxtQuantidade.Size = new System.Drawing.Size(77, 20);
            this.TxtQuantidade.TabIndex = 4;
            this.TxtQuantidade.TextChanged += new System.EventHandler(this.TxtQuantidade_TextChanged);
            this.TxtQuantidade.Leave += new System.EventHandler(this.TxtQuantidade_Leave);
            // 
            // CbxProduto
            // 
            this.CbxProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxProduto.FormattingEnabled = true;
            this.CbxProduto.Location = new System.Drawing.Point(59, 76);
            this.CbxProduto.Name = "CbxProduto";
            this.CbxProduto.Size = new System.Drawing.Size(315, 21);
            this.CbxProduto.TabIndex = 6;
            this.CbxProduto.SelectedIndexChanged += new System.EventHandler(this.CbxProduto_SelectedIndexChanged);
            // 
            // LblProduto
            // 
            this.LblProduto.AutoSize = true;
            this.LblProduto.Location = new System.Drawing.Point(14, 79);
            this.LblProduto.Name = "LblProduto";
            this.LblProduto.Size = new System.Drawing.Size(44, 13);
            this.LblProduto.TabIndex = 5;
            this.LblProduto.Text = "Produto";
            // 
            // TxtValor
            // 
            this.TxtValor.Location = new System.Drawing.Point(59, 161);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(99, 20);
            this.TxtValor.TabIndex = 8;
            // 
            // LblValor
            // 
            this.LblValor.AutoSize = true;
            this.LblValor.Location = new System.Drawing.Point(13, 164);
            this.LblValor.Name = "LblValor";
            this.LblValor.Size = new System.Drawing.Size(31, 13);
            this.LblValor.TabIndex = 7;
            this.LblValor.Text = "Valor";
            // 
            // BtnNovoItem
            // 
            this.BtnNovoItem.Location = new System.Drawing.Point(178, 103);
            this.BtnNovoItem.Name = "BtnNovoItem";
            this.BtnNovoItem.Size = new System.Drawing.Size(117, 23);
            this.BtnNovoItem.TabIndex = 9;
            this.BtnNovoItem.Text = "Novo Item";
            this.BtnNovoItem.UseVisualStyleBackColor = true;
            this.BtnNovoItem.Click += new System.EventHandler(this.BtnNovoItem_Click);
            // 
            // DgvVenda
            // 
            this.DgvVenda.AllowUserToAddRows = false;
            this.DgvVenda.AllowUserToDeleteRows = false;
            this.DgvVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVenda.Location = new System.Drawing.Point(12, 190);
            this.DgvVenda.Name = "DgvVenda";
            this.DgvVenda.ReadOnly = true;
            this.DgvVenda.Size = new System.Drawing.Size(493, 150);
            this.DgvVenda.TabIndex = 10;
            this.DgvVenda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVenda_CellClick);
            // 
            // TxtValorTotal
            // 
            this.TxtValorTotal.Enabled = false;
            this.TxtValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtValorTotal.Location = new System.Drawing.Point(405, 348);
            this.TxtValorTotal.Name = "TxtValorTotal";
            this.TxtValorTotal.Size = new System.Drawing.Size(99, 20);
            this.TxtValorTotal.TabIndex = 12;
            this.TxtValorTotal.TextChanged += new System.EventHandler(this.TxtValorTotal_TextChanged);
            // 
            // LblValorTotal
            // 
            this.LblValorTotal.AutoSize = true;
            this.LblValorTotal.Location = new System.Drawing.Point(342, 351);
            this.LblValorTotal.Name = "LblValorTotal";
            this.LblValorTotal.Size = new System.Drawing.Size(58, 13);
            this.LblValorTotal.TabIndex = 11;
            this.LblValorTotal.Text = "Valor Total";
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Location = new System.Drawing.Point(386, 374);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(117, 23);
            this.BtnFinalizar.TabIndex = 13;
            this.BtnFinalizar.Text = "Finalizar Venda";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // BtnSair
            // 
            this.BtnSair.Location = new System.Drawing.Point(263, 374);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(117, 23);
            this.BtnSair.TabIndex = 14;
            this.BtnSair.Text = "Sair";
            this.BtnSair.UseVisualStyleBackColor = true;
            this.BtnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // BtnExcluirItem
            // 
            this.BtnExcluirItem.Location = new System.Drawing.Point(178, 161);
            this.BtnExcluirItem.Name = "BtnExcluirItem";
            this.BtnExcluirItem.Size = new System.Drawing.Size(117, 23);
            this.BtnExcluirItem.TabIndex = 15;
            this.BtnExcluirItem.Text = "Excluir Item";
            this.BtnExcluirItem.UseVisualStyleBackColor = true;
            this.BtnExcluirItem.Click += new System.EventHandler(this.BtnExcluirItem_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(178, 132);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(117, 23);
            this.BtnEditar.TabIndex = 16;
            this.BtnEditar.Text = "Editar Item";
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(81, 109);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(77, 20);
            this.txtId.TabIndex = 18;
            // 
            // LblId
            // 
            this.LblId.AutoSize = true;
            this.LblId.Location = new System.Drawing.Point(13, 112);
            this.LblId.Name = "LblId";
            this.LblId.Size = new System.Drawing.Size(58, 13);
            this.LblId.TabIndex = 17;
            this.LblId.Text = "ID Produto";
            // 
            // FrmVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 402);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.LblId);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnExcluirItem);
            this.Controls.Add(this.BtnSair);
            this.Controls.Add(this.BtnFinalizar);
            this.Controls.Add(this.TxtValorTotal);
            this.Controls.Add(this.LblValorTotal);
            this.Controls.Add(this.DgvVenda);
            this.Controls.Add(this.BtnNovoItem);
            this.Controls.Add(this.TxtValor);
            this.Controls.Add(this.LblValor);
            this.Controls.Add(this.CbxProduto);
            this.Controls.Add(this.LblProduto);
            this.Controls.Add(this.TxtQuantidade);
            this.Controls.Add(this.LblQuantidade);
            this.Controls.Add(this.BtnNovaVenda);
            this.Controls.Add(this.CbxCliente);
            this.Controls.Add(this.LblCliente);
            this.Name = "FrmVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendas";
            this.Load += new System.EventHandler(this.FrmVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvVenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BtnEditarItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label LblCliente;
        private System.Windows.Forms.ComboBox CbxCliente;
        private System.Windows.Forms.Button BtnNovaVenda;
        private System.Windows.Forms.Label LblQuantidade;
        private System.Windows.Forms.TextBox TxtQuantidade;
        private System.Windows.Forms.ComboBox CbxProduto;
        private System.Windows.Forms.Label LblProduto;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.Label LblValor;
        private System.Windows.Forms.Button BtnNovoItem;
        private System.Windows.Forms.DataGridView DgvVenda;
        private System.Windows.Forms.TextBox TxtValorTotal;
        private System.Windows.Forms.Label LblValorTotal;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.Button BtnExcluirItem;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label LblId;
    }
}