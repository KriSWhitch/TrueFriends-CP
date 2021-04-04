using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace TrueFriendsApp
{
    //root name is called "picture"
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

        // Set serialization to IGNORE this property
        // because the 'PictureByteArray' property
        // is used instead to serialize
        // the 'Picture' Bitmap as an array of bytes.
        [XmlIgnore]
        public Bitmap Source
        {
            get { return source; }
            set { source = value; }
        }
        // Set PictureByteArray Property 
        // to be an attribute of the Picture node 
        [XmlAttribute("source")]
        public byte[] PictureByteArray
        {
            get
            {
                //get a TypeConverter object for converting Bitmap to bytes
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
