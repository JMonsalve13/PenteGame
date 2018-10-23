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
        int turnCounter = 0;
        List<string> players = new List<string>();
        GameBacking game;
        int gameSize;
        //The main game window
        public GameWindow(bool twoPlayers, string p1, string p2, int boardSize)
        {
            InitializeComponent();

            players.Add(p1);
            players.Add(p2);
            lblGameInfo.Content = $"{players[0]}'s turn!";

            gameSize = boardSize;
            game = new GameBacking();
            game.CreateBoard(boardSize);

            for (int i = 0; i < game.Board.GetLength(0); i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                grdGameGrid.ColumnDefinitions.Add(gridCol);
                RowDefinition gridRow = new RowDefinition();
                grdGameGrid.RowDefinitions.Add(gridRow);
            }

            FillGrid(game, boardSize);
        }
        //Can be called to update or fill the game grid based on the given a 2d array
        private void FillGrid(GameBacking game, int size)
        {
            grdGameGrid.Children.Clear();

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    {
                        if (game.Board[i][j] == true)
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

            if (game.IsPlayerOnesTurn)
            {
                game.Board[row][col] = true;
            }
            else if (!game.IsPlayerOnesTurn)
            {
                game.Board[row][col] = false;
            }
            //TODO: Check if (x, y) pair setup is correct on DidPlayerWin
            if (game.DidPlayerWin(row, col))
            {
                WinningWindow popup = new WinningWindow();
                popup.ShowDialog();
            }
            else
            {
                turnCounter++;
                game.IsPlayerOnesTurn = turnCounter % 2 == 0;
                if (game.IsPlayerOnesTurn)
                {
                    lblGameInfo.Content = $"{players[0]}'s turn!";
                }
                else
                {
                    lblGameInfo.Content = $"{players[1]}'s turn!";
                }

                FillGrid(game, gameSize);

            }
        }
    }
}
