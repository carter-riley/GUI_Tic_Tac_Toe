using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    public partial class ThreeDWindow : Window
    {
        private bool playerTurn = true;
        private bool gameOver = false;
        private TicTacToeBoard gameBoard;
        private int moveCounter = 0;
        private string mode;

        public ThreeDWindow(string gameMode)
        {
            mode = gameMode;
            InitializeComponent();
            gameBoard = new TicTacToeBoard(true);
            gameBoard.gameMode = 8;
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
                BinaryFormatter binFormat = new BinaryFormatter();
                using (Stream fStream =
                    new FileStream(DateTime.Now.ToFileTime() + ".dat", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, gameBoard);
                }
            }
            else if (value == "Quit")
            {
                MainWindow mainWindow = new MainWindow();

                mainWindow.Show();

                //Sets background and foreground color
                mainWindow.mainGrid.Background = (Brush)Application.Current.Properties["Background"];
                mainWindow.title.Foreground = (Brush) Application.Current.Properties["FontColor"];
                mainWindow.boardLabel.Foreground = (Brush)Application.Current.Properties["FontColor"];

                this.Close();
            }
        }

        //Method that handles the event of a button click
            //This whole window is a game board and it uses buttons for where players can choose to put either an X or O
            //  The game board is a 3X3 board
            //This method is for the game board
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if (gameOver)
            {
                MessageBox.Show("The game is over.");
                playAgainMessage();
                return;
            }
            //Creates a new button
            Button btn = sender as Button;

            Coordinates location = new Coordinates(Grid.GetRow(btn), Grid.GetColumn(btn), Int32.Parse(btn.Name.Substring(2, 1)));
            // if (btn.Content != null)


            if (gameBoard.isValidMove(location, mode))
            {
                moveCounter++;
                // MessageBox.Show("Move counter is: " + moveCounter);

                gameBoard.makeMove(location, playerTurn ? 'X' : 'O', mode);
                btn.Content = playerTurn ? "X" : "O";


                    if (gameBoard.isWinner(playerTurn ? 'X' : 'O', mode))
                    {

                        if (moveCounter == 27)
                        {
                            MessageBox.Show((playerTurn ? "X" : "O") + " Won!");
                            gameOver = true;
                            playAgainMessage();
                            return;
                        }
                        else
                        {
                            MessageBox.Show((playerTurn ? "X" : "O") + " Won!");
                            gameOver = true;
                            playAgainMessage();
                            return;
                        }
                        
                    }
                
                if (3 * 3 * 3 == moveCounter)
                {
                    MessageBox.Show("Cats game, nobody won!");
                    gameOver = true;
                    /*playAgainMessage();*/
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
            foreach (Button btn in this.Grid13d.Children.OfType<Button>())
            {
                btn.Background = (Brush)Application.Current.Properties["Background"];
                btn.Foreground = (Brush) Application.Current.Properties["FontColor"];
            }
            foreach (Button btn in this._3dGrid2.Children.OfType<Button>())
            {
                btn.Background = (Brush)Application.Current.Properties["Background"];
                btn.Foreground = (Brush)Application.Current.Properties["FontColor"];
            }
            foreach (Button btn in this._3dGrid3.Children.OfType<Button>())
            {
                btn.Background = (Brush)Application.Current.Properties["Background"];
                btn.Foreground = (Brush)Application.Current.Properties["FontColor"];
            }

        }

        //Method that handles the event of a button click 
        //Used for the Rules button
        private void btn_RuleClick(object sender, RoutedEventArgs e)
        {
            RuleWindow ruleWindow = new RuleWindow("3D tic-tac-toe, is an abstract strategy board game, generally for two players. It is similar in concept to traditional tic-tac-toe but is played in a cubical array of cells. Players take turns placing their markers in blank cells in the array. The first player to achieve three of their own markers in a row wins. The winning row can be horizontal, vertical, or diagonal on a single board as in regular tic-tac-toe, or vertically in a column, or a diagonal line through three boards.");

            ruleWindow.Show();
        }

        //Method that handles the event of a button click
        //Used for the settings button
        private void btn_SettingClick(object sender, RoutedEventArgs e)
        {
            //Creates a new window
            SettingWindow settingWindow = new SettingWindow(mode);
            
            //Shows new window
            settingWindow.Show();

            Application.Current.Properties["WindowIndex"] = this.Name;

            //Closes this window
            this.Close();

        }


        //Method that creates a message box with buttons
        //Used to ask the user if they want to play again or not
        private void playAgainMessage()
        {
            //Creates a message box with buttons
            MessageBoxResult playAgainBoxResult =
                MessageBox.Show("Do you want to play again?", "Play Again", MessageBoxButton.YesNo);

            //If user says yes then it clears the board
            if (playAgainBoxResult == MessageBoxResult.Yes)
            {
                foreach (Button btn in this.Grid13d.Children.OfType<Button>())
                {
                    btn.Content = "";
                }

                foreach (Button btn in this._3dGrid2.Children.OfType<Button>())
                {
                    btn.Content = "";
                }

                foreach (Button btn in this._3dGrid3.Children.OfType<Button>())
                {
                    btn.Content = "";
                }

                gameOver = false;
                gameBoard = null;
                gameBoard = new TicTacToeBoard(true);
                playerTurn = true;
                moveCounter = 0;
            }
            else if (playAgainBoxResult == MessageBoxResult.No) //If user says no then it closes window and opens main window
            {
                MainWindow mainWindow = new MainWindow();

                mainWindow.Show();

                //Sets background and foreground color
                mainWindow.mainGrid.Background = (Brush)Application.Current.Properties["Background"];
                mainWindow.title.Foreground = (Brush)Application.Current.Properties["FontColor"];
                mainWindow.boardLabel.Foreground = (Brush)Application.Current.Properties["FontColor"];

                this.Close();
            }
        }
    }
}
