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
        public string Explicacion { get; set; }
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
                Imagen = "Assets\\Samples\\CuadradoAmarillo.jpg",
                Forma="Cuadrado",
                Explicacion = @"Explicación Dron1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                Estado = Paquete.forma.Cuadrado,
                ImagenPeso="Assets\\Samples\\Estrella4.png",
                Color="Azul",
                X = 10,
                Y = 10,
                RX =100,
                RY =30,
             },
            new Paquete()
            {
                Id = 1,
                Nombre = "Paquete Amarillo",
                Imagen = "Assets\\Samples\\CuadradoAmarillo.jpg",
                Forma="Cuadrado",
                Explicacion = @"Explicación Dron2 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                Estado = Paquete.forma.Cuadrado,
                ImagenPeso="Assets\\Samples\\Estrella3.png",
                Color="Amarillo",
                X = 50,
                Y = 50,
                RX =150,
                RY =50,
             },
            new Paquete()
            {
                Id = 2,
                Nombre = "Paquete Verde",
                Imagen = "Assets\\Samples\\CuadradoAmarillo.jpg",
                Forma="Cuadrado",
                Explicacion = @"Explicación Dron3 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                Estado = Paquete.forma.Cuadrado,
                ImagenPeso="Assets\\Samples\\Estrella2.png",
                Color="Verde",
                X = 100,
                Y = 100,
                RX =50,
                RY =130,
             },
            new Paquete()
            {
                Id = 3,
                Nombre = "Paquete Rojo",
                Imagen = "Assets\\Samples\\CuadradoAmarillo.jpg",
                Forma="Cuadrado",
                Explicacion = @"Explicación Dron4 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                Estado = Paquete.forma.Cuadrado,
                ImagenPeso="Assets\\Samples\\Estrella5.png",
                Color="Rojo",
                X = 150,
                Y = 150,
                RX =200,
                RY =80,
             },
            /*new Paquete()
            {
                Id = 4,
                Nombre = "Dron5",
                Imagen = "Assets\\Samples\\CuadradoAmarillo.jpg",
                Explicacion = @"Explicación Dron5 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                Estado = Paquete.estados.Aterrizado,
                X = 200,
                Y = 200,
                RX =100,
                RY =140,
             },
            new Paquete()
            {
                Id = 5,
                Nombre = "Dron6",
                Imagen = "Assets\\Samples\\CuadradoAmarillo.jpg",
                Explicacion = @"Explicación Dron6 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                Estado = Paquete.estados.Aterrizado,
                X = 250,
                Y = 250,
                RX =30,
                RY =50,
             },
            new Paquete()
            {
                Id = 6,
                Nombre = "Dron7",
                Imagen = "Assets\\Samples\\7.jpg",
                Explicacion = @"Explicación Dron7 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                Estado = Paquete.estados.Aterrizado,
                X = 300,
                Y = 300,
                RX =250,
                RY =200,
             },
            new Paquete()
            {
                Id = 7,
                Nombre = "Dron8",
                Imagen = "Assets\\Samples\\8.jpg",
                Explicacion = @"Explicación Dron8 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                Estado = Paquete.estados.Aterrizado,
                X = 350,
                Y = 350,
                RX =140,
                RY =60,
             },
            new Paquete()
            {
                Id = 8,
                Nombre = "Dron9",
                Imagen = "Assets\\Samples\\9.jpg",
                Explicacion = @"Explicación Dron9 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                Estado = Paquete.estados.Aterrizado,
                X = 400,
                Y = 400,
                RX =230,
                RY =120,
             },
            new Paquete()
            {
                Id = 9,
                Nombre = "Dron10",
                Imagen = "Assets\\Samples\\10.jpg",
                Explicacion = @"Explicación Dron10 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                Estado = Paquete.estados.Aterrizado,
                X = 450,
                Y = 400,
                RX =300,
                RY =200,
             },
             new Paquete()
            {
                Id = 10,
                Nombre = "Dron11",
                Imagen = "Assets\\Samples\\11.jpg",
                Explicacion = @"Explicación Dron11 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                Estado = Paquete.estados.Aterrizado,
                X = 500,
                Y = 400,
                RX =100,
                RY =200,
             },
              new Paquete()
            {
                Id = 11,
                Nombre = "Dron12",
                Imagen = "Assets\\Samples\\12.jpg",
                Explicacion = @"Explicación Dron12 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                Estado = Paquete.estados.Aterrizado,
                X = 550,
                Y = 400,
                RX =250,
                RY =320,
             },
               new Paquete()
            {
                Id = 12,
                Nombre = "Dron13",
                Imagen = "Assets\\Samples\\13.jpg",
                Explicacion = @"Explicación Dron3 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat. Maecenas eu sapien ac urna aliquam dictum. Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
                Estado = Paquete.estados.Aterrizado,
                X = 600,
                Y = 400,
                RX =400,
                RY =300,
             }*/

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
