using InfoSec.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoSec.UI
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
            //dataGridView1.AutoGenerateColumns = false;
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            using(var db = new InfoSecDbContext())
            {
                dataGridView1.DataSource = db.Activities.Select(x => x.Title).ToList();
            }
        }
    }
}
