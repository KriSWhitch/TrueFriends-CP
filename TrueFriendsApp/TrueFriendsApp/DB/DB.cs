using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace TrueFriendsApp.DB
{
    class DB
    {
        private static string StringConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static SqlConnection GetDBConnection()
        {
            SqlConnection cn_connection = new SqlConnection(StringConnection);

            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            return cn_connection;
        }

        public static DataTable GetDataTable(string query)
        {
            SqlConnection cn_connection = GetDBConnection();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, cn_connection);
            adapter.Fill(table);

            return table;
        }

        public static void ExecuteSQL(string query)
        {
            SqlConnection cn_connection = GetDBConnection();

            SqlCommand cmd_Command = new SqlCommand(query, cn_connection);
            cmd_Command.ExecuteNonQuery();
        }

        public static void CloseDBConnection()
        {
            SqlConnection cn_connection = new SqlConnection(StringConnection);
            if (cn_connection.State != ConnectionState.Closed) cn_connection.Close();
        }

        public static string Hash(string input)
        {
            byte[] hash = Encoding.ASCII.GetBytes(input);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string output = "";
            foreach (var b in hashenc)
            {
                output += b.ToString("x2");
            }
            return output;
        }
    }
}
