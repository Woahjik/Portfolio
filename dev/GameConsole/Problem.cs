/*
    Problem Class for Mach Challenge Game
*/

namespace GameConsole;

public class Problem
{
    //Fields
    private readonly string[] _possibleOperators = {"+", "-", "*", "/"};
    private string _problemOperator;
    private int _term1;
    private int _term2;

    //Properties
    public string Expression { get; set; }
    public int Solution { get; set; }

    //Constructor
    public Problem()
    {
        //declare random instance
        Random random = new Random();

        //declare first term, second term, problem operator, and expression
        _term1 = random.Next(0, 20);
        _term2 = random.Next(0, 20);
        _problemOperator = _possibleOperators[random.Next(0, _possibleOperators.Length)];
        Expression = $"{_term1} {_problemOperator} {_term2}";
        
        //set solution based on problem operator
        switch (_problemOperator)
        {
            case "+":
                Solution = _term1 + _term2;
                break;
            case "-":
                Solution = _term1 - _term2;
                break;
            case "*":
                Solution = _term1 * _term2;
                break;
            default:
                Solution = _term1 / _term2;
                break;
        }

    }
}