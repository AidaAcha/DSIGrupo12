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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.System.Profile;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Input;
using Windows.System;
using System.Timers;
using Windows.UI;


// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Grupo12ProyectoFinal
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class HUD : Page
    {
        public const int TIME_LIMIT = 60; 
        public int time_;
        public int health_decrease = 5;
        public int totalObjectivos = 4;
        public int objetivos = 0;
        public VMPaquete paqueteSelec;
        public VMWrapper mWrapper_;
        public ObservableCollection<VMDron> ListaDrones { get; } = new ObservableCollection<VMDron>();
        public ObservableCollection<VMPaquete> ListaDestinos { get; } = new ObservableCollection<VMPaquete>();
        //private Timer timer;
        bool dangerLife = false;

        DispatcherTimer dispatcherTimer;

        public HUD()
        {
            this.InitializeComponent();
            //SetTimer();
            DispatcherTimerSetup();
        }

        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            VMWrapper mWrapper = e.Parameter as VMWrapper;
            mWrapper_ = mWrapper;
            mWrapper_.Time = time_;
            mWrapper_.Objectives = 0;
            mWrapper_.TotalObjectives = totalObjectivos;
            if (mWrapper != null)
            { 
                //dronImagen.Source = mWrapper.Dron.Img.Source;
                paqueteSel.Source = mWrapper.Paquete.Img.Source;
            }

            VMDron VMItem = new VMDron(mWrapper.Dron);
          //  VMPaquete VMDest = new VMPaquete(mWrapper.Paquete);
            ListaDrones.Add(VMItem);
            paqueteSelec = mWrapper.Paquete;
            canvas.Children.Add(VMItem.CCImg);
            //canvas.Children.Add(VMDest.CCImg);
            canvas.Children.Last().SetValue(Canvas.LeftProperty, VMItem.X );
            canvas.Children.Last().SetValue(Canvas.TopProperty, VMItem.Y );
           // canvas.Children.Last().SetValue(Canvas.LeftProperty, VMDest.X -100);
           // canvas.Children.Last().SetValue(Canvas.TopProperty, VMDest.Y -100);

            if (ListaDestinos != null)
                foreach (Paquete paquete in ModelPaquete.GetAllPaquetes())
                {
                    VMPaquete VMDestino = new VMPaquete(paquete);
                    ListaDestinos.Add(VMDestino);
                    VMDestino.CCImg.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    canvas.Children.Add(VMDestino.CCImg);
                    canvas.Children.Last().SetValue(Canvas.LeftProperty, VMDestino.X - 25);
                    canvas.Children.Last().SetValue(Canvas.TopProperty, VMDestino.Y - 25);
                }
            dispatcherTimer.Start();

            /*
             * ListaDrones.Add(mWrapper.Dron);
            canvas.Children.Add(mWrapper.Dron.CCImg);
            canvas.Children.Last().SetValue(Canvas.LeftProperty, mWrapper.Dron.X - 25);
            canvas.Children.Last().SetValue(Canvas.TopProperty, mWrapper.Dron.Y - 25);
             */
            base.OnNavigatedFrom(e);
        }
        private void sliderAlt_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void CanvasKeyDown(object sender, KeyRoutedEventArgs e)
        {
            int ind = -1;
            ContentControl cC = e.OriginalSource as ContentControl;
            if (cC.GetType() == e.OriginalSource.GetType())
            {
                ind = canvas.Children.IndexOf(cC);
            }
            if (ind > -1)
            {

                switch (e.Key)
                {
                    case VirtualKey.GamepadRightThumbstickLeft:
                    case VirtualKey.A:
                        ListaDrones[0].X -= 10;
                        break;
                    case VirtualKey.GamepadRightThumbstickUp:
                    case VirtualKey.W:
                        ListaDrones[0].Y -= 10;
                        break;
                    case VirtualKey.GamepadRightThumbstickDown:
                    case VirtualKey.S:
                        ListaDrones[0].Y += 10;
                        break;
                    case VirtualKey.GamepadRightThumbstickRight:
                    case VirtualKey.D:
                        ListaDrones[0].X += 10;
                        break;
                    case VirtualKey.GamepadMenu:
                    case VirtualKey.Escape:
                        {
                            mWrapper_.x_ = ListaDrones[0].X;
                            mWrapper_.y_ = ListaDrones[0].Y;
                            dispatcherTimer.Stop();
                            this.Frame.Navigate(typeof(Pausa), mWrapper_);
                        }
                        break;
                    case VirtualKey.P:
                        {
                            if (dispatcherTimer.IsEnabled)
                                dispatcherTimer.Stop();
                            else
                                dispatcherTimer.Start();
                        } 
                        break;
                    case VirtualKey.Up:
                       // ListaDrones[0].CCImg.Scale += ;
                        break;
                    
                }
                //limites
                if (ListaDrones[0].X < 0) ListaDrones[0].X = 0;
                else if (ListaDrones[0].X > 1400) ListaDrones[0].X = 1400;
                if (ListaDrones[0].Y < 0) ListaDrones[0].Y = 0;
                else if (ListaDrones[0].Y > 950) ListaDrones[0].Y = 950;
                canvas.Children[2].SetValue(Canvas.LeftProperty, ListaDrones[0].X);
                canvas.Children[2].SetValue(Canvas.TopProperty, ListaDrones[0].Y);
                
                if (ListaDrones[0].Y >230 && ListaDrones[0].Y < 400 && ListaDrones[0].X >0 && ListaDrones[0].X < 250)
                {
                    dispatcherTimer.Stop();
                    this.Frame.Navigate(typeof(Sel_Dron));
                }
                //desaparecer drones
                else
                {
                    int i = paqueteSelec.Id;
                    //int n = canvas.Children.F(ListaDrones[0].CCImg);
                    if (ListaDestinos != null /*&& ListaDestinos[i] == paqueteSelec*/)
                     {

                        if (ListaDrones[0].X > ListaDestinos[i].X - 50 && ListaDrones[0].X < ListaDestinos[i].X + 50 &&
                            ListaDrones[0].Y < ListaDestinos[i].Y + 50 && ListaDrones[0].Y > ListaDestinos[i].Y - 50)
                        {
                            // bool a = ListaDestinos.Remove(paqueteSelec);
                            UIElement u = ListaDestinos[i].CCImg;
                           if(canvas.Children.Remove(u))
                                mWrapper_.Objectives++;
                            paqueteSel.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                           //canvas.Children.RemoveAt(i + 1);
                        }
                    }
                    
                }
            }
        }

        //private void SetTimer()
        //{
        //    time = TIME_LIMIT;
        //    // Create a timer with a one second interval.
        //    timer = new Timer(1000);
        //    // Hook up the Elapsed event for the timer. 
        //    timer.Elapsed += EverySecondEvent;
        //    timer.AutoReset = true;
        //    timer.Enabled = true;
        //}

        //private void EverySecondEvent(object sender, ElapsedEventArgs e)
        //{
        //    //(time--).ToString();
        //    //if(time == 0)   //fin del juego
        //    //{
        //        timer.Stop();
        //        this.Frame.Navigate(typeof(FinJuego));
        //    //}
        //    //label1.Text = (int.Parse(label1.Text) - 1).ToString(); //lowering the value - explained above
        //    //if (int.Parse(label1.Text) == 0)  //if the countdown reaches '0', we stop it
        //    //    timer1.Stop();
        //}

        public void DispatcherTimerSetup()
        {
            time_ = TIME_LIMIT;
            numTiempo.Text = (time_).ToString();

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);   //1second interval

        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            numTiempo.Text = (--time_).ToString();
            VidaRect.Width = Math.Max(0, VidaRect.Width - health_decrease);
            mWrapper_.Time = time_;
            //vida_ = vida_;
            //Thickness preu = vida.Margin;
            //vida.Margin =new Thickness(vida.Margin.Left + 10, vida.Margin.Top, vida.Margin.Right, vida.Margin.Bottom);
            //vida.Margin.Right;
            //Bajamos la vida de forma artificial
            if(time_ == 0 || VidaRect.Width == 0)
            {
                dispatcherTimer.Stop();
                this.Frame.Navigate(typeof(FinJuego), mWrapper_);
            }
            else if(!dangerLife && VidaRect.Width < 50)
            {
                SolidColorBrush colorB = new SolidColorBrush();
                colorB.Color = Color.FromArgb(255, 255, 0, 0);
                VidaRect.Fill = colorB;
                dangerLife = true;
            }
        }
    }
}
