﻿using System;
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
    
    public class Zaposleni : Korisnik
    {
        public String Jmbg { get; set; }
        public String Zvanje { get; set; }
        public String DatumZaposlenja { get; set; }
        public MongoDBRef VremenskaStanica { get; set; }

        public Zaposleni(ObjectId id, String ime, String prezime, String username, String password, String jmbg, String zvanje, MongoDBRef stanica)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Password = password;
            this.Jmbg = jmbg;
            this.Zvanje = zvanje;
            this.VremenskaStanica = stanica;
            this._t = "Zaposleni";

        }

        public Zaposleni(String ime, String prezime, String username, String password, String jmbg, String zvanje, MongoDBRef stanica)
        {

            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Password = password;
            this.Jmbg = jmbg;
            this.Zvanje = zvanje;
            this.VremenskaStanica = stanica;
            this._t = "Zaposleni";
        }

    }
}
