using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for CustomWindow1.xaml
    /// </summary>
    public partial class CustomWindow : Window
    {
        public CustomWindow()
        {
            InitializeComponent();
        }

        //Method that fills the combobox with elements
        //This is called when window loads
        private void regularComboBox(object sender, RoutedEventArgs e)
        {
            //List which has elements that we want in the combo box
            List<string> data = new List<string>();
            data.Add("File");
            data.Add("Save");
            data.Add("Quit");

            //Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            //Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            //Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        //Method that handles the event of a selection changed within the combo box
        //Another window should open when a selection is picked
        private void regularComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get the ComboBox.
            var comboBox = sender as ComboBox;

            // Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;

            if (value == "File")
            {
                return;
            }
            else if (value == "Save")
            {
                //TODO
                //Implement save method using a text file
                //
            }
            else if (value == "Quit")
            {
                MainWindow mainWindow = new MainWindow();

                mainWindow.Show();

                //Sets background and foreground color
                mainWindow.mainGrid.Background = (Brush)Application.Current.Properties["Background"];
                mainWindow.title.Foreground = (Brush)Application.Current.Properties["FontColor"];

                this.Close();
            }
        }

        //Method that loads the colors for the window
        //Method is called when the window opens
        private void Colors_OnLoaded(object sender, RoutedEventArgs e)
        {
            //Sets the background and foreground color of all buttons using the startup variables
            foreach (Button btn in this.myGrid.Children.OfType<Button>())
            {
                btn.Background = (Brush)Application.Current.Properties["Background"];
                btn.Foreground = (Brush)Application.Current.Properties["FontColor"];
            }

        }

        //Method that handles the event of a button click 
        //Used for the Rules button
        private void btn_RuleClick(object sender, RoutedEventArgs e)
        {
            //Pops up a message box that displays the rules of the chosen game
            //*********Replace with actual rules
            MessageBox.Show("The object of Tic Tac Toe is to get three in a row. You play on a three by three game board. The first player is known as X and the second is O. Players alternate placing Xs and Os on the game board until either oppent has three in a row or all nine squares are filled. X always goes first, and in the event that no one has three in a row, the stalemate is called a cat game");
        }

        //Method that handles the event of a button click
        //Used for the settings button
        private void btn_SettingClick(object sender, RoutedEventArgs e)
        {
            //Creates a new window
            SettingWindow settingWindow = new SettingWindow();

            //Shows new window
            settingWindow.Show();

            Application.Current.Properties["WindowIndex"] = this.Name;

            //Closes this window
            this.Close();

        }
    }
}

