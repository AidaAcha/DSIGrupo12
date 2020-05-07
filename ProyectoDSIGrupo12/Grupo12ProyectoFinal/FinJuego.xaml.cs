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
    public sealed partial class FinJuego : Page
    { 
        //Para manejar los mandos
        private readonly object myLock = new object();
        private List<Gamepad> myGamepads = new List<Gamepad>();
        private Gamepad mainGamepad = null;
        bool savedRecord = false;
        //private GamepadReading reading, prereading;

        //Manejar el Timer
        //Timer de la Vista y Controlador
        DispatcherTimer GameTimer;
        
        public FinJuego()
        {
            this.InitializeComponent();
            Gamepad.GamepadAdded += (object sender, Gamepad e) =>
            {
                lock (myLock)
                {
                    bool gamepadInList = myGamepads.Contains(e);
                    if (!gamepadInList)
                    {
                        myGamepads.Add(e);
                    }
                }
            };

            Gamepad.GamepadRemoved += (object sender, Gamepad e) =>
             {
                 lock (myLock)
                 {
                     int indexRemoved = myGamepads.IndexOf(e);
                     if (indexRemoved > -1)
                     {
                         if (mainGamepad == myGamepads[indexRemoved])
                         {
                             mainGamepad = null;
                         }
                         myGamepads.RemoveAt(indexRemoved);
                     }
                 }
             };
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            GameTimerSetup();
        }

        public void GameTimerSetup()
        {
            GameTimer = new DispatcherTimer();
            //GameTimer.Tick += GameTimer_Tick; //dispatcherTimer_Tick
            GameTimer.Interval = new TimeSpan(10000);
            GameTimer.Start();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HUD));  //HUD
        }

        private void VolverButton_Click(object sender, RoutedEventArgs e)
        {
            /*ir al menu principal, ahora pausa para probar*/
            this.Frame.Navigate(typeof(MainPage));

        }

        private void NewNameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!savedRecord)
            {
                SavedRecord_Image.Visibility = Visibility.Visible;
                savedRecord = true;
                /* cambiar el nuevo record en el modelo de datos*/
            }
        }
    }
}
