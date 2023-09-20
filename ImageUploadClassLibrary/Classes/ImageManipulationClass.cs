using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace ImageUploadClassLibrary.Classes
{
    public class ImageManipulationClass
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ImageManipulationClass()
        {

        }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Method will convert the image to a memory stream for adding to the DB
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public byte[] PhotoProcess(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Method will convert a byte array to an image 
        /// </summary>
        /// <param name="imageData"></param>
        /// <returns></returns>
        public Image PhotoBuilder(byte[] imageData)
        {
            using (var ms = new MemoryStream(imageData))
            {
                return Image.FromStream(ms);
            }
        }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Method returns an image in Bitmap
        /// </summary>
        /// <returns></returns>
        public Bitmap GetPhoto()
        {
            var open = new OpenFileDialog()
            {
                Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png) | *.jpg; *.jpeg; *.gif; *.bmp; *.png; *.jfif"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(open.FileName);
                return image;
            }

            return null;
        }
    }
}