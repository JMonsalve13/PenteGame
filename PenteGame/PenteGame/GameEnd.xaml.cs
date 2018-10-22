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
    /// Interaction logic for GameEnd.xaml
    /// </summary>
    public partial class GameEnd : Window
    {
        public GameEnd()
        {
            InitializeComponent();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            Close();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            Setup setup = new Setup();
            setup.Show();
            Close();
        }
    }
}
