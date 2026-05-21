
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
            btnTicTacToe = new Button();
            btnSalir = new Button();
            lblTitulo = new Label();
            btnDamas = new Button();
            btnBD = new Button();
            btnHistorial = new Button();
            SuspendLayout();
            // 
            // btnTicTacToe
            // 
            btnTicTacToe.Location = new Point(535, 133);
            btnTicTacToe.Name = "btnTicTacToe";
            btnTicTacToe.Size = new Size(89, 23);
            btnTicTacToe.TabIndex = 0;
            btnTicTacToe.Text = "Tic-Tac-Toe";
            btnTicTacToe.UseVisualStyleBackColor = true;
            btnTicTacToe.Click += btnTicTacToe_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(535, 238);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(89, 23);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(215, 42);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(208, 30);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Suite de Videojuegos";
            // 
            // btnDamas
            // 
            btnDamas.Location = new Point(535, 166);
            btnDamas.Name = "btnDamas";
            btnDamas.Size = new Size(86, 23);
            btnDamas.TabIndex = 3;
            btnDamas.Text = "Damas";
            btnDamas.UseVisualStyleBackColor = true;
            btnDamas.Click += btnDamas_Click;
            // 
            // btnBD
            // 
            btnBD.Location = new Point(549, 293);
            btnBD.Name = "btnBD";
            btnBD.Size = new Size(75, 23);
            btnBD.TabIndex = 4;
            btnBD.Text = "BD";
            btnBD.UseVisualStyleBackColor = true;
            btnBD.Click += btnBD_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.Location = new Point(535, 203);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(86, 23);
            btnHistorial.TabIndex = 5;
            btnHistorial.Text = "Historial";
            btnHistorial.UseVisualStyleBackColor = true;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnHistorial);
            Controls.Add(btnBD);
            Controls.Add(btnDamas);
            Controls.Add(lblTitulo);
            Controls.Add(btnSalir);
            Controls.Add(btnTicTacToe);
            Name = "FormMenu";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
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
        private Button btnBD;
        private Button btnHistorial;
    }
}
