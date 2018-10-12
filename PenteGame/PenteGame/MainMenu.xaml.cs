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

namespace PenteGame
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        //The main menu for the game, allows you to go from screen to screen and close
        public MainMenu()
        {
            InitializeComponent();
        }
        //Brings the player to a game settings screen
        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            Setup setup = new Setup();
            setup.Show();
            Close();
        }
        //Brings the player to a help window, to explain the rules
        private void btnHelpScreen_Click(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.Show();
            Close();
        }
        //Closes the game
        private void btnQuitGame_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
