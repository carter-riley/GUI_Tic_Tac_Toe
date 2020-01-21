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
    /// Interaction logic for CustomChoiceWindow.xaml
    /// </summary>
    public partial class CustomChoiceWindow : Window
    {
        public CustomChoiceWindow()
        {
            InitializeComponent();
        }

        //Method that sets the colors of the background and font on load
        private void CustomChoiceWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            //Uses the startup variables that we have declared
            customGrid.Background = (Brush)Application.Current.Properties["Background"];
            customLabel.Foreground = (Brush)Application.Current.Properties["FontColor"];
            customText.Foreground = (Brush)Application.Current.Properties["FontColor"];
        }

        //Method that handles the button click event
        //Used when the Go button is clicked
        //Opens a new window that creates a game board based on the number the user has given
        private void btn_GoClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["BoardSize"] = int.Parse(customText.Text);

            CustomWindow customWindow = new CustomWindow();

            //Closes first window opens another
            this.Close();
            customWindow.createWindow(customWindow);
        }
    }
}