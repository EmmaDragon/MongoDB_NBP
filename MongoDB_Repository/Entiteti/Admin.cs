using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoNBP.Entiteti;

namespace MongoDB_Repository.Entiteti
{
  
    public class Admin : Korisnik
    {
        public String Okrug { get; set; }

        public Admin(String ime, String prezime, String username, String password, String okrug)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Password = password;
            this.Okrug = okrug;
        }

        public Admin(ObjectId id, String ime, String prezime, String username, String password, String okrug)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Password = password;
            this.Okrug = okrug;
        }
    }
}
