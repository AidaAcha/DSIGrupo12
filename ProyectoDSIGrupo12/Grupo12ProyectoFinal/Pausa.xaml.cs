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
    public sealed partial class Pausa : Page
    {

        public ObservableCollection<VMDron> ListaDrones { get; } = new ObservableCollection<VMDron>();
       
        //Dictionary<uint, Windows.UI.Xaml.Input.Pointer> pointers;

        //Para mostrar información
        private int SelMos = -1;
        //Para mostrar con Ratón
        private int SelInd = -1;
        //Click con botón Derecho
        private bool RotBotDer = false;
        //Puntero anterior
        PointerPoint ptrPtAnt;
        CoreCursor CursorHand = null;
        CoreCursor CursorPin = null;
        CoreCursor cursorBeforePointerEntered = null;

        //Para manejar los mandos
        private readonly object myLock = new object();
        private List<Gamepad> myGamepads = new List<Gamepad>();
        private Gamepad mainGamepad = null;
        private GamepadReading reading, prereading;

        //Manejar el Timer
        //Timer de la Vista y Controlador
        DispatcherTimer GameTimer;
        
        public Pausa()
        {
            this.InitializeComponent();
            CursorHand = new CoreCursor(CoreCursorType.Hand, 0);
            CursorPin = new CoreCursor(CoreCursorType.Pin, 0);
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
            NavInfoText.Text = "Estoy en Pausa";
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


        private bool ZMMando()
        {
            bool cambio = false;
            if (reading.RightThumbstickX < -0.1)
            {
                reading.RightThumbstickX += 0.1;
                cambio = true;
            }
            else if (reading.RightThumbstickX > 0.1)
            {
                reading.RightThumbstickX -= 0.1;
                cambio = true;
            }
            else
                reading.RightThumbstickX = 0;

            if (reading.RightThumbstickY < -0.1)
            {
                reading.RightThumbstickY += 0.1;
            }
            else if (reading.RightThumbstickY > 0.1)
            {
                reading.RightThumbstickY -= 0.1;
                cambio = true;
            }
            else
                reading.RightThumbstickY = 0;
            return cambio;
        }

        private void Opciones_Click(object sender, RoutedEventArgs e)
        {
            NavInfoText.Text = "Voy a opciones";
        }
        private void Renaudar_Click(object sender, RoutedEventArgs e)
        {
            NavInfoText.Text = "Vuelvo al juego";
            this.Frame.Navigate(typeof(MainPage));
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            NavInfoText.Text = "Voy al menu principal";
        }

    }
}
