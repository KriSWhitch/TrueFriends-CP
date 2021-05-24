using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Serialization;

namespace TrueFriendsApp
{
    [XmlRoot(ElementName = "picture")]
    public class Picture
    {
        public Picture()
        {

        }
        public Picture (Bitmap source)
        {
            this.Source = source;
        }
        Bitmap source;

        [XmlIgnore]
        public Bitmap Source
        {
            get { return source; }
            set { source = value; }
        }
        
        public string PictureString
        {
            get
            {
                MemoryStream ms = new MemoryStream();
                source.Save(ms, ImageFormat.Jpeg);
                byte[] byteImage = ms.ToArray();
                return Convert.ToBase64String(byteImage);
            }
            set
            {
                Bitmap bmpReturn;
                byte[] byteBuffer = Convert.FromBase64String(value);
                MemoryStream memoryStream = new MemoryStream(byteBuffer);
                memoryStream.Position = 0;
                bmpReturn = (Bitmap)Image.FromStream(memoryStream);
                memoryStream.Close();
                source = bmpReturn;
            }
        }
        [XmlAttribute("source")]
        public byte[] PictureByteArray
        {
            get
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                return (byte[])converter.ConvertTo(source, typeof(byte[]));
            }
            set
            {
                source = new Bitmap(new MemoryStream(value));
            }
        }
    }
}
