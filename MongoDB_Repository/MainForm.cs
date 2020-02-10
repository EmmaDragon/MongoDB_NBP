using MongoDB_Repository.Forme.AdminForme;
using MongoDB_Repository.Forme.KorisnikForme;
using MongoDB_Repository.Forme.ZaposleniForme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MongoNBP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form forma = new LogIn_Admin();
            forma.ShowDialog();
        }

        private void btnZaposleni_Click(object sender, EventArgs e)
        {
            Form forma = new LogIn_Zaposleni();
            forma.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form forma = new LogIn_Korisnik();
            forma.ShowDialog();
        }
    }
}
