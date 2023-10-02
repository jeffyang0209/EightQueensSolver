namespace Test8
{
    internal class Program
    {
        // 此解法是網路找來的，稍微了解過再補上測試
        // 不可在同一條水平線上
        // 不可在同一條垂直線上
        // 不可在同一條對角線上
        static void Main(string[] args)
        {
            var board = new Chessboard();
            Explore(board);
            Console.ReadLine();
        }

        static int resIdx = 1;
        static void Explore(Chessboard board)
        {
            //放皇后的順序一律由左上到右下，排除重複組合
            var minPos = board.QueenPositions.Any() ? board.QueenPositions.Max() : 0;
            foreach (var pos in board.Slots.Where(o => o > minPos))
            {
                var newBoard = new Chessboard(board, pos);
                if (newBoard.TouchDown)
                {
                    Console.WriteLine($"=== Result {resIdx++:00} ===");
                    newBoard.Print();
                }
                else if (!newBoard.NoSolution)
                {
                    Explore(newBoard);
                }
            }
        }
    }
}