using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TrueFriendsApp.Model;

namespace TrueFriendsApp.Classes
{
    interface IRepository
    {
        BindingList<User> GetUsers();
        void AddUser(string login, string password);
        BindingList<Advert> GetAdverts();
        void CreateAdvert(string name, int animalAge, decimal animalWeight, string kindOfAnimal, string description, string pictureString); 
        void EditAdvert(int id, string name, int animalAge, decimal animalWeight, string kindOfAnimal, string description, string pictureString);
        void DeleteAdvert(Advert ad);
        void AddToFavorite(int userID, int advertID);
    }
}
