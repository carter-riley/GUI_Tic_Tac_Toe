﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Method that fills the combobox with elements
        //This is called when window loads
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            //List which has elements that we want in the combo box
            List<string> data = new List<string>();
            data.Add("Play");
            data.Add("Normal Tic-tac-toe");
            data.Add("Misere Tic-tac-toe (Avoidance Tic-tac-toe)");
            data.Add("Nokato Tic-tac-toe");
            data.Add("Wild Tic-tac-toe (Your Choice Tic-tac-toe)");
            data.Add("Devil's Tic-tac-toe");
            data.Add("Revenge Tic-tac-toe");
            data.Add("Random Tic-tac-toe");
            data.Add("Ultimate Tic-tac-toe");
            data.Add("Custom Board");
            

            //Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            //Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            //Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        //Method that handles the event of a selection changed within the combo box
        //Another window should open when a selection is picked
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get the ComboBox.
            var comboBox = sender as ComboBox;

            // Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;

            if (value == "Play")
            {
                //We don't want the program to do anything if play is selected so it returns here
                return;
            }
            else if(value == "Normal Tic-tac-toe" || 
                    value == "Misere Tic-tac-toe (Avoidance Tic-tac-toe)" ||
                    value =="Misere Tic-tac-toe (Avoidance Tic-tac-toe)" ||
                    value == "Nokato Tic-tac-toe" ||
                    value == "Wild Tic-tac-toe (Your Choice Tic-tac-toe)" ||
                    value == "Devil's Tic-tac-toe" ||
                    value == "Revenge Tic-tac-toe" ||
                    value =="Random Tic-tac-toe")
            {
                //Creates the new Window
                RegularWindow regularWindow = new RegularWindow(value);

                //Closes initial window
                this.Close();

                //These startup variables should be colors
                //Assigns these variables so the next window that is open can use them to have the same colors
                Application.Current.Properties["Background"] = mainGrid.Background;
                Application.Current.Properties["FontColor"] = title.Foreground;

                //Show next window
                regularWindow.Show();
            }
            else if(value == "Ultimate Tic-tac-toe")
            {
                UltimateWindow ultimateWindow = new UltimateWindow(value);

                this.Close();

                //These startup variables should be colors
                //Assigns these variables so the next window that is open can use them to have the same colors
                Application.Current.Properties["Background"] = mainGrid.Background;
                Application.Current.Properties["FontColor"] = title.Foreground;

                //Show next window
                ultimateWindow.Show();
            }
            else if (value == "Custom Board")
            {
                CustomChoiceWindow customChoiceWindow = new CustomChoiceWindow();
                
                this.Close();

                //These startup variables should be colors
                //Assigns these variables so the next window that is open can use them to have the same colors
                Application.Current.Properties["Background"] = mainGrid.Background;
                Application.Current.Properties["FontColor"] = title.Foreground;

                customChoiceWindow.Show();
            }
        }

        //Method for the event of a button click
        //For the setting button
        //This method also opens another window
        private void btn_SettingClick(object sender, RoutedEventArgs e)
        {
            //Creates a new setting window
            SettingWindow settingWindow = new SettingWindow();

            //Sets this variable so it can be used for conditionals later
            Application.Current.Properties["WindowIndex"] = this.Name;

            //Show setting window
            settingWindow.Show();

            //Closes initial window
            this.Close();

        }
    }
}