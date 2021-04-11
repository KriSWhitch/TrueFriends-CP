using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace TrueFriendsApp
{
    public static class DB
    {
        private static string StringConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static SqlConnection cn_connection = new SqlConnection(StringConnection);

        public static SqlConnection GetDBConnection()
        {
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

        public static void CreateAdvert(string fullName, string shortName, int animalAge, decimal animalWeight, string kindOfAnimal, string description, byte[] pictureByteArray)
        {
            
            cn_connection = GetDBConnection();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cn_connection;
                command.CommandText = @"INSERT INTO Advert ([Advert_FullName], [Advert_ShortName], [Advert_AnimalAge], [Advert_AnimalWeight], [Advert_KindOfAnimal], [Advert_Description], [Advert_Image], [Advert_CreationDate]) 
                                        VALUES (@Advert_FullName,@Advert_ShortName,@Advert_AnimalAge, @Advert_AnimalWeight, @Advert_KindOfAnimal, @Advert_Description, @Advert_Image, GETDATE())";

                command.Parameters.Add("@Advert_FullName", SqlDbType.VarChar, 40);
                command.Parameters.Add("@Advert_ShortName", SqlDbType.VarChar, 20);
                command.Parameters.Add("@Advert_AnimalAge", SqlDbType.Int);
                command.Parameters.Add("@Advert_AnimalWeight", SqlDbType.Float);
                command.Parameters.Add("@Advert_KindOfAnimal", SqlDbType.VarChar, 20);
                command.Parameters.Add("@Advert_Description", SqlDbType.VarChar, 2000);
                command.Parameters.Add("@Advert_Image", SqlDbType.VarBinary);

                command.Parameters["@Advert_FullName"].Value = fullName;
                command.Parameters["@Advert_ShortName"].Value = shortName;
                command.Parameters["@Advert_AnimalAge"].Value = animalAge;
                command.Parameters["@Advert_AnimalWeight"].Value = animalWeight;
                command.Parameters["@Advert_KindOfAnimal"].Value = kindOfAnimal;
                command.Parameters["@Advert_Description"].Value = description;
                command.Parameters["@Advert_Image"].Value = pictureByteArray;

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void EditAdvert(int id, string fullName, string shortName, int animalAge, decimal animalWeight, string kindOfAnimal, string description, byte[] pictureByteArray)
        {
            cn_connection = GetDBConnection();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cn_connection;
                command.CommandText = @"UPDATE Advert SET Advert_FullName = @Advert_FullName, Advert_ShortName = @Advert_ShortName, 
                                        Advert_AnimalAge = @Advert_AnimalAge, Advert_AnimalWeight = @Advert_AnimalWeight, Advert_KindOfAnimal = @Advert_KindOfAnimal, 
                                        Advert_Description = @Advert_Description, Advert_Image = @Advert_Image WHERE Advert_ID = @Advert_ID";

                command.Parameters.Add("@Advert_ID", SqlDbType.Int);
                command.Parameters.Add("@Advert_FullName", SqlDbType.VarChar, 40);
                command.Parameters.Add("@Advert_ShortName", SqlDbType.VarChar, 20);
                command.Parameters.Add("@Advert_AnimalAge", SqlDbType.Int);
                command.Parameters.Add("@Advert_AnimalWeight", SqlDbType.Float);
                command.Parameters.Add("@Advert_KindOfAnimal", SqlDbType.VarChar, 20);
                command.Parameters.Add("@Advert_Description", SqlDbType.VarChar, 2000);
                command.Parameters.Add("@Advert_Image", SqlDbType.VarBinary);

                command.Parameters["@Advert_ID"].Value = id;
                command.Parameters["@Advert_FullName"].Value = fullName;
                command.Parameters["@Advert_ShortName"].Value = shortName;
                command.Parameters["@Advert_AnimalAge"].Value = animalAge;
                command.Parameters["@Advert_AnimalWeight"].Value = animalWeight;
                command.Parameters["@Advert_KindOfAnimal"].Value = kindOfAnimal;
                command.Parameters["@Advert_Description"].Value = description;
                command.Parameters["@Advert_Image"].Value = pictureByteArray;

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void DeleteAdvert(int id)
        {
            cn_connection = GetDBConnection();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cn_connection;
                command.CommandText = @"DELETE Advert WHERE Advert_ID = @Advert_ID";
                command.Parameters.Add("@Advert_ID", SqlDbType.Int);
                command.Parameters["@Advert_ID"].Value = id;

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static List<Advert> GetAdverts()
        {
            List<Advert> adverts = new List<Advert>();
            cn_connection = GetDBConnection();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = cn_connection;
                command.CommandText = @"Select Advert_ID, Advert_FullName, Advert_ShortName, Advert_AnimalAge, Advert_AnimalWeight, Advert_KindOfAnimal, Advert_Description, Advert_Image, Advert_Creator, Advert_CreationDate From Advert";


                SqlDataReader info = command.ExecuteReader();
                object advertCreator = null, id = null, fullName = null, shortName = null, animalAge = null, animalWeight = null, kindOfAnimal = null, description = null, image = null, creationDate = null;

                while (info.Read())
                {
                    id = info["Advert_ID"];
                    fullName = info["Advert_FullName"];
                    shortName = info["Advert_ShortName"];
                    animalAge = info["Advert_AnimalAge"];
                    animalWeight = info["Advert_AnimalWeight"];
                    kindOfAnimal = info["Advert_KindOfAnimal"];
                    image = info["Advert_Image"];
                    description = info["Advert_Description"];
                    advertCreator = info["Advert_Creator"];
                    creationDate = info["Advert_CreationDate"];
                    adverts.Add(
                        new Advert()
                        {
                            ID = Convert.ToInt32(id),
                            FullName = Convert.ToString(fullName),
                            ShortName = Convert.ToString(shortName),
                            AnimalAge = Convert.ToInt32(animalAge),
                            AnimalWeight = Convert.ToDecimal(animalWeight),
                            KindOfAnimal = Convert.ToString(kindOfAnimal),
                            Image = new Picture() { PictureByteArray = (byte[])image },
                            Description = Convert.ToString(description),
                            AdvertCreator = Convert.ToString(advertCreator),
                            CreationDate = Convert.ToString(creationDate)
                        }
                    );
                }
                return adverts;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return adverts;
            }
        }

    }
}
