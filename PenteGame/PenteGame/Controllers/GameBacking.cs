using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenteGame.Controllers
{
    public class GameBacking
    {
        public bool?[][] Board;

        public int Size { get; set; }

        public int Player1CptrCounter { get; set; }

        public int Player2CptrCounter { get; set; }

       
        /// <summary>
        /// Fills the Board with uniform arrays to represent the board of pente
        ///ahh
        public void CreateBoard(int sizeNum) {

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

        public bool DetectFiveInARowWin(int x, int y) {
            bool? piece = Board[x][y];
            bool IsFiveInARow = false;
            int[] list = new int[4];
            list[0] = CheckForFiveInARow(x, y, x + 1, y + 1);
            list[1] = CheckForFiveInARow(x, y, x + 1, y - 1);
            list[2] = CheckForFiveInARow(x, y, x, y + 1);
            list[3] = CheckForFiveInARow(x, y, x + 1, y);
            int max = 0;
            for (int i = 0; i < list.Length; i++) {
                if (max < list[i]) {
                    max = list[i];
                }
            }
            if (max >= 5) {
                IsFiveInARow = true;
            }
            return IsFiveInARow;
        }

        private int CheckForFiveInARow(int x1, int y1, int x2, int y2) {
            return CheckForFiveInARow(x1, y1, x2, y2, false);
        }

        private int CheckForFiveInARow(int x1, int y1, int x2, int y2, bool hasGoneInOtherDirection) {
            int amount = 1;
            if (IsInsideTheBoard(x2, y2) && Board[x1][y1] == Board[x2][y2]) {
                amount = amount + CheckForFiveInARow(x1, y1, x2 + CheckDirection(x1, x2), y2 +  CheckDirection(y1, y2), hasGoneInOtherDirection);
            } else if (!hasGoneInOtherDirection) {
                amount = CheckForFiveInARow(x1, y1, x1 - CheckDirection(x1, x2), y1 - CheckDirection(y1, y2), !hasGoneInOtherDirection);
            }
            return amount;
        }

        private int CheckDirection(int value1, int value2) {
            int overallValue = value1 - value2;
            int boardProgression = 0;
            if (overallValue < 0)
            {
                boardProgression = -1;
            }
            else if (overallValue > 0) {
                boardProgression = 1;
            }
            return boardProgression;
        }

        /// <summary>
        /// Checks if the a specific win condition, based on the surrounding area around a given piece
        /// </summary>
        /// <param name="x">The x position of the checked piece</param>
        /// <param name="y">The y posiition of the checked piece</param>
        /// <param name="size">The size is the length of the check of the win conition - 1(for instance a check for a consecutive 5 spaces would have a size 4)</param>
        /// <param name="isFillColorSameAsPieceColor">If the space in between the intial piece and the corelating checked piece that lies on the area is the same color as the pieces checked. (For a capture check, this would be false)</param>
        public void CheckWinSurroundings(int x, int y, int size, bool isFillColorSameAsPieceColor) {
            int[] XValues = { -size, 0, size };
            int[] YValues = { -size, 0, size };
            foreach (int checkX in XValues) {
                foreach (int checkY in YValues) {
                    int perPieceX = x + size;
                    int perPieceY = y + size;
                    if (IsInsideTheBoard(perPieceX, perPieceY) && (perPieceX != x && perPieceY != y)) {
                        CheckFill(x, y, perPieceX, perPieceY, isFillColorSameAsPieceColor ? Board[x][y] : !Board[x][y]);
                    }
                }
            }
        }

        /// <summary>
        /// Checks for any capture that ocurred from the piece coordinates provided
        /// </summary>
        /// <param name="x">X position of piece</param>
        /// <param name="y">Y position of piece</param>
        /// <param name="ean">returns true if there are no errors</param>
        public void PossibleCaptures(int x, int y,out bool ean) {
            CheckWinSurroundings(x, y, 3, false);
            throw new NotImplementedException();
            
        }

        /// <summary>
        /// Checks the pieces that lie between the first piece and the second piece
        /// </summary>
        /// <param name="x1">X position of first piece</param>
        /// <param name="y1">Y position of first piece</param>
        /// <param name="x2">X position of second piece</param>
        /// <param name="y2">Y position of second piece</param>
        /// <param name="checkFill">The value checked to see if something is equal to first piece or not.</param>
        private bool CheckFill(int x1, int y1, int x2, int y2, bool? checkFill) {
            bool isFilled = true;
            bool? initialPiece = Board[y1][x1];
            bool? checkPiece = Board[y2][x2];
            if (initialPiece == checkPiece)
            { 
                while (x2 != x1 && y2 != y1) {
                    y2 = y2 - CheckDirection(y1, y2);
                    x2 = x2 - CheckDirection(x1, x2);
                    checkPiece = Board[y2][x2];
                    if (checkPiece == null || checkPiece != checkFill) {
                        isFilled = false;
                        break;
                    }
                }
            }
            return isFilled;
        }

        /// <summary>
        /// Checks if the selected cooardinates are inside the board
        /// </summary>
        /// <param name="array">The array of unpaired cooardinates provided</param>
        /// <returns></returns>
        private bool IsInsideTheBoard(params int[] array) {
            bool isInsideBoard = true;
            foreach (int i in array) {
                isInsideBoard = i >= 0 && i < Size;
            }
            return isInsideBoard;
        }

       

      
    }
}
