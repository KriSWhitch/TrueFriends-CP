using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TrueFriendsApp.Model;

namespace TrueFriendsApp.Classes
{
    interface IRepository
    {
        BindingList<User> GetUsers(); // получение всех объектов
        void AddUser(string login, string password); // создание объекта
        BindingList<Advert> GetAdverts();
        void CreateAdvert(string name, int animalAge, decimal animalWeight, string kindOfAnimal, string description, string pictureString); // обновление объекта
        void EditAdvert(int id, string name, int animalAge, decimal animalWeight, string kindOfAnimal, string description, string pictureString); // удаление объекта по id
        void DeleteAdvert(Advert ad);  // сохранение изменений
    }
}
