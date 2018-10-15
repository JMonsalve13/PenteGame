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
    /// Interaction logic for Setup.xaml
    /// </summary>
    public partial class Setup : Window
    {
        public Setup()
        {
            InitializeComponent();
        }

        private void rbtnTwo_Click(object sender, RoutedEventArgs e)
        {
            tbxSecondPlayer.IsEnabled = true;
            btnSubmit.IsEnabled = true;
        }

        private void rbtnOne_Click(object sender, RoutedEventArgs e)
        {
            tbxSecondPlayer.IsEnabled = false;
            tbxSecondPlayer.Text = "";
            btnSubmit.IsEnabled = true;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (rbtnOne.IsChecked == true)
            {
                if (!String.IsNullOrEmpty(tbxFirstPlayer.Text))
                {
                    GameWindow game = new GameWindow(false, tbxFirstPlayer.Text, "CPU");
                    game.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Please enter a name for player one!");
                }
            }
            if (rbtnTwo.IsChecked == true)
            {
                if (!String.IsNullOrEmpty(tbxFirstPlayer.Text) && !String.IsNullOrEmpty(tbxSecondPlayer.Text))
                {
                    GameWindow game = new GameWindow(true, tbxFirstPlayer.Text, tbxSecondPlayer.Text);
                    game.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Player one and two need a name!");
                }
            }
        }
    }

}