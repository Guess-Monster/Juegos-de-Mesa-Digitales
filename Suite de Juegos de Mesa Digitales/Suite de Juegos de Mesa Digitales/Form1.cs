namespace Suite_de_Juegos_de_Mesa_Digitales
{
    public partial class frm1 : Form
    {
        public frm1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm2 form = new frm2();
            form.ShowDialog();
        }
    }
}
