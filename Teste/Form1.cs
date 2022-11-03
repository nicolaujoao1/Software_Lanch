using Software_Lanch.Context;

namespace Teste
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext _context;
        public Form1()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var listData = _context.Categorias.ToArray();
            dataGridView1.DataSource= listData;
        }
    }
}