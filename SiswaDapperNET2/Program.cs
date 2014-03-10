using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;

using Dapper;
namespace SiswaDapperNET2
{
    class Program
    {

        private static OleDbConnection GetOpenConnection()
        {                        
            OleDbConnection conn = null;

            try
            {
                var appDir = System.IO.Directory.GetCurrentDirectory();
                var strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appDir + "\\SISWA.MDB;User Id=admin;Password=;";

                conn = new OleDbConnection(strConn);
                conn.Open();
            }
            catch (Exception)
            {
            }

            return conn;
        }

        static void Main(string[] args)
        {
            var daftarSiswa = new List<Siswa>();
            using (var conn = GetOpenConnection())
            {
                var strSql = "SELECT nis, nama FROM siswa";
                daftarSiswa = conn.Query<Siswa>(strSql, null).ToList();
            }

            Console.WriteLine("NIS\tNAMA");
            Console.WriteLine("===================================");
            foreach (var siswa in daftarSiswa)
            {
                Console.WriteLine(siswa.Nis + "\t" + siswa.Nama);
            }
            Console.ReadKey();
        }
    }
}
