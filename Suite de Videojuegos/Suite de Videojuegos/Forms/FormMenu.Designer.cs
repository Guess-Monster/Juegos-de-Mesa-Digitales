
namespace Suite_de_Videojuegos
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            btnTicTacToe = new Button();
            btnSalir = new Button();
            lblTitulo = new Label();
            btnDamas = new Button();
            btnHistorial = new Button();
            panelSuperior = new Panel();
            picLogo = new PictureBox();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // btnTicTacToe
            // 
            btnTicTacToe.BackColor = Color.FromArgb(52, 152, 219);
            btnTicTacToe.FlatAppearance.BorderSize = 0;
            btnTicTacToe.FlatStyle = FlatStyle.Flat;
            btnTicTacToe.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTicTacToe.ForeColor = SystemColors.ButtonHighlight;
            btnTicTacToe.Location = new Point(293, 136);
            btnTicTacToe.Name = "btnTicTacToe";
            btnTicTacToe.Size = new Size(118, 37);
            btnTicTacToe.TabIndex = 0;
            btnTicTacToe.Text = "Tic-Tac-Toe";
            btnTicTacToe.UseVisualStyleBackColor = false;
            btnTicTacToe.Click += btnTicTacToe_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(52, 152, 219);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSalir.ForeColor = SystemColors.ButtonHighlight;
            btnSalir.Location = new Point(293, 249);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(98, 36);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.FromArgb(45, 45, 65);
            lblTitulo.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.Window;
            lblTitulo.Location = new Point(255, 31);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(306, 40);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Suite de Videojuegos";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // btnDamas
            // 
            btnDamas.BackColor = Color.FromArgb(52, 152, 219);
            btnDamas.FlatAppearance.BorderSize = 0;
            btnDamas.FlatStyle = FlatStyle.Flat;
            btnDamas.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDamas.ForeColor = SystemColors.ButtonHighlight;
            btnDamas.Location = new Point(293, 175);
            btnDamas.Name = "btnDamas";
            btnDamas.Size = new Size(95, 36);
            btnDamas.TabIndex = 3;
            btnDamas.Text = "Damas";
            btnDamas.UseVisualStyleBackColor = false;
            btnDamas.Click += btnDamas_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.BackColor = Color.FromArgb(52, 152, 219);
            btnHistorial.FlatAppearance.BorderSize = 0;
            btnHistorial.FlatStyle = FlatStyle.Flat;
            btnHistorial.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHistorial.ForeColor = SystemColors.ButtonHighlight;
            btnHistorial.Location = new Point(293, 212);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(95, 36);
            btnHistorial.TabIndex = 5;
            btnHistorial.Text = "Historial";
            btnHistorial.UseVisualStyleBackColor = false;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(35, 55, 75);
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(800, 100);
            panelSuperior.TabIndex = 6;
            panelSuperior.Paint += panelSuperior_Paint;
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(12, 112);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(185, 326);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 7;
            picLogo.TabStop = false;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 65);
            ClientSize = new Size(800, 450);
            Controls.Add(picLogo);
            Controls.Add(panelSuperior);
            Controls.Add(btnHistorial);
            Controls.Add(btnDamas);
            Controls.Add(btnSalir);
            Controls.Add(btnTicTacToe);
            Name = "FormMenu";
            Text = "Form1";
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        private void BtnTicTacToe_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button btnTicTacToe;
        private Button btnSalir;
        private Label lblTitulo;
        private Button btnDamas;
        private Button btnHistorial;
        private Panel panelSuperior;
        private PictureBox picLogo;
    }
}
