﻿using System;
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

        //Para manejar los mandos
        private readonly object myLock = new object();
        private List<Gamepad> myGamepads = new List<Gamepad>();
        private Gamepad mainGamepad = null;
        //private GamepadReading reading, prereading;

        //Manejar el Timer
        //Timer de la Vista y Controlador
        DispatcherTimer GameTimer;
        
        public Pausa()
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


        private void Opciones_Click(object sender, RoutedEventArgs e)
        {
            NavInfoText.Text = "Voy a opciones";
            //Va a opciones cuando esté completa la pagina
        }
        private void Renaudar_Click(object sender, RoutedEventArgs e)
        {
            NavInfoText.Text = "Vuelvo al juego";
            //Va al juego cuando esté completa la pagina
            this.Frame.Navigate(typeof(MainPage));
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            NavInfoText.Text = "Voy al menu principal";
            //Va al menú cuando esté completa la pagina, ahora va a fin del juego para probar
            this.Frame.Navigate(typeof(FinJuego));

        }

    }
}
