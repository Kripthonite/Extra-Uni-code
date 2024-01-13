
namespace WinFormsApp1
{
    partial class FrmEstações
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
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ButtonRemoverEstação = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAdicionarEstação = new System.Windows.Forms.Button();
            this.textBoxNPlataformas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNlinhas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textboxNomeAdd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ButtonAdicionarBalcão = new System.Windows.Forms.Button();
            this.textBoxNFuncionário = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxNBalcão = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxNomeEstaçãoBalcão = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(151, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 75);
            this.label1.TabIndex = 0;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(698, 655);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ButtonRemoverEstação);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.buttonAdicionarEstação);
            this.tabPage1.Controls.Add(this.textBoxNPlataformas);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBoxNlinhas);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textboxNomeAdd);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(690, 627);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Adicionar/Remover";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // ButtonRemoverEstação
            // 
            this.ButtonRemoverEstação.Location = new System.Drawing.Point(509, 447);
            this.ButtonRemoverEstação.Name = "ButtonRemoverEstação";
            this.ButtonRemoverEstação.Size = new System.Drawing.Size(127, 29);
            this.ButtonRemoverEstação.TabIndex = 11;
            this.ButtonRemoverEstação.Text = "Remover";
            this.ButtonRemoverEstação.UseVisualStyleBackColor = true;
            this.ButtonRemoverEstação.Click += new System.EventHandler(this.ButtonRemoverEstação_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(68, 447);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(372, 29);
            this.textBox4.TabIndex = 10;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 422);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 22);
            this.label7.TabIndex = 9;
            this.label7.Text = "Nome da Estação";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(68, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 32);
            this.label6.TabIndex = 8;
            this.label6.Text = "Remover";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // buttonAdicionarEstação
            // 
            this.buttonAdicionarEstação.Location = new System.Drawing.Point(509, 224);
            this.buttonAdicionarEstação.Name = "buttonAdicionarEstação";
            this.buttonAdicionarEstação.Size = new System.Drawing.Size(127, 29);
            this.buttonAdicionarEstação.TabIndex = 7;
            this.buttonAdicionarEstação.Text = "Adicionar";
            this.buttonAdicionarEstação.UseVisualStyleBackColor = true;
            this.buttonAdicionarEstação.Click += new System.EventHandler(this.buttonAdicionarEstação_Click);
            // 
            // textBoxNPlataformas
            // 
            this.textBoxNPlataformas.Location = new System.Drawing.Point(264, 224);
            this.textBoxNPlataformas.Name = "textBoxNPlataformas";
            this.textBoxNPlataformas.Size = new System.Drawing.Size(176, 29);
            this.textBoxNPlataformas.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nº Plataformas";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBoxNlinhas
            // 
            this.textBoxNlinhas.Location = new System.Drawing.Point(68, 224);
            this.textBoxNlinhas.Name = "textBoxNlinhas";
            this.textBoxNlinhas.Size = new System.Drawing.Size(148, 29);
            this.textBoxNlinhas.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nº Linhas";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textboxNomeAdd
            // 
            this.textboxNomeAdd.Location = new System.Drawing.Point(68, 140);
            this.textboxNomeAdd.Name = "textboxNomeAdd";
            this.textboxNomeAdd.Size = new System.Drawing.Size(372, 29);
            this.textboxNomeAdd.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nome da Estação";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(68, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Adicionar";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonSearch);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(690, 627);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Listar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(533, 40);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(112, 29);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(51, 88);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(594, 509);
            this.dataGridView2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(438, 29);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.textBox8);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.ButtonAdicionarBalcão);
            this.tabPage3.Controls.Add(this.textBoxNFuncionário);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.textBoxNBalcão);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.textBoxNomeEstaçãoBalcão);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(690, 627);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Balcão";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaGreen;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(68, 450);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 141);
            this.panel2.TabIndex = 19;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(562, 141);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(503, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 29);
            this.button1.TabIndex = 17;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox8.Location = new System.Drawing.Point(68, 388);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(366, 29);
            this.textBox8.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(68, 359);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(170, 22);
            this.label16.TabIndex = 15;
            this.label16.Text = "Nome da Estação";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.Maroon;
            this.label15.Location = new System.Drawing.Point(68, 309);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(173, 32);
            this.label15.TabIndex = 14;
            this.label15.Text = "Ver Balcões";
            // 
            // ButtonAdicionarBalcão
            // 
            this.ButtonAdicionarBalcão.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonAdicionarBalcão.Location = new System.Drawing.Point(503, 216);
            this.ButtonAdicionarBalcão.Name = "ButtonAdicionarBalcão";
            this.ButtonAdicionarBalcão.Size = new System.Drawing.Size(127, 29);
            this.ButtonAdicionarBalcão.TabIndex = 13;
            this.ButtonAdicionarBalcão.Text = "Adicionar";
            this.ButtonAdicionarBalcão.UseVisualStyleBackColor = true;
            this.ButtonAdicionarBalcão.Click += new System.EventHandler(this.ButtonAdicionarBalcão_Click);
            // 
            // textBoxNFuncionário
            // 
            this.textBoxNFuncionário.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxNFuncionário.Location = new System.Drawing.Point(240, 214);
            this.textBoxNFuncionário.Name = "textBoxNFuncionário";
            this.textBoxNFuncionário.Size = new System.Drawing.Size(194, 29);
            this.textBoxNFuncionário.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(240, 189);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(142, 22);
            this.label14.TabIndex = 11;
            this.label14.Text = "Nº Funcionário";
            // 
            // textBoxNBalcão
            // 
            this.textBoxNBalcão.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxNBalcão.Location = new System.Drawing.Point(68, 214);
            this.textBoxNBalcão.Name = "textBoxNBalcão";
            this.textBoxNBalcão.Size = new System.Drawing.Size(156, 29);
            this.textBoxNBalcão.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(68, 189);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 22);
            this.label13.TabIndex = 9;
            this.label13.Text = "Nº Balcão";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // textBoxNomeEstaçãoBalcão
            // 
            this.textBoxNomeEstaçãoBalcão.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxNomeEstaçãoBalcão.Location = new System.Drawing.Point(68, 144);
            this.textBoxNomeEstaçãoBalcão.Name = "textBoxNomeEstaçãoBalcão";
            this.textBoxNomeEstaçãoBalcão.Size = new System.Drawing.Size(366, 29);
            this.textBoxNomeEstaçãoBalcão.TabIndex = 8;
            this.textBoxNomeEstaçãoBalcão.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(68, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(170, 22);
            this.label12.TabIndex = 7;
            this.label12.Text = "Nome da Estação";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 16);
            this.label11.TabIndex = 6;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(68, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(237, 32);
            this.label10.TabIndex = 5;
            this.label10.Text = "Adicionar Balcão";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 16);
            this.label8.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(80, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 32);
            this.label9.TabIndex = 3;
            // 
            // FrmEstações
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(698, 655);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEstações";
            this.Text = "FrmEstações";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textboxNomeAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNlinhas;
        private System.Windows.Forms.Button buttonAdicionarEstação;
        private System.Windows.Forms.TextBox textBoxNPlataformas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ButtonRemoverEstação;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxNomeEstaçãoBalcão;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button ButtonAdicionarBalcão;
        private System.Windows.Forms.TextBox textBoxNFuncionário;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxNBalcão;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}