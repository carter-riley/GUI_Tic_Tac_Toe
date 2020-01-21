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
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for regularWindow.xaml
    /// </summary>
    public partial class RegularWindow : Window
    {
        private bool playerTurn = true;
        private bool gameOver = false;
        private TicTacToeBoard gameBoard;
        private int moveCounter = 0;
        private string mode;

        public RegularWindow(string gameMode)
        {
            mode = gameMode;
            InitializeComponent();
            gameBoard = new TicTacToeBoard(3, 0);
            // MessageBox.Show("Player X is going first.");
        }

        //TODO
        //Need to return an array of something
        //Logisitcs - Carter
        //Implement method for Save button
        //  Possibly a Load button as well

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
                mainWindow.title.Foreground = (Brush) Application.Current.Properties["FontColor"];

                this.Close();
            }
        }

        //Method that handles the event of a button click
            //This whole window is a game board and it uses buttons for where players can choose to put either an X or O
            //  The game board is a 3X3 board
            //This method is for the game board
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(gameOver) {
                MessageBox.Show("The game is over.");
                return;
            }
            //Creates a new button
            Button btn = sender as Button;

            Coordinates location = new Coordinates(Grid.GetRow(btn), Grid.GetColumn(btn));
            // if (btn.Content != null)


            if (gameBoard.isValidMove(location, mode))
            {
                moveCounter++;
                // MessageBox.Show("Move counter is: " + moveCounter);
                gameBoard.makeMove(location, playerTurn ? 'X' : 'O', mode);
                btn.Content = playerTurn ? "X" : "O";

                if (gameBoard.isWinner(playerTurn ? 'X' : 'O', mode))
                {
                    MessageBox.Show((playerTurn ? "X" : "O") + " Won!");
                    gameOver = true;
                }
            }
            else
            {
                MessageBox.Show("That is not a valid move!");
                return;
            }
            //MessageBox.Show(location.ToString());

            //If btn already has an X or O in it then it will just return

            //Prints an X or O to the button that is pressed


        
            //TODO
            //Use this to get exact coordinates of users play and return that for logistics
            //This section of code can be used to obtain the coordinates of the where the user has placed an X or O


            //Flips this bool so that it switches between X and O
            playerTurn = !playerTurn;
        }

        //Method that loads the colors for the window
        //Method is called when the window opens
        private void Colors_OnLoaded(object sender, RoutedEventArgs e)
        {
            //Sets the background and foreground color of all buttons using the startup variables
            foreach (Button btn in this.RegularGrid.Children.OfType<Button>())
            {
                btn.Background = (Brush)Application.Current.Properties["Background"];
                btn.Foreground = (Brush) Application.Current.Properties["FontColor"];
            }
            
        }

        //Method that handles the event of a button click 
        //Used for the Rules button
        private void btn_RuleClick(object sender, RoutedEventArgs e)
        {
            //Pops up a message box that displays the rules of the chosen game
            //*********Replace with actual rules
            switch (mode)
            {
                case "Normal Tic-tac-toe":
                    MessageBox.Show("The object of Tic Tac Toe is to get three in a row. You play on a three by three game board. The first player is known as X and the second is O. Players alternate placing Xs and Os on the game board until either opponent has three in a row or all nine squares are filled. X always goes first, and in the event that no one has three in a row, the stalemate is called a cat game");
                    break;
                case "Misere Tic-tac-toe (Avoidance Tic-tac-toe)":
                    MessageBox.Show("The object of Misere Tic-tac-toe (Avoidance Tic-tac-toe) is to avoid getting three in a row. You play on a three by three game board. The first player is known as X and the second is O. Players alternate placing Xs and Os on the game board until either opponent has three in a row or all nine squares are filled. X always goes first, and in the event that no one has three in a row, the stalemate is called a cat game");
                    break;
                case "Nokato Tic-tac-toe":
                    MessageBox.Show("The object of Nokato Tic-tac-toe is to avoid getting three in a row. You play on a three by three game board. Both players are X. Players alternate placing Xs on the game board until one of the players gets three in a row and loses.");
                    break;
                case "Wild Tic-tac-toe (Your Choice Tic-tac-toe)":
                    MessageBox.Show("The object of Wild Tic-tac-toe (Your Choice Tic-tac-toe) is to get three in a row. You play on a three by three game board. Player 1 an player 2 get to choose wether to place an X or an O each turn. Players placing Xs or Os on the game board until either an opponent has three in a row or all nine squares are filled. Player 1 goes first, and in the event that no one has three in a row, the stalemate is called a cat game");
                    break;
                case "Devil's Tic-tac-toe":
                    MessageBox.Show("The object of Devil's Tic-tac-toe is to avoid getting three in a row. You play on a three by three game board. Player 1 an player 2 get to choose wether to place an X or an O each turn. Players placing Xs or Os on the game board until either an opponent has three in a row or all nine squares are filled. Player 1 goes first, and in the event that no one has three in a row, the stalemate is called a cat game");
                    break;
                case "Revenge Tic-tac-toe":
                    MessageBox.Show("The object of Revenge Tic-tac-toe is to get three in a row without your opponent getting three-in-a-row in the next turn. If a player gets three in a row, their opponent has one more turn to try and get three in a row and if they are able to, they win. You play on a three by three game board. The first player is known as X and the second is O. Players alternate placing Xs and Os on the game board until either opponent has three in a row or all nine squares are filled. X always goes first, and in the event that no one has three in a row, the stalemate is called a cat game");
                    break;
                case "Random Tic-tac-toe":
                    MessageBox.Show("The object of Random Tic-tac-toe is to get three in a row. A randon player is chosen to play each turn. You play on a three by three game board. The first player is known as X and the second is O. Players alternate placing Xs and Os on the game board until either opponent has three in a row or all nine squares are filled. In the event that no one has three in a row, the stalemate is called a cat game");
                    break;
                default:
                    MessageBox.Show("No Game mode detected");
                    break;
            }
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