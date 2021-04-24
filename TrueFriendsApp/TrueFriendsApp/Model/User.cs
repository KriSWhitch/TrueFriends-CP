using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrueFriendsApp.Model
{
    public class User
    {
        private int user_id;
        private string user_login;
        private string user_password;
        private bool user_isAdmin;


        [Key]
        public int User_ID // Идентификатор объявления
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public string User_Login // Полное название объявления
        {
            get { return user_login; }
            set { user_login = value; }
        }

        public string User_Password // Краткое название объявления
        {
            get { return user_password; }
            set { user_password = value; }
        }
        public bool User_IsAdmin // Краткое название объявления
        {
            get { return user_isAdmin; }
            set { user_isAdmin = value; }
        }

        public User()
        {

        }

        public User(int id, string login, string password, bool isAdmin)
        {
            User_ID = id;
            User_Login = login;
            User_Password = password;
            User_IsAdmin = isAdmin;
        }

        public User(string login, string password, bool isAdmin)
        {
            User_Login = login;
            User_Password = password;
            User_IsAdmin = isAdmin;
        }

    }
}
