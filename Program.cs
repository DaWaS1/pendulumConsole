using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pendulumConsole
{
    internal class Program
    {
        public static string conString { get; set; }
        static List<TrackClass> track = new List<TrackClass>();
        static List<AlbumClass> alumb = new List<AlbumClass>();
        static List<string> adatok = new List<string>();



        static void Main(string[] args)
        {
            conString = @"Data Source = (localdb)\ProjectModels;Database = music;";
            Beolvasas();
            Kiszed();
            SQLfeltolt();
            Console.ReadKey();
        }

        private static void SQLfeltolt()
        {
            for (int i = 0; i < alumb.Count; i++)
            {
                using (var c = new SqlConnection(conString))
                {
                    c.Open();
                    var SQLcom = new SqlCommand(
                        $"INSERT INTO Albums (id, artist, title, release) VALUES ('{alumb[i].Azon}', '{alumb[i].Szerzonev}', '{alumb[i].Cim}', '{alumb[i].Megjel}');", c).ExecuteNonQuery();
                }
            }

            for (int i = 0; i < track.Count; i++)
            {
                using (var c = new SqlConnection(conString))
                {
                    c.Open();
                    var SQLcom = new SqlCommand(
                        $"INSERT INTO Tracks (title, length, album, url) VALUES ('{track[i].Cim}', '{track[i].Hossz}', '{track[i].Azon}', '{track[i].Url}');", c).ExecuteNonQuery();
                }
            }
            Console.Clear();
            Console.WriteLine("Sikeresen feltöltöttem az adatokat az adatbázisba!");
        }

        private static void Kiszed()
        {
            int i = 0;
            string sor = "";
            while (!adatok[i].Contains('['))
            {
                Console.WriteLine(adatok[i]);
                sor = adatok[i];
                AlbumClass s = new AlbumClass(sor);
                alumb.Add(s);
                i++;
            }
            Console.WriteLine("********************************************************************");
            i++;
            while (i != adatok.Count)
            {
                Console.WriteLine(adatok[i]);
                sor = adatok[i];
                TrackClass t = new TrackClass(sor);
                track.Add(t);
                i++;
            }
            
        }

        private static void Beolvasas()
        {
            using (var sr = new StreamReader("..\\..\\Res\\pendulum.txt"))
            {
                string sor = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    sor = sr.ReadLine();
                    adatok.Add(sor);
                }
            }
        }
    }
}
