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
            List<int> oddNums = new List<int>();
            for (int i = 9; i < 40; i++)
            {
                if (i % 2 != 0)
                {
                    oddNums.Add(i);
                    cbxBoardSize.Items.Add(i);
                }
            }
            cbxBoardSize.SelectedItem = cbxBoardSize.Items[0];
        }
        //Enable the submit button and enable player 2 text box
        private void rbtnTwo_Click(object sender, RoutedEventArgs e)
        {
            tbxSecondPlayer.IsEnabled = true;
            btnSubmit.IsEnabled = true;
        }
        //Enable the submit button and disable player 2 text box
        private void rbtnOne_Click(object sender, RoutedEventArgs e)
        {
            tbxSecondPlayer.IsEnabled = false;
            tbxSecondPlayer.Text = "";
            btnSubmit.IsEnabled = true;
        }
        //Determines how many players there are when submit is clicked and will pass that information to gameWindow
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (rbtnOne.IsChecked == true)
            {
                if (!String.IsNullOrEmpty(tbxFirstPlayer.Text))
                {
                    GameWindow game = new GameWindow(false, tbxFirstPlayer.Text, "CPU", (int)cbxBoardSize.SelectedItem);
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
                    GameWindow game = new GameWindow(true, tbxFirstPlayer.Text, tbxSecondPlayer.Text, (int)cbxBoardSize.SelectedItem);
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