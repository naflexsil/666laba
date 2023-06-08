
/**********************************
*                                 *
*        Стариковой Алины         *
*       "Делегаты, события"       *
*                                 *
**********************************/

using System;
using System.Diagnostics;
using static _666laba.Handlers;

namespace laba666 {
    public class Program {
        static void Main(string[] args) {
            Console.WriteLine("\t\n||||||||||||| размер квадратной матрицы |||||||||||||");
// М А Т Р И Ц А    О Б Ъ Е Д И Н Е Н Н А Я    
            AboutMatrix MatrixA = new AboutMatrix();
            MatrixA.Size = Convert.ToInt32(Console.ReadLine());
            AboutMatrix MatrixB = new AboutMatrix();
            MatrixB.Size = Convert.ToInt32(Console.ReadLine());
            var RandomNumber = new Random((int)Stopwatch.GetTimestamp());
            for (int IndexColumn = 0; IndexColumn < MatrixA.Size; ++IndexColumn) {
                for (int IndexRow = 0; IndexRow < MatrixA.Size; ++IndexRow) {
                    MatrixA.array[IndexColumn, IndexRow] = RandomNumber.Next(10, 100);
                    MatrixB.array[IndexColumn, IndexRow] = RandomNumber.Next(10, 100);
                }
            }
            Console.WriteLine("\n\n\n\t\t! красивенькие готовенькие матрицы !");
            Console.WriteLine(MatrixA.ToString());
            Console.WriteLine(MatrixB.ToString());
            Console.WriteLine("\n\n\n\t||||||||||||| что желаем? |||||||||||||");
            Console.WriteLine("1)  сложить\n2)  вычесть\n3)  умножить\n4)  детерминант\n5)  инверсия\n6)  диагональная матрица\n7)  транспонирование\n8)  след матрицы\n\n");

//З А П У С К    Ц Е П О Ч К И   О Б Я З А Н Н О С Т Е Й           
            int Choice = int.Parse(Console.ReadLine());
            Start Menu = new Start();
            Menu.HandleStart(MatrixA, MatrixB, Choice); 
            Console.ReadKey();
        }

        public static void ConvertToDiagonal(AboutMatrix A) {
            Action<AboutMatrix> convertDelegate = delegate (AboutMatrix matrix) {
                for (int IndexColumn = 0; IndexColumn < matrix.Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < matrix.Size; ++IndexRow) {
                        if (IndexColumn != IndexRow)
                            matrix.array[IndexColumn, IndexRow] = 0;
                    }
                }
            };
            A.ConvertToDiagonal(convertDelegate);
            Console.WriteLine($"\n\t! держи матрицу диагональную !\n {A}");
        }

        public class AboutMatrix {
            public int Size;
            public double[,] array = new double[10, 10];
            public void ConvertToDiagonal(Action<AboutMatrix> convertDelegate) {
                convertDelegate(this);
            }


// D E E P  C O P Y
            public AboutMatrix DeepCopy() {
                AboutMatrix clone = (AboutMatrix)this.MemberwiseClone();
                return clone;
            }
// C O M P A R E  T O
            public int CompareTo(AboutMatrix other) {
                if (other is null)
                    return 1;
                if (Size != other.Size)
                    return Size.CompareTo(other.Size);
                for (int IndexColumn = 0; IndexColumn < Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < Size; ++IndexRow) {
                        int compare = array[IndexColumn, IndexRow].CompareTo(other.array[IndexColumn, IndexRow]);
                        if (compare != 0)
                            return compare;
                    }
                }
                return 0;
            }
// E Q U A L S
            public override bool Equals(object obj) {
                if (obj is null || !(obj is AboutMatrix)) {
                    return false;
                }
                return this == (AboutMatrix)obj;
            }
// G E T  H A S H  C O D E
            public override int GetHashCode() {
                unchecked {
                    int hashCode = 20;
                    for (int ColumnCounter = 0; ColumnCounter < Size; ++ColumnCounter) {
                        for (int RowCounter = 0; RowCounter < Size; ++RowCounter) {
                            hashCode = hashCode * 23 + array[ColumnCounter, RowCounter].GetHashCode();
                        }
                    }
                    return hashCode;
                }
            }
// С Л О Ж Е Н И Е
            public static AboutMatrix operator +(AboutMatrix A, AboutMatrix B) {
                for (int IndexColumn = 0; IndexColumn < A.Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < A.Size; ++IndexRow) {
                        A.array[IndexColumn, IndexRow] = A.array[IndexColumn, IndexRow] + B.array[IndexColumn, IndexRow];
                    }
                }
                return A;
            }
