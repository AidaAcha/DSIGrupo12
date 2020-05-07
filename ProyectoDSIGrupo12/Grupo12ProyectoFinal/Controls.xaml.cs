using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Grupo12ProyectoFinal
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Controls : Page
    {
        SolidColorBrush c1= new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 140, 0)), c2= new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 100, 0));
        public Controls()
        {
            this.InitializeComponent();
            mandoButton.Background = c1;
            tecladoButton.Background = c2;
            volverButton.Background = c1;
        }

        private void Teclado_Click(object sender, RoutedEventArgs e)
        {
            mandoButton.Background = c1;
            tecladoButton.Background = c2;
            imagen.ImageSource = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\" + "T.png"));
        }

        private void volverButton_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();

        }


        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }

        private void Mando_Click(object sender, RoutedEventArgs e)
        {
            tecladoButton.Background = c1;
            mandoButton.Background = c2;
            imagen.ImageSource = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\" + "Mando.png"));
        }
    }
}
