using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Text;
using System.Windows;
using TrueFriendsApp.Classes;
using TrueFriendsApp.Model;

namespace TrueFriendsApp.DB
{
    class UserRepository : IRepository<User>
    { 
        private DataContext db;
        private static string StringConnection = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
        private static DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        private static DbContextOptions<DataContext> options = optionsBuilder.UseSqlServer(StringConnection).Options;

        public UserRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> Get()
        {
            BindingList<User> users = new BindingList<User>();
            try
            {
                db.User.Load();
                users = db.User.Local.ToBindingList();
                return users;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return users;
            }
        }

        public void Create(User user)
        {
            try
            {
                db.User.Add(user);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.Message);
            }
        }

        public void Update(User user)
        {
            try
            {
                db.User.Update(user);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Delete(User user)
        {
            try
            {
                db.User.Remove(user);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }

}