// В Ы Ч И Т А Н И Е
            public static AboutMatrix operator -(AboutMatrix A, AboutMatrix B) {
                for (int IndexColumn = 0; IndexColumn < A.Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < A.Size; ++IndexRow) {
                        A.array[IndexColumn, IndexRow] = A.array[IndexColumn, IndexRow] - B.array[IndexColumn, IndexRow];
                    }
                }
                return A;
            }
// У М Н О Ж Е Н И Е 
            public static AboutMatrix operator *(AboutMatrix A, AboutMatrix B) {
                for (int IndexColumn = 0; IndexColumn < A.Size; ++IndexColumn) {
                    for (int Index = 0; Index < A.Size; ++Index) {
                        for (int IndexRow = 0; IndexRow < A.Size; ++IndexRow) {
                            A.array[IndexColumn, Index] += A.array[IndexRow, Index] * B.array[IndexColumn, IndexRow];
                        }
                    }
                }
                return A;
            }
// Д Е Л Е Н И Е
            public static AboutMatrix operator /(AboutMatrix A, AboutMatrix B) {
                for (int IndexColumn = 0; IndexColumn < A.Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < A.Size; ++IndexRow) {
                        try {
                            A.array[IndexColumn, IndexRow] = A.array[IndexColumn, IndexRow] / B.array[IndexColumn, IndexRow];
                        }
                        catch {
                            A.array[IndexColumn, IndexRow] = 0;
                        }
                    }
                }
                return A;
            }
// С Р А В Н Е Н И Я
            public static bool operator ==(AboutMatrix A, AboutMatrix B) {
                if (A.Size != B.Size) {
                    return true;
                }
                for (int IndexColumn = 0; IndexColumn < A.Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < A.Size; ++IndexRow) {
                        if (A.array[IndexColumn, IndexRow] == B.array[IndexColumn, IndexRow]) {
                            return true;
                        }
                    }
                }
                return false;
            }
            public static bool operator !=(AboutMatrix A, AboutMatrix B) {
                if (A.Size != B.Size) {
                    return true;
                }
                for (int IndexColumn = 0; IndexColumn < A.Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < A.Size; ++IndexRow) {
                        if (A.array[IndexColumn, IndexRow] != B.array[IndexColumn, IndexRow]) {
                            return true;
                        }
                    }
                }
                return false;
            }
            public static AboutMatrix operator >(AboutMatrix A, AboutMatrix B) {
                for (int IndexColumn = 0; IndexColumn < A.Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < A.Size; ++IndexRow) {
                        if (A.array[IndexColumn, IndexRow] > B.array[IndexColumn, IndexRow]) {
                            A.array[IndexColumn, IndexRow] = 1;
                        }
                        else {
                            A.array[IndexColumn, IndexRow] = 0;
                        }
                    }
                }
                return A;
            }
            public static AboutMatrix operator <(AboutMatrix A, AboutMatrix B) {
                for (int IndexColumn = 0; IndexColumn < A.Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < A.Size; ++IndexRow) {
                        if (A.array[IndexColumn, IndexRow] < B.array[IndexColumn, IndexRow]) {
                            A.array[IndexColumn, IndexRow] = 1;
                        }
                        else {
                            A.array[IndexColumn, IndexRow] = 0;
                        }
                    }
                }
                return A;
            }
            public static AboutMatrix operator >=(AboutMatrix A, AboutMatrix B) {
                for (int IndexColumn = 0; IndexColumn < A.Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < A.Size; ++IndexRow) {
                        if (A.array[IndexColumn, IndexRow] >= B.array[IndexColumn, IndexRow]) {
                            A.array[IndexColumn, IndexRow] = 1;
                        }
                        else {
                            A.array[IndexColumn, IndexRow] = 0;
                        }
                    }
                }
                return A;
            }
            public static AboutMatrix operator <=(AboutMatrix A, AboutMatrix B) {
                for (int IndexColumn = 0; IndexColumn < A.Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < A.Size; ++IndexRow) {
                        if (A.array[IndexColumn, IndexRow] <= B.array[IndexColumn, IndexRow]) {
                            A.array[IndexColumn, IndexRow] = 1;
                        }
                        else {
                            A.array[IndexColumn, IndexRow] = 0;
                        }
                    }
                }
                return A;
            }

