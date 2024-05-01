namespace ShuDu
{
    internal class SudoCaculate
    {
        private int[,] board;

        private bool SolveSudoku()
        {
            int row, col;
            if (!FindEmptyCell(out row, out col))
                return true; 

            for (int num = 1; num <= 9; num++)
            {
                if (IsValidMove(row, col, num))
                {
                    board[row, col] = num;

                    if (SolveSudoku())
                        return true;

                    board[row, col] = 0;
                }
            }

            return false;
        }

        private bool FindEmptyCell(out int row, out int col)
        {
            for (row = 0; row < 9; row++)
            {
                for (col = 0; col < 9; col++)
                {
                    if (board[row, col] == 0)
                        return true;
                }
            }
            row = -1;
            col = -1;
            return false;
        }

        private bool IsValidMove(int row, int col, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[row, i] == num || board[i, col] == num)
                    return false;

                int boxRow = 3 * (row / 3) + i / 3;
                int boxCol = 3 * (col / 3) + i % 3;
                if (board[boxRow, boxCol] == num)
                    return false;
            }
            return true;
        }

        private SudoCaculate(int[,] board)
        {
            this.board = board;
        }

        public static int[,] Caculate(int[,] data)
        {
            var result = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    result[i, j] = data[i, j];
                }
            }
            var caculate = new SudoCaculate(result);
            caculate.SolveSudoku();
            return result;
        }
    }
}
