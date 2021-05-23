using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TrueFriendsApp.Model;

namespace TrueFriendsApp.Classes
{
    interface IRepository<T> where T : class
    {
        void Create(T obj);
        IEnumerable<T> Get();
        void Update(T obj);
        void Delete(T obj);
    }
}
