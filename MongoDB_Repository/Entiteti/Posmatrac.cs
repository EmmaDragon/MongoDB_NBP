using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoNBP.Entiteti;

namespace Podaci
{
    
    public class Posmatrac : Korisnik
    {
        public String DatumRodjenja { get; set; }
        public String Jmbg { get; set; }
        public String Zvanje { get; set; }
        //mozda treba dodati jos neki konstruktor

        public Posmatrac(ObjectId id, String ime, String prezime, String username, String password)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Password = password;
            this._t = "Posmatrac";
        }

        public Posmatrac(String ime, String prezime, String username, String password, MongoDBRef stanica)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Password = password;
            this._t = "Posmatrac";
        }
        public Posmatrac(String ime, String prezime, String username, String password, String zvanje, String JMBG, String DatumRodj)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Password = password;
            this.DatumRodjenja = DatumRodj;
            this.Jmbg = JMBG;
            this.Zvanje = zvanje;
            this._t = "Posmatrac";
        }
        public Posmatrac(ObjectId id, String ime, String prezime, String username, String password, String zvanje, String JMBG, String DatumRodj)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Password = password;
            this.DatumRodjenja = DatumRodj;
            this.Jmbg = JMBG;
            this.Zvanje = zvanje;
            this._t = "Posmatrac";
        }
    }
}
