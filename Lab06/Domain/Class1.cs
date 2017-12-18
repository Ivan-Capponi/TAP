using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Utente
    {
        [Key]
        public string Login { get; set; }
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

    public class Prodotto
    {
        [Key]
        public int ProductId { get; set; }
        public string NomeCommerciale { get; set; }
        public string NomeInterno { get; set; }
        public string Descrizione { get; set; }
    }

    public class Commento
    {
        [Key]
        public int MyId { get; set; }
        public Utente Autore { get; set; }
        public DateTime Creazione { get; set; }
        public string Testo { get; set; }
    }
}