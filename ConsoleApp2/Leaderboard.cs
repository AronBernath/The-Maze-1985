using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Leaderboard
    {
        public string[,] top5;

        public void Connection(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = (LocalDB)/MSSQLLocalDB; AttachDbFilename = D:/Dokumentumok/Feleves_szar/ConsoleApp2/Database1.mdf; Integrated Security = True");
            con.ConnectionString = "Data Source = (LocalDB)/MSSQLLocalDB; AttachDbFilename = D:/Dokumentumok/Feleves_szar/ConsoleApp2/Database1.mdf; Integrated Security = True";
        }

    }
}
