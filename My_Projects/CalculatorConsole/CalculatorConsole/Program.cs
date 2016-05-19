using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorConsole
{
    public enum OperationType
    {
        None,
        Sum,
        Subtract,
        Multiply,
        Divide,
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please input first value:");
                string strFirstValue = Console.ReadLine();
                double firstValue = Convert.ToDouble(strFirstValue);
                OperationType operationType = GetInputOperation();
                Console.WriteLine("Please input second value:");
                string strSecondValue = Console.ReadLine();
                double secondValue = Convert.ToDouble(strSecondValue);
                IOperation operation = TOperationFactory.CreateOperation(operationType);
                operation.NumberOne = firstValue;
                operation.NumberTwo = secondValue;
                Console.WriteLine("Result: " + operation.GetResult());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
            Console.Read();
        }
        private static OperationType GetInputOperation()
        {
            OperationType result = OperationType.None;
            Console.WriteLine("Please choose a Operation [+, -, *, /]:");
            string OperationString = Console.ReadLine();
            switch (OperationString)
            {
                case "+":
                    result = OperationType.Sum;
                    break;
                case "-":
                    result = OperationType.Subtract;
                    break;
                case "*":
                    result = OperationType.Multiply;
                    break;
                case "/":
                    result = OperationType.Divide;
                    break;
            }
            if (result == OperationType.None)
            {
                throw new Exception("Invalid operation string:" + OperationString);
            }
            return result;
        }

    }

    public interface IOperation
    {
        double NumberOne { get;set;}
        double NumberTwo { get;set;}
        double GetResult();
    }

    public class TSumOperation : IOperation
    {
        private double FNumOne;
        private double FNumTwo;
        #region IOperation Members

        public double NumberOne
        {
            get
            {
                return FNumOne;
            }
            set
            {
                if (FNumOne != value)
                {
                    FNumOne = value;
                }
            }
        }

        public double NumberTwo
        {
            get
            {
                return FNumTwo;
            }
            set
            {
                if (FNumTwo != value)
                {
                    FNumTwo = value;
                }
            }
        }

        private double Operate(double aNumOne, double aNumTwo)
        {
            double result = 0;
            result = aNumOne + aNumTwo;
            return result;
        }

        public double GetResult()
        {
            return Operate(NumberOne, NumberTwo);
        }

        #endregion
    }

    public class TSubtractOperation : IOperation
    {
        private double FNumOne;
        private double FNumTwo;
        #region IOperation Members

        public double NumberOne
        {
            get
            {
                return FNumOne;
            }
            set
            {
                if (FNumOne != value)
                {
                    FNumOne = value;
                }
            }
        }

        public double NumberTwo
        {
            get
            {
                return FNumTwo;
            }
            set
            {
                if (FNumTwo != value)
                {
                    FNumTwo = value;
                }
            }
        }

        private double Operate(double aNumOne, double aNumTwo)
        {
            double result = 0;
            result = aNumOne - aNumTwo;
            return result;
        }

        public double GetResult()
        {
            return Operate(NumberOne, NumberTwo);
        }

        #endregion
    }

    public class TMultiplyOperation : IOperation
    {
        private double FNumOne;
        private double FNumTwo;
        #region IOperation Members

        public double NumberOne
        {
            get
            {
                return FNumOne;
            }
            set
            {
                if (FNumOne != value)
                {
                    FNumOne = value;
                }
            }
        }

        public double NumberTwo
        {
            get
            {
                return FNumTwo;
            }
            set
            {
                if (FNumTwo != value)
                {
                    FNumTwo = value;
                }
            }
        }

        private double Operate(double aNumOne, double aNumTwo)
        {
            double result = 0;
            result = aNumOne * aNumTwo;
            return result;
        }

        public double GetResult()
        {
            return Operate(NumberOne, NumberTwo);
        }

        #endregion
    }

    public class TDivideOperation : IOperation
    {
        private double FNumOne;
        private double FNumTwo;
        #region IOperation Members

        public double NumberOne
        {
            get
            {
                return FNumOne;
            }
            set
            {
                if (FNumOne != value)
                {
                    FNumOne = value;
                }
            }
        }

        public double NumberTwo
        {
            get
            {
                return FNumTwo;
            }
            set
            {
                if (FNumTwo != value)
                {
                    FNumTwo = value;
                }
            }
        }

        private double Operate(double aNumOne, double aNumTwo)
        {
            double result = 0;
            result = aNumOne / aNumTwo;
            return result;
        }

        public double GetResult()
        {
            return Operate(NumberOne, NumberTwo);
        }

        #endregion
    }

    public class TOperationFactory
    {
        public static IOperation CreateOperation(OperationType aType)
        {
            IOperation result = null;
            switch (aType)
            {
                case OperationType.None:
                    break;
                case OperationType.Sum:
                    result = new TSumOperation();
                    break;
                case OperationType.Subtract:
                    result = new TSubtractOperation();
                    break;
                case OperationType.Multiply:
                    result = new TMultiplyOperation();
                    break;
                case OperationType.Divide:
                    result = new TDivideOperation();
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
