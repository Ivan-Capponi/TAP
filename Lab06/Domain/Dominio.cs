﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Domain
{
    [Table("Utenti")]
    public class Utente
    {
        [Key]
        public string Login { get; set; }

        public string Password { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Età { get; set; }
        public DateTime Date { get; set; }
        public string Descrizione { get; set; }
    }

    public enum StatoSegnalazione
    {
        Aperta, PresaInCarico, Risolta
    }
    [Table("Segnalazioni")]
    public class Segnalazione
    {
        [Key]
        public int MyId { get; set; }
        public virtual Prodotto Product { get; set; }
        public IEnumerable <Commento> Commenti { get; set; }
        public virtual Utente Autore { get; set; }
        public StatoSegnalazione Stato { get; set; }
        public DateTime Creazione { get; set; }
        [StringLength(256)]
        public string Descrizione { get; set; }
        public string Testo { get; set; }
    }
    [Table("Prodotti")]
    public class Prodotto
    {
        [Key]
        public int ProductId { get; set; }
        public string NomeCommerciale { get; set; }
        public string NomeInterno { get; set; }
        public string Descrizione { get; set; }
    }
    [Table("Commenti")]
    public class Commento
    {
        [Key]
        public int MyId { get; set; }
        public Utente Autore { get; set; }
        public DateTime Creazione { get; set; }
        public string Testo { get; set; }
    }

    public class SystemContext : DbContext
    {
        public DbSet <Utente> Utenti { get; set; }
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Segnalazione> Segnalazioni { get; set; }
        public DbSet<Commento> Commenti { get; set; }
    }
}