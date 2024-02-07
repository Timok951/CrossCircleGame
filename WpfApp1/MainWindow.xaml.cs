using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Button[] buttons;
        bool circle = true;
        public List<Button> userbuttons=new List<Button>() ;
        List<Button> pcbuttons = new List<Button>();
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[] { B1, B2, B3, B4, B5, B6, B7, B8, B9 };

            foreach (Button i in buttons)
            {
                i.IsEnabled = false;
            }
        }
        void Wincon() {

            if ((buttons[0].Content == "x" && buttons[1].Content == "x" && buttons[2].Content == "x" ) || (buttons[3].Content == "x" && buttons[4].Content == "x" && buttons[5].Content == "x") || (buttons[6].Content == "x" && buttons[7].Content == "x" && buttons[8].Content == "x") || (buttons[0].Content == "x" && buttons[3].Content == "x" && buttons[6].Content == "x") || (buttons[1].Content == "x" && buttons[4].Content == "x" && buttons[7].Content == "x") || (buttons[2].Content == "x" && buttons[5].Content == "x" && buttons[8].Content == "x") || (buttons[0].Content == "x" && buttons[4].Content == "x" && buttons[8].Content == "x") || (buttons[2].Content == "x" && buttons[4].Content == "x" && buttons[6].Content == "x"))
            {
                MessageBox.Show("победили крестики");
                foreach (Button i in buttons)
                {
                    i.IsEnabled = false;

                }
            }

             else if ((buttons[0].Content == "0" && buttons[1].Content == "0" && buttons[2].Content == "0") || (buttons[3].Content == "0" && buttons[4].Content == "0" && buttons[5].Content == "0") || (buttons[6].Content == "0" && buttons[7].Content == "0" && buttons[8].Content == "0") || (buttons[0].Content == "0" && buttons[3].Content == "0" && buttons[6].Content == "0") || (buttons[1].Content == "0" && buttons[4].Content == "0" && buttons[7].Content == "0") || (buttons[2].Content == "0" && buttons[5].Content == "0" && buttons[8].Content == "0") || (buttons[0].Content == "0" && buttons[4].Content == "0" && buttons[8].Content == "0") || (buttons[2].Content == "0" && buttons[4].Content == "0" && buttons[6].Content == "0"))
            {
                MessageBox.Show("победили нолики");
                foreach (Button i in buttons)
                {
                    i.IsEnabled = false;

                }
            }

        }

        void AI() {


            bool isUnique; do
            {
                int rand = random.Next(0, 8); isUnique = true;

            foreach (Button usb in userbuttons)
                {
                    if (buttons[rand].Name == usb.Name)
                    {
                        isUnique = false;
                        break;
                    }
                    if (pcbuttons.Count > 4)
                    {

                        break;
                    }
                }

                if (isUnique)
                {
                    foreach (Button pcb in pcbuttons)
                    {
                        if (buttons[rand].Name == pcb.Name)
                        {
                            isUnique = false;
                            break;
                        }

                        if (pcbuttons.Count == 4) {

                            break;
                        
                        }

            
                    }
                }

                if (isUnique)
                {
                    if (circle == false)
                    {
                        buttons[rand].Content = "0";

                    }

                    else {
                        buttons[rand].Content = "x";


                    }
                    pcbuttons.Add(buttons[rand]);
                    buttons[rand].IsEnabled = false;
                }



            } while (!isUnique);


        }


        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Father_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (circle == false)
            {
                clickedButton.Content = "x";
            } 
            
            else
            {
                clickedButton.Content = "0";
            }
           
            clickedButton.IsEnabled = false;
            string buttonName = clickedButton.Name;

            
            userbuttons.Add(clickedButton);
            AI();
            Wincon();



        }

        private void Gamestart_Click(object sender, RoutedEventArgs e)
        {
            
            userbuttons.Clear();
            pcbuttons.Clear();
            foreach (Button i in buttons) { 
                i.IsEnabled = true;
                i.Content = "";
            }

            if (circle == true)
            {
                circle = false;
            }

            else { 
                circle = true;
            
            }
        }
    }
}
