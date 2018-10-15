using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenteGame.Controllers
{
    public class GameBacking
    {
        public bool?[][] Board = new bool?[19][];

        public GameBacking()
        {
            CreateBoard();
        }

        private void CreateBoard()
        {
            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = new bool?[19];
                for (int j = 0; j < Board[i].Length; j++)
                {
                    Board[i][j] = null;
                }
            }
        }

      
    }
}
