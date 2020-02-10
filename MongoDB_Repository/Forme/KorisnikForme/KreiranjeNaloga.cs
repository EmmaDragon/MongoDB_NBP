using MongoDB_Repository.Entiteti;
using Podaci;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MongoNBP.Entiteti;

namespace MongoDB_Repository.Forme.KorisnikForme
{
    public partial class KreiranjeNaloga : Form
    {
        public KreiranjeNaloga()
        {
            InitializeComponent();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("MongoNBP");

            var collection = db.GetCollection<Korisnik>("korisnici");
            if (Validacija())
            {
                
                    Posmatrac kor;
                    if (txbZvanje.Text != "" && txbJmbg.Text != "" && maskedTextBox1.Text != "")
                        kor = new Posmatrac(txbIme.Text, txbPrezime.Text, txbUsername.Text, txbPassword.Text, txbZvanje.Text, txbJmbg.Text, maskedTextBox1.Text);
                    else if (txbZvanje.Text != "" && txbJmbg.Text != "")
                        kor = new Posmatrac(txbIme.Text, txbPrezime.Text, txbUsername.Text, txbPassword.Text, txbZvanje.Text, txbJmbg.Text, null);
                    else if (txbZvanje.Text != "" && maskedTextBox1.Text != "")
                        kor = new Posmatrac(txbIme.Text, txbPrezime.Text, txbUsername.Text, txbPassword.Text, txbZvanje.Text, null, maskedTextBox1.Text);
                    else if (txbJmbg.Text != "" && maskedTextBox1.Text != "")
                        kor = new Posmatrac(txbIme.Text, txbPrezime.Text, txbUsername.Text, txbPassword.Text, null, txbJmbg.Text, maskedTextBox1.Text);
                    else if (txbZvanje.Text != "")
                        kor = new Posmatrac(txbIme.Text, txbPrezime.Text, txbUsername.Text, txbPassword.Text, txbZvanje.Text, null, null);
                    else if (txbJmbg.Text != "")
                        kor = new Posmatrac(txbIme.Text, txbPrezime.Text, txbUsername.Text, txbPassword.Text, null, txbJmbg.Text, null);
                    else if (maskedTextBox1.Text != "")
                        kor = new Posmatrac(txbIme.Text, txbPrezime.Text, txbUsername.Text, txbPassword.Text, null, null, maskedTextBox1.Text);
                    else
                        kor = new Posmatrac(txbIme.Text, txbPrezime.Text, txbUsername.Text, txbPassword.Text, null, null, null);


                if (ValidacijaUsername(txbUsername.Text,txbJmbg.Text))
                {

                    DialogResult msgResult = MessageBox.Show("Da li ste sigurni da zelite da sacuvate podatke?", "Upit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msgResult == DialogResult.Yes)
                    {
                        collection.Insert(kor);

                        MessageBox.Show("Uspesno ste izvrsili kreiranje naloga!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        return;
                    }
                }

            }

        }
        public bool Validacija()
        {
            bool ind = true;

            if (txbIme.Text == "")
            {
                MessageBox.Show("Niste uneli Ime korisnika", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ind = false;
                return ind;
            }
            if (txbPrezime.Text == "")
            {
                MessageBox.Show("Niste uneli Prezime korisnika", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ind = false;
                return ind;
            }
            if (txbUsername.Text == "")
            {
                MessageBox.Show("Niste uneli Username korisnika", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ind = false;
                return ind;
            }
            if (txbPassword.Text == "")
            {
                MessageBox.Show("Niste uneli Password korisnika", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ind = false;
                return ind;
            }
            return ind;
        }
        public bool ValidacijaUsername(String username,String jmbg)
        {
            bool ind = true;

            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("MongoNBP");
            var collectionKorisnici = db.GetCollection<Korisnik>("korisnici");
            var query = Query.And(Query.EQ("Jmbg", jmbg),
                Query.EQ("_t", "Posmatrac"));
            var result = collectionKorisnici.Find(query);
            if (result.Count<Korisnik>() != 0)
            {
                        MessageBox.Show("Posmatrac sa zadatim jmbg-om vec postoji!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return !ind;
                    
            }
            query = Query.EQ("Username", username);
            result = collectionKorisnici.Find(query);
            if (result.Count<Korisnik>() != 0)
            {
                MessageBox.Show("Username koji zelite da koristite vec postoji! Pokusajte sa drugin username-om.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return !ind;
            }
            else
                return ind;
        }

        private void KreiranjeNaloga_Load(object sender, EventArgs e)
        {

        }
    }

}
