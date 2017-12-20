using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using Domain;

namespace BugTrackingSystem
{
    public class BugTrackingSystem
    {

        public static void InitializeBugTracking(string connectionString, string adminPassword)
        {
            SystemContext s = new SystemContext();
            s.Database.Connection.ConnectionString = connectionString;
            Database.SetInitializer(new DropCreateDatabaseAlways<SystemContext>());
            s.Database.Initialize(true);
            Utente admin = new Utente();
            admin.Login = "Admin";
            admin.Password = adminPassword;
            admin.Date = DateTime.Today;
            s.Utenti.Add(admin);
            s.SaveChanges();
            s.Dispose();
        }

        public static void LoadBugTracking(string connectionString, string adminPassword)
        {
            SystemContext s = new SystemContext();
            s.Database.Connection.ConnectionString = connectionString;
            try
            {
                DbConnection conn = s.Database.Connection;
                conn.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Impossibile connettersi al database. Il programma terminerà.");
                Debug.WriteLine(e.Message);
                s.Dispose();
                throw;
            }
            s.Dispose();
        }
    }
}
