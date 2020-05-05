using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.Gaming.Input;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Xaml.Automation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Grupo12ProyectoFinal
{


    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Sel_Dron : Page
    {

        public ObservableCollection<VMPaquete> ListaPaquetes { get; } = new ObservableCollection<VMPaquete>();

        public Sel_Dron()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Carga la lista de ModelView a partir de la lista de Modelo
            if (ListaPaquetes != null)
                foreach (Paquete dron in ModelPaquete.GetAllPaquetes())
                {
                    VMPaquete VMitem = new VMPaquete(dron);
                    ListaPaquetes.Add(VMitem);
                }
            base.OnNavigatedTo(e);
        }
        //solo pone en el mapa el ultimo en haber sido clicado, si tienes todos seleccionados solo pilla el ultimo que hayas pulsado
        private void ImageListView_ItemClickPaquete(object sender, ItemClickEventArgs e)
        {
            VMPaquete d = e.ClickedItem as VMPaquete;
            SelImaPaquete.Source = d.Img.Source;
            //TextInfoPaquete.Text = d.Explicacion;
            ImgFromaPaquete.Source = d.Img.Source;
            TextPaqueteNombre.Text = d.Nombre;
            TextPaqueteForma.Text = d.Forma;
            SelImaPaquete.Source = d.Img.Source;
            Canvas.SetLeft(SelImaPaquete, d.X);
            Canvas.SetTop(SelImaPaquete, d.Y);

        }

        private void ImageListView_ItemClickDron(object sender, ItemClickEventArgs e)
        {
            VMPaquete d = e.ClickedItem as VMPaquete;
            SelImaDron.Source = d.Img.Source;
            TextDronNombre.Text = d.Nombre;
            //TextInfoPaquete.Text = d.Explicacion;
            SelImaDron.Source = d.Img.Source;
            Canvas.SetLeft(SelImaDron, d.X);
            Canvas.SetTop(SelImaDron, d.Y);

        }
        private void Volver_Click(object sender, RoutedEventArgs e)
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

    }
}