// М И Н О Р  +  О П Р Е Д Е Л И Т Е Л Ь
            public static AboutMatrix Minor(AboutMatrix A, int Column, int Row) {
                AboutMatrix buf = new AboutMatrix();
                for (int IndexColumn = 0; IndexColumn < A.Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < A.Size; ++IndexRow) {
                        if ((IndexRow != Row) || (IndexColumn != Column)) {
                            if (IndexColumn > Column && IndexRow < Row) buf.array[IndexColumn - 1, IndexRow] = A.array[IndexColumn, IndexRow];
                            if (IndexColumn < Column && IndexRow > Row) buf.array[IndexColumn, IndexRow - 1] = A.array[IndexColumn, IndexRow];
                            if (IndexColumn > Column && IndexRow > Row) buf.array[IndexColumn - 1, IndexRow - 1] = A.array[IndexColumn, IndexRow];
                            if (IndexColumn < Column && IndexRow < Row) buf.array[IndexColumn, IndexRow] = A.array[IndexColumn, IndexRow];
                        }
                    }
                }
                return buf;
            }
            public double Determ(AboutMatrix A) {
                double det = 0;
                int Rank = A.Size;
                if (Rank == 1) det = A.array[0, 0];
                if (Rank == 2) det = A.array[0, 0] * A.array[1, 1] - A.array[0, 1] * A.array[1, 0];
                if (Rank > 2) {
                    for (int Index = 0; Index < A.Size; ++Index) {
                        det += Math.Pow(-1, 0 + Index) * A.array[0, Index] * Determ(Minor(A, 0, Index));
                    }
                }
                return det;
            }
            private AboutMatrix SubMatrix(int Row, int Column) {
                var subMatrix = new AboutMatrix();
                int subRow = 0;
                for (int IndexRow = 0; Row < Size; ++Row) {
                    if (IndexRow == Row)
                        continue;
                    int subColumn = 0;
                    for (int IndexColumn = 0; Column < Size; ++Column) {
                        if (IndexColumn == Column)
                            continue;
                        subMatrix.array[subColumn, subColumn] = array[Column, Column];
                        ++subColumn;
                    }
                    ++subRow;
                }
                return subMatrix;
            }


// И Н В Е Р С И Я
            public AboutMatrix Inverse(AboutMatrix A) {
                var determinant = Determ(A);
                if (determinant == 0) {
                    throw new InvalidOperationException(" инверсии не может быть");
                }
                var Result = new AboutMatrix();
                int sign = 1;
                for (int IndexColumn = 0; IndexColumn < Result.Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < Result.Size; ++IndexRow) {
                        var subMatrix = SubMatrix(IndexColumn, IndexRow);
                        Result.array[IndexRow, IndexColumn] = sign * subMatrix.Determ(A) / determinant;
                        sign = -sign;
                    }
                }
                return Result;
            }

// В Ы В О Д  М А Т Р И Ц Ы
            public override string ToString() {
                string Result = $"\n размеры: {Size} x {Size}";
                Result += $"\n|||||||||||||||||||||||||||||||||||||||\n" + "\t\tМатрица\n";
                for (int IndexColumn = 0; IndexColumn < Size; ++IndexColumn) {
                    for (int IndexRow = 0; IndexRow < Size; ++IndexRow) {
                        Result += array[IndexColumn, IndexRow].ToString() + "\t";
                    }
                    Result += "\n";
                }
                return Result;
            }
        }
    }
}