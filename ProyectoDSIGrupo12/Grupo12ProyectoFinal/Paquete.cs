using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo12ProyectoFinal
{
    public class Paquete
    {
        public enum forma { Cuadrado, Circulo, Triangulo };

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Forma { get; set; }

        public string Imagen { get; set; }
        //public Image Img;
        public string ImagenPeso { get; set; }
        public string Color { get; set; }

        public forma Estado { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int RX;
        public int RY;



        public Paquete() { }
    }
    public class ModelPaquete
    {
        public static List<Paquete> Paquetes = new List<Paquete>()
        {
            new Paquete()
            {
                Id = 0,
                Nombre = "Paquete Azul",
                Imagen = "Assets\\Samples\\PaqueteAzul.png",
                Forma="Cuadrado",
                Estado = Paquete.forma.Cuadrado,
                ImagenPeso="Assets\\Samples\\Estrella4.png",
                Color="Azul",
                X = 800,
                Y = 300,
                RX =100,
                RY =30,
             },
            new Paquete()
            {
                Id = 1,
                Nombre = "Paquete Amarillo",
                Imagen = "Assets\\Samples\\PaqueteAmarillo.png",
                Forma="Cuadrado",
                Estado = Paquete.forma.Cuadrado,
                ImagenPeso="Assets\\Samples\\Estrella3.png",
                Color="Amarillo",
                X = 800,
                Y = 750,
                RX =150,
                RY =50,
             },
            new Paquete()
            {
                Id = 2,
                Nombre = "Paquete Verde",
                Imagen = "Assets\\Samples\\PaqueteVerdel.png",
                Forma="Cuadrado",
                Estado = Paquete.forma.Cuadrado,
                ImagenPeso="Assets\\Samples\\Estrella2.png",
                Color="Verde",
                X = 1200,
                Y = 700,
                RX =50,
                RY =130,
             },
            new Paquete()
            {
                Id = 3,
                Nombre = "Paquete Rojo",
                Imagen = "Assets\\Samples\\PaqueteRojo.png",
                Forma="Cuadrado",
                Estado = Paquete.forma.Cuadrado,
                ImagenPeso="Assets\\Samples\\Estrella5.png",
                Color="Rojo",
                X = 1000,
                Y = 350,
                RX =140,
                RY =60,
             },
          };


        public static IList<Paquete> GetAllPaquetes()
        {
            return Paquetes;
        }

        public static Paquete GetDronById(int id)
        {
            return Paquetes[id];
        }
    }
}
