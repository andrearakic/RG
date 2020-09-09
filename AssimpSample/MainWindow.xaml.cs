using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using SharpGL.SceneGraph;
using SharpGL;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Input;
using SharpGL.SceneGraph;
using System.Runtime.InteropServices;


namespace AssimpSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Atributi
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        private const int BORDER = 700;

        /// <summary>
        ///  Instanca OpenGL "sveta" - klase koja je zaduzena za iscrtavanje koriscenjem OpenGL-a.
        /// </summary>
        World m_world = null;

        /// <summary>
        ///  Pamti staru poziciju kursora da bi mogli da racunamo pomeraj.
        /// </summary>
        private Point oldPos;

        

        #endregion Atributi

        #region Konstruktori

        public MainWindow()
        {
            // Inicijalizacija komponenti
            InitializeComponent();

            // Kreiranje OpenGL sveta
            try
            {
                //m_world = new World(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "3D Models\\Balon"), "Heart.dae", (int)openGLControl.Width, (int)openGLControl.Height, openGLControl.OpenGL);
                m_world = new World(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "3D Models\\Balloon"), "Air_Balloon.3ds", (int)openGLControl.Width, (int)openGLControl.Height, openGLControl.OpenGL);

            }
            catch (Exception e)
            {
                MessageBox.Show("Neuspesno kreirana instanca OpenGL sveta. Poruka greške: " + e.Message, "Poruka", MessageBoxButton.OK);
                this.Close();
            }
        }

        #endregion Konstruktori

        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="SharpGL.SceneGraph.OpenGLEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLDraw(object sender, OpenGLEventArgs args)
        {
            m_world.Draw(args.OpenGL);
        }

        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="SharpGL.SceneGraph.OpenGLEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            m_world.Initialize(args.OpenGL);
        }

        /// <summary>
        /// Handles the Resized event of the openGLControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="SharpGL.SceneGraph.OpenGLEventArgs"/> instance containing the event data.</param>
        private void openGLControl_Resized(object sender, OpenGLEventArgs args)
        {
            m_world.Resize(args.OpenGL, (int)openGLControl.Width, (int)openGLControl.Height);
        }
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F10: this.Close(); break;
                case Key.W: m_world.RotationX -= 5.0f; break;
                case Key.S: m_world.RotationX += 5.0f; break;
                case Key.A: m_world.RotationY -= 5.0f; break;
                case Key.D: m_world.RotationY += 5.0f; break;
                case Key.X: stopInerface(false); m_world.startAnimation(); break;//ONEMOGUCI INTERFEJS, STARTUJ ANIMACIJU
                case Key.Add: m_world.SceneDistance -= 300.0f; break;
                case Key.Subtract: m_world.SceneDistance += 300.0f; break;
                case Key.F2: this.Close(); break;
                case Key.T:
                    if (m_world.RotationX < 90.0f)
                    {
                        m_world.RotationX += 5f;
                    }
                    break;
                case Key.G:
                    if (m_world.RotationX > 0.0f)
                    {
                        m_world.RotationX -= 5f;
                    }
                    break;
                case Key.F: m_world.RotationY -= 5.0f; break;
                case Key.H: m_world.RotationY += 5.0f; break;

                case Key.F4:
                    OpenFileDialog opfModel = new OpenFileDialog();
                    bool result = (bool) opfModel.ShowDialog();
                    if (result)
                    {

                        try
                        {
                            World newWorld = new World(Directory.GetParent(opfModel.FileName).ToString(), Path.GetFileName(opfModel.FileName), (int)openGLControl.Width, (int)openGLControl.Height, openGLControl.OpenGL);
                            m_world.Dispose();
                            m_world = newWorld;
                            m_world.Initialize(openGLControl.OpenGL);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("Neuspesno kreirana instanca OpenGL sveta:\n" + exp.Message, "GRESKA", MessageBoxButton.OK );
                        }
                    }
                    break;
            }
        }

        //OMOGUCAVANJE INTERFEJSA
        public void stopInerface(bool boolean)
        {
            sliderBlue.IsEnabled = boolean;
            sliderRed.IsEnabled = boolean;
            sliderGreen.IsEnabled = boolean;
            sliderDoor.IsEnabled = boolean;
            sliderHangar.IsEnabled = boolean;
        }

        //PROMENE SLAJDERA
        private void SliderDoor(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_world != null)
                m_world.doorSpeed = (float)e.NewValue;
        }

        private void SliderHangar(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_world != null)
                m_world.hangarHeight = (float)e.NewValue;
        }
        
        private void SliderRed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_world != null)
                m_world.red = (float)e.NewValue;
        }

        private void SliderGreen(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_world != null)
                m_world.green = (float)e.NewValue;
        }

        private void SliderBlue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (m_world != null)
                m_world.blue = (float)e.NewValue;
        }
    }
}
