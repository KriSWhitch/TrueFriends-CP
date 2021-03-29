using System.Collections.Generic;
using System.Windows.Media;

namespace TrueFriendsApp
{
    // Данный класс используется для отображения объявлений в приложении
    public class AdvertInGrid
    {
        public int ID { get; set; } // Идентификатор объявления
        public string FullName { get; set; } // Полное название товара
        public string ShortName { get; set; } // Краткое название товара
        public string Category { get; set; }  // Категория товара
        public double Raiting { get; set; }  // Рейтинг товара
        public decimal Cost { get; set; }  // Цена товара
        public int Amount { get; set; }  // Количество товара на складе
        public ImageSource AdvertImage { get; set; }  // Картинка для отображения в списке
        public List<Picture> Images {get; set; } // Список картинок прикрепленных к объявлению
    }
}
