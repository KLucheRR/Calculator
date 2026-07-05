namespace CalculatorCore
{

    public static class Calculator
    {
        public const string ZERO_DIVISION_EXEPTION = "На ноль делить нельзя!";
        public static double Sum(params double[] args)
        {
            double result = 0;
            foreach (var arg in args)
            {
                result += arg;
            }
            return result;
        }

        public static double Substract(params double[] args)
        {
            double result = args[0];
            for (int i = 1; i < args.Length; i++)
            {
                result -= args[i];
            }
            return result;
        }

        public static double Multiply(params double[] args)
        {
            double result = args[0];
            for (int i = 1; i < args.Length; i++) 
            {
                result *= args[i];
            }
            return result;
        }

        public static double Divide(params double[] args)
        {
            double result = args[0];
            for (int i = 1; i < args.Length; i++)
            {
                if (args[i] == 0)
                {
                    throw new Exception(ZERO_DIVISION_EXEPTION);
                }
                result /= args[i];
            }
            return result;
        }
    }
}
