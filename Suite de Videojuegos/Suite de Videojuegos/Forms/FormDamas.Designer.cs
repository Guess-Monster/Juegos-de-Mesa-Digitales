namespace Suite_de_Videojuegos.Forms
{
    partial class FormDamas
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
            tablero = new TableLayoutPanel();
            lblTurno = new Label();
            lblResultado = new Label();
            btnReiniciar = new Button();
            lstHistorial = new ListBox();
            SuspendLayout();
            // 
            // tablero
            // 
            tablero.ColumnCount = 8;
            tablero.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tablero.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tablero.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tablero.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tablero.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tablero.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tablero.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tablero.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tablero.Location = new Point(12, 12);
            tablero.Name = "tablero";
            tablero.RowCount = 8;
            tablero.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tablero.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tablero.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tablero.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tablero.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tablero.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tablero.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tablero.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tablero.Size = new Size(640, 640);
            tablero.TabIndex = 0;
            // 
            // lblTurno
            // 
            lblTurno.AutoSize = true;
            lblTurno.Location = new Point(702, 64);
            lblTurno.Name = "lblTurno";
            lblTurno.Size = new Size(45, 15);
            lblTurno.TabIndex = 1;
            lblTurno.Text = "Turno: ";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(702, 122);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(59, 15);
            lblResultado.TabIndex = 2;
            lblResultado.Text = "Resultado";
            // 
            // btnReiniciar
            // 
            btnReiniciar.Location = new Point(689, 188);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(75, 23);
            btnReiniciar.TabIndex = 3;
            btnReiniciar.Text = "Reiniciar";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += btnReiniciar_Click_1;
            // 
            // lstHistorial
            // 
            lstHistorial.FormattingEnabled = true;
            lstHistorial.ItemHeight = 15;
            lstHistorial.Location = new Point(714, 267);
            lstHistorial.Name = "lstHistorial";
            lstHistorial.Size = new Size(250, 499);
            lstHistorial.TabIndex = 4;
            // 
            // FormDamas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 711);
            Controls.Add(lstHistorial);
            Controls.Add(btnReiniciar);
            Controls.Add(lblResultado);
            Controls.Add(lblTurno);
            Controls.Add(tablero);
            Name = "FormDamas";
            Text = "FormDamas";
            Load += FormDamas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tablero;
        private Label lblTurno;
        private Label lblResultado;
        private Button btnReiniciar;
        private ListBox lstHistorial;
    }
}