using static laba666.Program;
namespace laba666 {

    public static class Additions {

// Т Р А Н С П О Н И Р О В А Н Н А Я (переворачивает матрицу по ее диагонали)
        public static AboutMatrix MatrixTransposition(this AboutMatrix A) {
            for (int IndexColumn = 0; IndexColumn < A.Size; ++IndexColumn) {
                for (int IndexRow = 0; IndexRow < A.Size; ++IndexRow) {
                    A.array[IndexColumn, IndexRow] = A.array[IndexRow, IndexColumn];
                }
            }
            return A;
        }
        public static double MatrixTrace(this AboutMatrix matrix) {
            double Result = 0;
            for (int IndexColumn = 0; IndexColumn < matrix.Size; ++IndexColumn) {
                for (int IndexRow = 0; IndexRow < matrix.Size; ++IndexRow) {
                    if (IndexColumn == IndexRow) {
                        Result += matrix.array[IndexColumn, IndexRow];
                    }
                }
            }
            return Result;
        }
    }
}
