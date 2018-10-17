using PenteGame.Controllers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PenteGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        List<string> players = new List<string>();
        //The main game window
        public GameWindow(bool twoPlayers, string p1, string p2, int boardSize)
        {
            InitializeComponent();
            players.Add(p1);
            players.Add(p2);
            lblGameInfo.Content = $"{players[0]}'s turn!";
            GameBacking game = new GameBacking();
            FillGrid(game);
        }
        //Can be called to update or fill the game grid based on the given a 2d array
        private void FillGrid(GameBacking game)
        {
            
            for (int i = 0; i < 19; i++)
                for (int j = 0; j < 19; j++)
                {
                    {
                        if(game.Board[i][j] == true)
                        {
                            Ellipse piece = new Ellipse();
                            piece.Fill = Brushes.White;
                            piece.Stroke = Brushes.Black;
                            piece.StrokeThickness = 1;
                            this.grdGameGrid.Children.Add(piece);
                            Grid.SetRow(piece, i);
                            Grid.SetColumn(piece, j);
                        }
                        else if (game.Board[i][j] == false)
                        {
                            Ellipse piece = new Ellipse();
                            piece.Fill = Brushes.Black;
                            piece.Stroke = Brushes.Black;
                            piece.StrokeThickness = 1;
                            this.grdGameGrid.Children.Add(piece);
                            Grid.SetRow(piece, i);
                            Grid.SetColumn(piece, j);
                        }
                        else
                        {
                            Rectangle piece = new Rectangle();
                            piece.Fill = Brushes.White;
                            piece.Stroke = Brushes.Black;
                            piece.StrokeThickness = 1;
                            piece.Opacity = .01;
                            piece.MouseLeftButtonDown += new MouseButtonEventHandler(turn);
                            this.grdGameGrid.Children.Add(piece);
                            Grid.SetRow(piece, i);
                            Grid.SetColumn(piece, j);
                        }
                    }
                }
        }
        //A click method where the game logic will handle a click on the board
        private void turn(object sender, MouseButtonEventArgs e)
        {
            var point = Mouse.GetPosition(grdGameGrid);
            
            int row = 0;
            int col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;

            foreach (var rowDefinition in grdGameGrid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }

            foreach (var columnDefinition in grdGameGrid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }

            MessageBox.Show($"{row} {col}");
        }
    }
}
