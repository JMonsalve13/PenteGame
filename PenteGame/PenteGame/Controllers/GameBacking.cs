using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenteGame.Controllers
{
    public class GameBacking
    {
        public bool?[][] Board;

        public GameBacking()
        {
          
        }

        public void CreateBoard(int sizeNum)
        {
            Board = new bool?[sizeNum][];
            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = new bool?[sizeNum];
                for (int j = 0; j < Board[i].Length; j++)
                {
                    Board[i][j] = null;
                }
            }
        }

      
    }
}
