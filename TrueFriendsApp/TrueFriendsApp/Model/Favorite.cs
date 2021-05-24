using System.ComponentModel.DataAnnotations;

namespace TrueFriendsApp.Model
{
    class Favorite
    {
        private int favorite_ID;
        private int favorite_user_ID;
        private int favorite_advert_ID;


        [Key]
        public int Favorite_ID // идентификатор избранного
        {
            get { return favorite_ID; }
            set { favorite_ID = value; }
        }

        public int Favorite_User_ID // пользователь, который добавил объявление в избранное
        {
            get { return favorite_user_ID; }
            set { favorite_user_ID = value; }
        }

        public int Favorite_Advert_ID // объявление занесенное пользователем в избранное
        {
            get { return favorite_advert_ID; }
            set { favorite_advert_ID = value; }
        }

        public Favorite()
        {

        }

        public Favorite(int id, int userID, int advertID)
        {
            Favorite_ID = id;
            Favorite_User_ID = userID;
            Favorite_Advert_ID = advertID;
        }

        public Favorite(int userID, int advertID)
        {
            Favorite_User_ID = userID;
            Favorite_Advert_ID = advertID;
        }

    }
}
