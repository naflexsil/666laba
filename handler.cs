using laba666;
using System;
using static laba666.Program;

namespace _666laba {
    public class Handlers {
        public delegate void DelegateForHandle(AboutMatrix MatrixA, AboutMatrix MatrixB, int Choice);
        public abstract class Handler {
            public DelegateForHandle HandleStart;
            public Handler Successor { get; set; }
            public abstract void HandlerStart(AboutMatrix MatrixA, AboutMatrix MatrixB, int Choice);
        }

        public class Start : Handler {
            public Start() {
                Successor = new Plus();
                HandleStart = HandlerStart;
            }
            public override void HandlerStart(AboutMatrix MatrixA, AboutMatrix MatrixB, int Choice) {
                Successor.HandleStart(MatrixA, MatrixB, Choice);
            }
        }

        public class Plus : Handler {
            public Plus() {
                Successor = new Minus();
                HandleStart = HandlerStart;
            }
            public override void HandlerStart(AboutMatrix MatrixA, AboutMatrix MatrixB, int Choice) {
                if (Choice == 1) {
                    Console.WriteLine($"сумма:\n{MatrixA + MatrixB}");
                }
                else {
                    Successor.HandleStart(MatrixA, MatrixB, Choice);
                }
            }
        }

        public class Minus : Handler {
            public Minus() {
                Successor = new Multiplic();
                HandleStart = HandlerStart;
            }
            public override void HandlerStart(AboutMatrix MatrixA, AboutMatrix MatrixB, int Choice) {
                if (Choice == 2) {
                    Console.WriteLine($"разность:\n{MatrixA - MatrixB}");
                }
                else {
                    Successor.HandleStart(MatrixA, MatrixB, Choice);
                }
            }
        }

        public class Multiplic : Handler {
            public Multiplic() {
                Successor = new Determ();
                HandleStart = HandlerStart;
            }
            public override void HandlerStart(AboutMatrix MatrixA, AboutMatrix MatrixB, int Choice) {
                if (Choice == 3) {
                    Console.WriteLine($"произведение:\n{MatrixA * MatrixB}");
                }
                else {
                    Successor.HandleStart(MatrixA, MatrixB, Choice);
                }
            }
        }

        public class Determ : Handler {
            public Determ() {
                Successor = new Inverse();
                HandleStart = HandlerStart;
            }
            public override void HandlerStart(AboutMatrix MatrixA, AboutMatrix MatrixB, int Choice) {
                if (Choice == 4) {
                    Console.WriteLine($"детерминант: {MatrixA.Determ(MatrixA)}");
                }
                else {
                    Successor.HandleStart(MatrixA, MatrixB, Choice);
                }
            }
        }

        public class Inverse : Handler {
            public Inverse() {
                Successor = new ConvertDiagonal();
                HandleStart = HandlerStart;
            }
            public override void HandlerStart(AboutMatrix MatrixA, AboutMatrix MatrixB, int Choice) {
                if (Choice == 5) {
                    try {
                        var InverseOfMatrix = MatrixA.Inverse(MatrixA);
                        Console.WriteLine($"обратная матрица А:\n{InverseOfMatrix}");
                    }
                    catch {
                        Console.WriteLine("еще раз подумай");
                    }
                }
                else {
                    Successor.HandleStart(MatrixA, MatrixB, Choice);
                }
            }
        }

        public class ConvertDiagonal : Handler {
            public ConvertDiagonal() {
                Successor = new Transe();
                HandleStart = HandlerStart;
            }
            public override void HandlerStart(AboutMatrix MatrixA, AboutMatrix Matrix2, int UserChoice) {
                if (UserChoice == 6) {
                    ConvertToDiagonal(MatrixA);
                }
                else {
                    Successor.HandleStart(MatrixA, Matrix2, UserChoice);
                }
            }          
        }

        public class Transe : Handler {
            public Transe() {
                Successor = new Trace();
                HandleStart = HandlerStart;
            }
            public override void HandlerStart(AboutMatrix MatrixA, AboutMatrix MatrixB, int UserChoice) {
                if (UserChoice == 7) {
                    var TransposedMatrix = MatrixA.MatrixTransposition();
                    Console.WriteLine("транспонированная матрица:");
                    Console.WriteLine(TransposedMatrix);
                }
                else {
                    Successor.HandleStart(MatrixA, MatrixB, UserChoice);
                }
            }
        }

        public class Trace : Handler {
            public Trace() {
                HandleStart = HandlerStart;
            }
            public override void HandlerStart(AboutMatrix MatrixA, AboutMatrix MatrixB, int UserChoice) {
                if (UserChoice == 8) {
                    double Trace = MatrixA.MatrixTrace();
                    Console.WriteLine($"cлед матрицы: {Trace}\n");
                }
                else {
                    Successor.HandleStart(MatrixA, MatrixB, UserChoice);
                }
            }
        }
    }
}
