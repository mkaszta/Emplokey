using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplokey_ActivityUpdater
{
    class Program
    {
        public static string connString = "Server = localhost\\sqlexpress; database=Emplokey; Integrated Security = SSPI";
        public static SqlConnection connection = new SqlConnection(connString);
        public static EmplokeyContext db = new EmplokeyContext();        

        static void Main(string[] args)
        {
            connection.Open();

            CheckConfirmations();
            ClearLogs();
            SendRequests();

            connection.Close();
        }

        public static void CheckConfirmations()
        {
            try
            {
                var queryRequests = from r in db.Requests
                                    where r.Confirmed == 0
                                    select r;

                foreach (var item in queryRequests)
                {
                    db.Logs.Where(l => l.ID == item.LogId).First().Time_logout = DateTime.Now;
                }

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        public static void ClearLogs()
        {
            try
            {
                var queryLogs = from l in db.Logs
                                where l.Time_logout == null
                                orderby l.ID_user
                                select l;

                foreach (var user in queryLogs.Select(x => x.ID_user).Distinct())
                {
                    var queryUserLogs = from u in db.Logs
                                        where u.ID_user == user && u.Time_logout == null
                                        orderby u.Time_login ascending
                                        select u;

                    for (int i = 0; i < queryUserLogs.Count()-1; i++)
                    {
                        db.Logs.Remove(queryUserLogs.ToList().ElementAt(i));
                    }                    
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SendRequests()
        {
            try
            {
                var queryLogs = from l in db.Logs
                                where l.Time_logout == null
                                select l;

                foreach (var item in db.Requests.ToList())
                {
                    db.Requests.Remove(item);
                }

                foreach (var item in queryLogs)
                {
                    db.Requests.Add(new Requests
                    {
                        LogId = item.ID
                    });
                }

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }        
    }
}
