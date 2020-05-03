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
        
        public MainPage()
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
                    /*int indexRemoved = myGamepads.IndexOf(e);
                    if (indexRemoved > -1)
                    {
                        if (mainGamepad == myGamepads[indexRemoved])
                        {
                            mainGamepad = null;
                        }
                        myGamepads.RemoveAt(indexRemoved);
                    }*/
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
            /*// Initialize the dictionary.
            pointers = new Dictionary<uint, Windows.UI.Xaml.Input.Pointer>();
            // Declare the pointer event handlers.
            Target.PointerPressed +=
            new PointerEventHandler(Target_PointerPressed);
            Target.PointerEntered +=
            new PointerEventHandler(Target_PointerEntered);
            Target.PointerReleased +=
            new PointerEventHandler(Target_PointerReleased);
            Target.PointerExited +=
            new PointerEventHandler(Target_PointerExited);
            Target.PointerCanceled +=
            new PointerEventHandler(Target_PointerCanceled);
            Target.PointerCaptureLost +=
            new PointerEventHandler(Target_PointerCaptureLost);
            Target.PointerMoved +=
            new PointerEventHandler(Target_PointerMoved);
            Target.PointerWheelChanged +=
            new PointerEventHandler(Target_PointerWheelChanged);
            buttonClear.Click +=
            new RoutedEventHandler(ButtonClear_Click);*/
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Cosntruye las listas de ModelView a partir de la lista Modelo 
            if (ListaDrones != null)
                foreach (Dron dron in Model.GetAllDrones())
                {
                    VMDron VMitem = new VMDron(dron);
                    ListaDrones.Add(VMitem);
                    VMitem.CCImg.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    MiCanvas.Children.Add(VMitem.CCImg);
                    MiCanvas.Children.Last().SetValue(Canvas.LeftProperty, VMitem.X - 25);
                    MiCanvas.Children.Last().SetValue(Canvas.TopProperty, VMitem.Y - 25);
                }
            base.OnNavigatedTo(e);
            GameTimerSetup();
        }

        public void GameTimerSetup()
        {
            GameTimer = new DispatcherTimer();
            GameTimer.Tick += GameTimer_Tick; //dispatcherTimer_Tick
            GameTimer.Interval = new TimeSpan(10000);
            GameTimer.Start();
        }

        void GameTimer_Tick(object sender, object e)
        {//Los Drones se simulan a nivel de aplicación cada 0.1s
            LeeMando();    //Lee GamePad
            //DetecteGestosMando(); //Detecta gestos del mando
            if (ZMMando())              //ZonaMuerte JoyStick
                AplMando();             //Aplica acciones del mando
            MuestraInfo();         //Actualiza Información

        }

        private void LeeMando()
        {
            if(myGamepads.Count != 0)
            {
                mainGamepad = myGamepads[0];
                prereading = reading;
                reading = mainGamepad.GetCurrentReading();
                //Muestra en IU
                GamePadLog.Text = "Botones: " + reading.Buttons.ToString() + "\n"
                    + "\t RJoy: " + reading.RightThumbstickX.ToString()
                    + " , " + reading.RightThumbstickX.ToString(); // + "\n";
            }
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

        private void AplMando()
        {
            if(mainGamepad != null)
            {
                //Object cc= FocusManager.GetFocusedElement();
                foreach (ContentControl cc in MiCanvas.Children)
                {
                    if(cc.FocusState != FocusState.Unfocused)
                    {
                        int SI = MiCanvas.Children.IndexOf(cc);
                        if (SI >= 0)
                        {
                            ListaDrones[SI].X = (int)(ListaDrones[SI].X + 10 * reading.RightThumbstickX);
                            ListaDrones[SI].Y = (int)(ListaDrones[SI].Y - 10 * reading.RightThumbstickY);
                            MiCanvas.Children[SI].SetValue(Canvas.LeftProperty, ListaDrones[SI].X - 25);
                            MiCanvas.Children[SI].SetValue(Canvas.TopProperty, ListaDrones[SI].Y - 25);
                        }
                    }

                }
            }
        }

        private void MuestraInfo()
        {
            if(SelMos >= 0)
            {
                VMDron Sel = ListaDrones[SelMos];
                SelDatos.Text = "Id: ," + Sel.Id + ", Nombre:" + Sel.Nombre + ", Estado: " + Sel.Estado.ToString()
                    + "\n, REF: " + Sel.RX.ToString() + "," + Sel.RY.ToString() + " POS: " + Sel.X.ToString();
                SelExp.Text = "Explicación: " + Sel.Explicacion;
                SelIma.Source = Sel.Img.Source;
            }
        }
        
        private void ImageGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

            VMDron Sel = e.ClickedItem as VMDron;
            SelMos = Sel.Id;
            MuestraInfo();

            /*VMDron Item = e.ClickedItem as VMDron;
            Imagen.Source = Item.Img.Source;
            Texto.Text = Item.Explicacion;
            Canvas.SetLeft(ImagenC, Item.X);
            Canvas.SetTop(ImagenC, Item.Y);
            ImagenC.Source = Item.Img.Source;*/
        }

        private void Button_ClearSelection(object sender, RoutedEventArgs e)
        {
            itemListView.SelectedIndex = -1;
            SelMos = -1;
            SelInd = -1;
            MuestraInfo();
        }

        private void Button_SelectAll (object sender, RoutedEventArgs e)
        {
            itemListView.SelectAll();
            SelMos = 0;
            MuestraInfo();
        }

        private void itemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (VMDron item in e.AddedItems)
            {
                item.CCImg.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            foreach (VMDron item in e.RemovedItems)
            {
                item.CCImg.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void Mapa_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            cursorBeforePointerEntered = Window.Current.CoreWindow.PointerCursor;
            ptrPtAnt = e.GetCurrentPoint(SelIma);

            if (ptrPtAnt.Properties.IsRightButtonPressed==true)
            {
                RotBotDer = true;
                Window.Current.CoreWindow.PointerCursor = CursorHand;
            }
            else
            {
                RotBotDer = false;
                Window.Current.CoreWindow.PointerCursor = CursorPin;
            }
            Image Fuente = e.OriginalSource as Image;
            ContentControl cc = Fuente.Parent as ContentControl;
            if (Fuente != null)
            {
                SelInd = MiCanvas.Children.IndexOf(cc);
                SelMos = SelInd;
                MuestraInfo();
            }
        }

        private void Mapa_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint ptrPt = e.GetCurrentPoint(MiCanvas);

            if (SelInd >= 0)
            {
                if (RotBotDer == true)
                {
                    ListaDrones[SelInd].Angulo = (int)ptrPt.Position.X - (int)ptrPtAnt.Position.X;
                    ListaDrones[SelInd].Rotacion.Angle = ListaDrones[SelInd].Angulo;
                }
                else
                {
                    ListaDrones[SelInd].X = (int)ptrPt.Position.X;
                    ListaDrones[SelInd].Y = (int)ptrPt.Position.Y;
                    MiCanvas.Children[SelInd].SetValue(Canvas.LeftProperty, ListaDrones[SelInd].X - 25);
                    MiCanvas.Children[SelInd].SetValue(Canvas.TopProperty, ListaDrones[SelInd].Y - 25);
                    MuestraInfo();
                }

            }
        }

        private void Mapa_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            SelInd = -1;
            Window.Current.CoreWindow.PointerCursor = cursorBeforePointerEntered;
        }

        private void MiCanvas_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            int FocInd = -1;
            ContentControl cc = e.OriginalSource as ContentControl;
            if (e.OriginalSource.GetType() == cc.GetType())
                FocInd = MiCanvas.Children.IndexOf(cc);

            if (FocInd >= 0)
            {
                int X = (int)ListaDrones[FocInd].X;
                int Y = (int)ListaDrones[FocInd].Y;
                int Angulo = (int)ListaDrones[FocInd].Angulo;

                switch (e.Key)
                {
                    case VirtualKey.A:
                    case VirtualKey.GamepadRightThumbstickLeft:
                        X = X - 10;
                        break;

                    case VirtualKey.D:
                    case VirtualKey.GamepadRightThumbstickRight:
                        X = X + 10;
                        break;

                    case VirtualKey.W:
                    case VirtualKey.GamepadRightThumbstickUp:
                        Y = Y - 10;
                        break;

                    case VirtualKey.S:
                    case VirtualKey.GamepadRightThumbstickDown:
                        Y = Y + 10;
                        break;

                    case VirtualKey.Q:
                    case VirtualKey.GamepadX:
                        Angulo = Angulo - 1;
                        break;

                    case VirtualKey.E:
                    case VirtualKey.GamepadY:
                        Angulo = Angulo + 1;
                        break;
                    case VirtualKey.Escape:
                    case VirtualKey.GamepadMenu:
                        GoPause();
                        break;
                }

                ListaDrones[FocInd].X = X;
                ListaDrones[FocInd].Y = Y;
                ListaDrones[FocInd].Angulo = Angulo;
                MiCanvas.Children[FocInd].SetValue(Canvas.LeftProperty, X - 25);
                MiCanvas.Children[FocInd].SetValue(Canvas.TopProperty, Y - 25);
                ListaDrones[FocInd].Rotacion.Angle = Angulo;
            }
        }

        private void GoPause()
        {
            this.Frame.Navigate(typeof(Pausa));
        }
    }
}
