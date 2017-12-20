using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Domain;

namespace BugTrackingSystem
{
    public class BugTrackingSystem
    {
        private static SystemContext _context;
        public static void AddNewUser(String username, String adminPassword)
        {
            Utente utente = new Utente();
            utente.Login = username;
            utente.Password = adminPassword;
            utente.Date = DateTime.Today;
            _context.Utenti.Add(utente);
            _context.SaveChanges();
            _context.Dispose();
        }
        public static void InitializeBugTracking(string connectionString, string adminPassword)
        {
            _context = new SystemContext();
            _context.Database.Connection.ConnectionString = connectionString;
            try
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<SystemContext>());
                _context.Database.Initialize(true);
            }
            catch (SqlException e)
            {
                Console.WriteLine("La base di dati è attualmente occupata. Il programma terminerà");
                Debug.WriteLine(e.Message);
                _context.Dispose();
                throw;
            }
            
            AddNewUser("admin", adminPassword);
        }

        public static void LoadBugTracking(string connectionString, string adminPassword)
        {
            _context = new SystemContext();
            _context.Database.Connection.ConnectionString = connectionString;
            try
            {
                DbConnection conn = _context.Database.Connection;
                conn.Open();
                List <string> login = (from utenti in _context.Utenti where utenti.Password == adminPassword select utenti.Nome).ToList();
                if (login.Count == 1)
                    Console.WriteLine("Login eseguito correttamente");
                else
                {
                    Console.WriteLine("Login fallito");
                }
             }
            catch (SqlException e)
            {
                Console.WriteLine("Impossibile connettersi al database. Il programma terminerà.");
                Debug.WriteLine(e.Message);
                _context.Dispose();
                throw;
            }
            _context.Dispose();
        }
    }
}
