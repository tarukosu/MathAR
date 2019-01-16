using B83.ExpressionParser;
using UnityEngine;

namespace MathAR
{
    public class CustomFunction : FunctionOfTwoVariables
    {
        [Tooltip("数式を記入する。変数は x, y")] [SerializeField] private string customFunction = "x + y";

        void Awake()
        {
            function = customFunction;
        }

        void Start()
        {
            Calc(0, 0);
            Calc(1, 1);
        }

        // Update is called once per frame
        void Update()
        {

        }

        /*
        public double Calc(double x, double y)
        {
            var parser = new ExpressionParser();
            Expression exp = parser.EvaluateExpression(function);
            exp.Parameters["x"].Value = x;
            exp.Parameters["y"].Value = y;

            var result = exp.Value;

            Debug.Log("Log: " + exp.Value);
            return result;

            /*
    
            Expression e = new Expression("2.0 + 3 * 5");
            var result = e.Evaluate();
            Debug.Log(result);
            return (double)result;
            */
            //Debug.Assert(17 == e.Evaluate());

            /*
    
            string exp = "(1+6)*5/(7-4.0)+1";
    
            try
            {
                uREPL.Mono.evaluator.Run("using System;");
    
                int result = (int)uREPL.Mono.evaluator.Evaluate("1+1;");
                Debug.Log(result);
    
                object ret;
                bool hasReturnValue;
                var isPartial = uREPL.Mono.Evaluate(exp, out ret, out hasReturnValue) != null;
                Debug.Log(ret);
                return 0;
            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogError(e.Message);
                return double.NaN;
            }
//            /
        }
           */
    }
}