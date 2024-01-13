
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.ButtonTrajetos = new System.Windows.Forms.Button();
            this.ButtonHorários = new System.Windows.Forms.Button();
            this.ButtonFuncionários = new System.Windows.Forms.Button();
            this.ButtonBilhetes = new System.Windows.Forms.Button();
            this.ButtonComboios = new System.Windows.Forms.Button();
            this.ButtonEstações = new System.Windows.Forms.Button();
            this.PanelEstações = new System.Windows.Forms.Panel();
            this.PictureEstação = new System.Windows.Forms.PictureBox();
            this.panelForms = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelPrincipal.SuspendLayout();
            this.PanelEstações.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEstação)).BeginInit();
            this.panelForms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.BackColor = System.Drawing.Color.ForestGreen;
            this.PanelPrincipal.Controls.Add(this.ButtonTrajetos);
            this.PanelPrincipal.Controls.Add(this.ButtonHorários);
            this.PanelPrincipal.Controls.Add(this.ButtonFuncionários);
            this.PanelPrincipal.Controls.Add(this.ButtonBilhetes);
            this.PanelPrincipal.Controls.Add(this.ButtonComboios);
            this.PanelPrincipal.Controls.Add(this.ButtonEstações);
            this.PanelPrincipal.Controls.Add(this.PanelEstações);
            this.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(211, 655);
            this.PanelPrincipal.TabIndex = 0;
            // 
            // ButtonTrajetos
            // 
            this.ButtonTrajetos.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonTrajetos.FlatAppearance.BorderSize = 0;
            this.ButtonTrajetos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.ButtonTrajetos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonTrajetos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonTrajetos.ForeColor = System.Drawing.Color.White;
            this.ButtonTrajetos.Image = ((System.Drawing.Image)(resources.GetObject("ButtonTrajetos.Image")));
            this.ButtonTrajetos.Location = new System.Drawing.Point(0, 565);
            this.ButtonTrajetos.Name = "ButtonTrajetos";
            this.ButtonTrajetos.Size = new System.Drawing.Size(211, 95);
            this.ButtonTrajetos.TabIndex = 6;
            this.ButtonTrajetos.Text = "Trajetos";
            this.ButtonTrajetos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonTrajetos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonTrajetos.UseVisualStyleBackColor = true;
            this.ButtonTrajetos.Click += new System.EventHandler(this.ButtonTrajetos_Click);
            // 
            // ButtonHorários
            // 
            this.ButtonHorários.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonHorários.FlatAppearance.BorderSize = 0;
            this.ButtonHorários.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.ButtonHorários.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHorários.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonHorários.ForeColor = System.Drawing.Color.White;
            this.ButtonHorários.Image = ((System.Drawing.Image)(resources.GetObject("ButtonHorários.Image")));
            this.ButtonHorários.Location = new System.Drawing.Point(0, 470);
            this.ButtonHorários.Name = "ButtonHorários";
            this.ButtonHorários.Size = new System.Drawing.Size(211, 95);
            this.ButtonHorários.TabIndex = 5;
            this.ButtonHorários.Text = "Horários";
            this.ButtonHorários.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonHorários.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonHorários.UseVisualStyleBackColor = true;
            this.ButtonHorários.Click += new System.EventHandler(this.ButtonHorários_Click);
            // 
            // ButtonFuncionários
            // 
            this.ButtonFuncionários.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonFuncionários.FlatAppearance.BorderSize = 0;
            this.ButtonFuncionários.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.ButtonFuncionários.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonFuncionários.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonFuncionários.ForeColor = System.Drawing.Color.White;
            this.ButtonFuncionários.Image = ((System.Drawing.Image)(resources.GetObject("ButtonFuncionários.Image")));
            this.ButtonFuncionários.Location = new System.Drawing.Point(0, 375);
            this.ButtonFuncionários.Name = "ButtonFuncionários";
            this.ButtonFuncionários.Size = new System.Drawing.Size(211, 95);
            this.ButtonFuncionários.TabIndex = 4;
            this.ButtonFuncionários.Text = "Funcionários";
            this.ButtonFuncionários.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonFuncionários.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonFuncionários.UseVisualStyleBackColor = true;
            this.ButtonFuncionários.Click += new System.EventHandler(this.ButtonFuncionários_Click);
            // 
            // ButtonBilhetes
            // 
            this.ButtonBilhetes.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonBilhetes.FlatAppearance.BorderSize = 0;
            this.ButtonBilhetes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.ButtonBilhetes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonBilhetes.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonBilhetes.ForeColor = System.Drawing.Color.White;
            this.ButtonBilhetes.Image = ((System.Drawing.Image)(resources.GetObject("ButtonBilhetes.Image")));
            this.ButtonBilhetes.Location = new System.Drawing.Point(0, 280);
            this.ButtonBilhetes.Name = "ButtonBilhetes";
            this.ButtonBilhetes.Size = new System.Drawing.Size(211, 95);
            this.ButtonBilhetes.TabIndex = 3;
            this.ButtonBilhetes.Text = "Bilhetes";
            this.ButtonBilhetes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonBilhetes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonBilhetes.UseVisualStyleBackColor = true;
            this.ButtonBilhetes.Click += new System.EventHandler(this.ButtonBilhetes_Click);
            // 
            // ButtonComboios
            // 
            this.ButtonComboios.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonComboios.FlatAppearance.BorderSize = 0;
            this.ButtonComboios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.ButtonComboios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonComboios.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonComboios.ForeColor = System.Drawing.Color.White;
            this.ButtonComboios.Image = ((System.Drawing.Image)(resources.GetObject("ButtonComboios.Image")));
            this.ButtonComboios.Location = new System.Drawing.Point(0, 185);
            this.ButtonComboios.Name = "ButtonComboios";
            this.ButtonComboios.Size = new System.Drawing.Size(211, 95);
            this.ButtonComboios.TabIndex = 2;
            this.ButtonComboios.Text = "Comboios";
            this.ButtonComboios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonComboios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonComboios.UseVisualStyleBackColor = true;
            this.ButtonComboios.Click += new System.EventHandler(this.ButtonComboios_Click);
            // 
            // ButtonEstações
            // 
            this.ButtonEstações.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonEstações.FlatAppearance.BorderSize = 0;
            this.ButtonEstações.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.ButtonEstações.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEstações.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonEstações.ForeColor = System.Drawing.Color.White;
            this.ButtonEstações.Image = ((System.Drawing.Image)(resources.GetObject("ButtonEstações.Image")));
            this.ButtonEstações.Location = new System.Drawing.Point(0, 90);
            this.ButtonEstações.Name = "ButtonEstações";
            this.ButtonEstações.Size = new System.Drawing.Size(211, 95);
            this.ButtonEstações.TabIndex = 1;
            this.ButtonEstações.Text = "Estações";
            this.ButtonEstações.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonEstações.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonEstações.UseVisualStyleBackColor = true;
            this.ButtonEstações.Click += new System.EventHandler(this.ButtonEstações_Click);
            // 
            // PanelEstações
            // 
            this.PanelEstações.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.PanelEstações.Controls.Add(this.PictureEstação);
            this.PanelEstações.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelEstações.Location = new System.Drawing.Point(0, 0);
            this.PanelEstações.Name = "PanelEstações";
            this.PanelEstações.Size = new System.Drawing.Size(211, 90);
            this.PanelEstações.TabIndex = 1;
            this.PanelEstações.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // PictureEstação
            // 
            this.PictureEstação.BackColor = System.Drawing.Color.Transparent;
            this.PictureEstação.Image = ((System.Drawing.Image)(resources.GetObject("PictureEstação.Image")));
            this.PictureEstação.Location = new System.Drawing.Point(12, 12);
            this.PictureEstação.Name = "PictureEstação";
            this.PictureEstação.Size = new System.Drawing.Size(190, 71);
            this.PictureEstação.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureEstação.TabIndex = 0;
            this.PictureEstação.TabStop = false;
            // 
            // panelForms
            // 
            this.panelForms.Controls.Add(this.pictureBox1);
            this.panelForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForms.Location = new System.Drawing.Point(211, 0);
            this.panelForms.Name = "panelForms";
            this.panelForms.Size = new System.Drawing.Size(698, 655);
            this.panelForms.TabIndex = 1;
            this.panelForms.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(291, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(404, 619);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(909, 655);
            this.Controls.Add(this.panelForms);
            this.Controls.Add(this.PanelPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Rede Comboios";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelEstações.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureEstação)).EndInit();
            this.panelForms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelPrincipal;
        private System.Windows.Forms.Panel PanelEstações;
        private System.Windows.Forms.PictureBox PictureEstação;
        private System.Windows.Forms.Button ButtonEstações;
        private System.Windows.Forms.Button ButtonTrajetos;
        private System.Windows.Forms.Button ButtonHorários;
        private System.Windows.Forms.Button ButtonFuncionários;
        private System.Windows.Forms.Button ButtonBilhetes;
        private System.Windows.Forms.Button ButtonComboios;
        private System.Windows.Forms.Panel panelForms;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

