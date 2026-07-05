namespace Calculator.Controllers.Calculator
{
    public class Query
    {
        public IEnumerable<double> Args { get; set; }
        public OperationType Type { get; set; }
    }

    public enum OperationType
    {
        Sum,
        Substract,
        Multiply,
        Divide
    }
}
