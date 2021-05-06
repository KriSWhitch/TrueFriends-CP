using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TrueFriendsApp.Model;

namespace TrueFriendsApp.Classes
{
    static class UnitOfWork
    {
        private static SQLRemoteServer db = new SQLRemoteServer();

        public static BindingList<User> GetUsers()
        {
            return db.GetUsers();
        }

        public static void AddUser(string login, string password)
        {
            db.AddUser(login, password);
        }

        public static void CreateAdvert(string name, int animalAge, decimal animalWeight, string kindOfAnimal, string description, string pictureString)
        {

            db.CreateAdvert(name, animalAge, animalWeight, kindOfAnimal, description, pictureString);
        }

        public static void EditAdvert(int id, string name, int animalAge, decimal animalWeight, string kindOfAnimal, string description, string pictureString)
        {
            db.EditAdvert(id, name, animalAge, animalWeight, kindOfAnimal, description, pictureString);
        }

        public static void DeleteAdvert(Advert ad)
        {
            db.DeleteAdvert(ad);
        }

        public static BindingList<Advert> GetAdverts()
        {
            return db.GetAdverts();
        }
    }
}
