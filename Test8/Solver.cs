using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test8
{
    public class Solver
    {
        public static List<Chessboard> Solve()
        {
            var board = new Chessboard();
            var results = new List<Chessboard>();
            Explore(board, results);
            return results;
        }

        private static void Explore(Chessboard board, List<Chessboard> results)
        {
            var minPos = board.QueenPositions.Any() ? board.QueenPositions.Max() : 0;
            foreach (var pos in board.Slots.Where(o => o > minPos))
            {
                var newBoard = new Chessboard(board, pos);
                if (newBoard.TouchDown)
                {
                    results.Add(newBoard);
                }
                else if (!newBoard.NoSolution)
                {
                    Explore(newBoard, results);
                }
            }
        }
    }
}
