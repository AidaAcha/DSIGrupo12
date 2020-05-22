using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Grupo12ProyectoFinal
{
    public class VMDron : Dron
    {
        public Image Img;
        public Image ImgPeso;
        public Image ImgVel;
        public Image ImgBateria;
        public ContentControl CCImg;
        public int Zoom;
        public RotateTransform Rotacion;
        public int Angulo;
        public VMDron(Dron dron)
            {
            Id = dron.Id;
            Nombre = dron.Nombre;
            Imagen = dron.Imagen;
            
            Explicacion = dron.Explicacion;
            Estado = dron.Estado;
            X = dron.X;
            Y = dron.Y;
            RX = dron.RX;
            RY = dron.RY;
            //Creo la Rotación
            Angulo = 0;
            Rotacion = new RotateTransform();
            Rotacion.Angle = Angulo;
            Rotacion.CenterX = 25;
            Rotacion.CenterY = 25;
            //Creo la imagen
            Img = new Image();
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + dron.Imagen;
            Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
            Img.Width = 50;
            Img.Height = 50;

            ImgPeso = new Image();
            string s1 = System.IO.Directory.GetCurrentDirectory() + "\\" + dron.ImagenPeso;
            ImgPeso.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s1));
            ImgPeso.Width = 50;
            ImgPeso.Height = 50;

            ImgVel = new Image();
            string s2 = System.IO.Directory.GetCurrentDirectory() + "\\" + dron.ImagenVelocidad;
            ImgVel.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s2));
            ImgVel.Width = 50;
            ImgVel.Height = 50;

            ImgBateria = new Image();
            string s3 = System.IO.Directory.GetCurrentDirectory() + "\\" + dron.ImagenBateria;
            ImgBateria.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s3));
            ImgBateria.Width = 50;
            ImgBateria.Height = 50;

            //Creo el ContentControl
            CCImg = new ContentControl();
            CCImg.RenderTransform = Rotacion;
            CCImg.Content = Img;
            CCImg.UseSystemFocusVisuals = true;
            CCImg.Visibility = Windows.UI.Xaml.Visibility.Visible;//.Collapsed;
            //Mapa.Children.Add(CCImg);
            //Mapa.Children.Last().SetValue(Canvas.LeftProperty, X - 25);
            //Mapa.Children.Last().SetValue(Canvas.TopProperty, Y - 25);
        }
    }


    public class VMPaquete : Paquete
    {
        public Image Img;
        public Image ImgPeso;
        public ContentControl CCImg;
        public int Zoom;
        public RotateTransform Rotacion;
        public int Angulo;
        public VMPaquete(Paquete paquete)
        {
            Id = paquete.Id;
            Nombre = paquete.Nombre;
            Imagen = paquete.Imagen;
            Explicacion = paquete.Explicacion;
            Estado = paquete.Estado;
            Forma = paquete.Forma;
            X = paquete.X;
            Y = paquete.Y;
            RX = paquete.RX;
            RY = paquete.RY;
            //Creo la Rotación
            Angulo = 0;
            Rotacion = new RotateTransform();
            Rotacion.Angle = Angulo;
            Rotacion.CenterX = 25;
            Rotacion.CenterY = 25;
            //Creo la imagen
            Img = new Image();
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + paquete.Imagen;
            Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
            Img.Width = 50;
            Img.Height = 50;

            ImgPeso = new Image();
            string s1 = System.IO.Directory.GetCurrentDirectory() + "\\" + paquete.ImagenPeso;
            ImgPeso.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s1));
            //ImgPeso.Width = 50;
            //ImgPeso.Height = 50;


            //Creo el ContentControl
            CCImg = new ContentControl();
            CCImg.RenderTransform = Rotacion;
            CCImg.Content = Img;
            CCImg.UseSystemFocusVisuals = true;
            CCImg.Visibility = Windows.UI.Xaml.Visibility.Visible;//.Collapsed;
            //Mapa.Children.Add(CCImg);
            //Mapa.Children.Last().SetValue(Canvas.LeftProperty, X - 25);
            //Mapa.Children.Last().SetValue(Canvas.TopProperty, Y - 25);
        }
    }

    public class VMWrapper
    {
        public VMDron Dron;
        public VMPaquete Paquete;
        public int [] destinos;
        public int Time;
        public int Objectives;
        public int TotalObjectives;
        public double x_, y_;

        public VMWrapper(Dron d, Paquete p, int t, int obj, int totalObj, double x, double y)
        {
            Dron = new VMDron(d);
            Paquete = new VMPaquete(p);
            Time = t;
            Objectives = obj;
            TotalObjectives = totalObj;
            x_ = x;
            y_ = y;
            destinos = new int[totalObj];
        }
    }
}
