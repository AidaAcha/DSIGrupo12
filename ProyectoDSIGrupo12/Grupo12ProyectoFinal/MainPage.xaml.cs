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


// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Grupo12ProyectoFinal
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            ElementSoundPlayer.State = ElementSoundPlayerState.On;
            this.InitializeComponent();
        }

        private void Iniciar_Click(object sender, RoutedEventArgs e)
        {
           // NavInfoText.Text = "Vuelvo al juego";
            //Va al juego cuando esté completa la pagina
            this.Frame.Navigate(typeof(Sel_Dron));
            ElementSoundPlayer.Play(ElementSoundKind.Invoke);
        }

        private void Opciones_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Options));
            ElementSoundPlayer.Play(ElementSoundKind.Invoke);
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
           
            ElementSoundPlayer.Play(ElementSoundKind.Invoke);
            Application.Current.Exit();
        }
    }
}
