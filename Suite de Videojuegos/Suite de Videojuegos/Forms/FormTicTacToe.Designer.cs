namespace Suite_de_Videojuegos.Forms
{
    partial class FormTicTacToe
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
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            lblTurno = new Label();
            lblResultado = new Label();
            btnReiniciar = new Button();
            SuspendLayout();
            // 
            // btn1
            // 
            btn1.Location = new Point(56, 36);
            btn1.Name = "btn1";
            btn1.Size = new Size(100, 100);
            btn1.TabIndex = 0;
            btn1.UseVisualStyleBackColor = true;
            // 
            // btn2
            // 
            btn2.Location = new Point(181, 36);
            btn2.Name = "btn2";
            btn2.Size = new Size(100, 100);
            btn2.TabIndex = 1;
            btn2.UseVisualStyleBackColor = true;
            // 
            // btn3
            // 
            btn3.Location = new Point(307, 36);
            btn3.Name = "btn3";
            btn3.Size = new Size(100, 100);
            btn3.TabIndex = 2;
            btn3.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            btn4.Location = new Point(56, 168);
            btn4.Name = "btn4";
            btn4.Size = new Size(100, 100);
            btn4.TabIndex = 3;
            btn4.UseVisualStyleBackColor = true;
            // 
            // btn5
            // 
            btn5.Location = new Point(181, 168);
            btn5.Name = "btn5";
            btn5.Size = new Size(100, 100);
            btn5.TabIndex = 4;
            btn5.UseVisualStyleBackColor = true;
            // 
            // btn6
            // 
            btn6.Location = new Point(307, 168);
            btn6.Name = "btn6";
            btn6.Size = new Size(100, 100);
            btn6.TabIndex = 5;
            btn6.UseVisualStyleBackColor = true;
            // 
            // btn7
            // 
            btn7.Location = new Point(56, 300);
            btn7.Name = "btn7";
            btn7.Size = new Size(100, 100);
            btn7.TabIndex = 6;
            btn7.UseVisualStyleBackColor = true;
            // 
            // btn8
            // 
            btn8.Location = new Point(181, 300);
            btn8.Name = "btn8";
            btn8.Size = new Size(100, 100);
            btn8.TabIndex = 7;
            btn8.UseVisualStyleBackColor = true;
            // 
            // btn9
            // 
            btn9.Location = new Point(307, 300);
            btn9.Name = "btn9";
            btn9.Size = new Size(100, 100);
            btn9.TabIndex = 8;
            btn9.UseVisualStyleBackColor = true;
            // 
            // lblTurno
            // 
            lblTurno.AutoSize = true;
            lblTurno.Location = new Point(527, 51);
            lblTurno.Name = "lblTurno";
            lblTurno.Size = new Size(52, 15);
            lblTurno.TabIndex = 9;
            lblTurno.Text = "Turno: X";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(527, 88);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(38, 15);
            lblResultado.TabIndex = 10;
            lblResultado.Text = "label2";
            // 
            // btnReiniciar
            // 
            btnReiniciar.Location = new Point(527, 145);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(75, 23);
            btnReiniciar.TabIndex = 11;
            btnReiniciar.Text = "Reiniciar";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += btnReiniciar_Click_1;
            // 
            // FormTicTacToe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReiniciar);
            Controls.Add(lblResultado);
            Controls.Add(lblTurno);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Name = "FormTicTacToe";
            Text = "Form1";
            Load += FormTicTacToe_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Label lblTurno;
        private Label lblResultado;
        private Button btnReiniciar;
    }
}