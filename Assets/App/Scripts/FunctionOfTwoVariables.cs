using System.Collections;
using System.Collections.Generic;
using B83.ExpressionParser;
using UnityEngine;

namespace MathAR
{
    public class FunctionOfTwoVariables : MonoBehaviour
    {
        protected string function = "x + y";
        protected ExpressionParser parser;
        protected Expression expression;

        void Awake()
        {
        }

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public float Calc(double x, double y)
        {
            if (expression == null)
            {
                parser = new ExpressionParser();
                expression = parser.EvaluateExpression(function);
            }

            //var parser = new ExpressionParser();
            //Expression exp = parser.EvaluateExpression(function);
            expression.Parameters["x"].Value = x;
            expression.Parameters["y"].Value = y;

            var result = expression.Value;

            // Debug.Log("Log: " + exp.Value);
            return (float) result;
        }
    }
}
