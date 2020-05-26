using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo12ProyectoFinal
{
    public class Dron
    {
        public enum estados { Aterrizado, Autonomo, Manual };

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string ImagenPeso { get; set; }
        public string ImagenBateria { get; set; }
        public string ImagenVelocidad { get; set; }

        //public Image Img;
        public estados Estado { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int RX;
        public int RY;



        public Dron() { }
    }
    public class Model
    {
        public static List<Dron> Drones = new List<Dron>()
        {                       
            new Dron()
            {
                Id = 0,
                Nombre = "Dron1",
                Imagen = "Assets\\Samples\\Dron_1.png",
                Estado = Dron.estados.Aterrizado,
                ImagenPeso="Assets\\Samples\\Estrella1.png",
                ImagenBateria="Assets\\Samples\\Estrella3.png",
                ImagenVelocidad="Assets\\Samples\\Estrella5.png",
                X = 200,
                Y = 200,
                RX =100,
                RY =30,
             },
            new Dron()
            {
                Id = 1,
                Nombre = "Dron2",
                Imagen = "Assets\\Samples\\Dron_2.png",
                Estado = Dron.estados.Aterrizado,
                ImagenPeso="Assets\\Samples\\Estrella3.png",
                ImagenBateria="Assets\\Samples\\Estrella4.png",
                ImagenVelocidad="Assets\\Samples\\Estrella3.png",
                X = 200,
                Y = 200,
                RX =150,
                RY =50,
             },
            new Dron()
            {
                Id = 2,
                Nombre = "Dron3",
                Imagen = "Assets\\Samples\\Dron_3.png",
                ImagenPeso="Assets\\Samples\\Estrella5.png",
                ImagenBateria="Assets\\Samples\\Estrella4.png",
                ImagenVelocidad="Assets\\Samples\\Estrella2.png",
                Estado = Dron.estados.Aterrizado,
                X = 200,
                Y = 200,
                RX =50,
                RY =130,
             },
            new Dron()
            {
                Id = 3,
                Nombre = "Dron4",
                Imagen = "Assets\\Samples\\Dron_4.png",
                ImagenPeso="Assets\\Samples\\Estrella3.png",
                ImagenBateria="Assets\\Samples\\Estrella2.png",
                ImagenVelocidad="Assets\\Samples\\Estrella5.png",
                Estado = Dron.estados.Aterrizado,
                X = 200,
                Y = 200,
                RX =200,
                RY =80,
             },
          };

      
        public static IList<Dron> GetAllDrones()
        {
            return Drones;
        }

        public static Dron GetDronById(int id)
        {
            return Drones[id];
        }
    }
}
