using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test8;

namespace TestProject
{
    [TestClass]
    public class TestData
    {
        /// <summary>
        /// 測試皇后數量
        /// </summary>
        [TestMethod]
        public void TestSolveEightQueens()
        {
            var results = Solver.Solve();
            Assert.IsTrue(results.Count > 0);

            foreach (var board in results)
            {
                var boardStr = board.GetBoardString();
                var QCount = boardStr.Count(c => c == 'Q');
                Assert.AreEqual(8, QCount);  // 確保每個結果都有8個皇后
            }
        }

        /// <summary>
        /// 測試不互相攻擊
        /// </summary>
        [TestMethod]
        public void TestQueensNotAttackingEachOther()
        {
            var results = Solver.Solve();
            foreach (var board in results)
            {
                for (int i = 0; i < board.QueenPositions.Count; i++)
                {
                    for (int j = i + 1; j < board.QueenPositions.Count; j++)
                    {
                        var q1 = board.QueenPositions[i];
                        var q2 = board.QueenPositions[j];

                        var q1X = q1 / Chessboard.DIG_SHIFT;
                        var q1Y = q1 % Chessboard.DIG_SHIFT;

                        var q2X = q2 / Chessboard.DIG_SHIFT;
                        var q2Y = q2 % Chessboard.DIG_SHIFT;

                        // 檢查是否在同一行或同一列
                        Assert.AreNotEqual(q1X, q2X);
                        Assert.AreNotEqual(q1Y, q2Y);

                        // 檢查是否在對角線上
                        Assert.IsFalse(q1X - q1Y == q2X - q2Y);
                        Assert.IsFalse(q1X + q1Y == q2X + q2Y);
                    }
                }
            }
        }
    }
}
