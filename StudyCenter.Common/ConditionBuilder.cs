using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace StudyCenter.Common
{
    internal class ConditionBuilder : ExpressionVisitor
    {
        private List<object> _mArguments;
        private Stack<string> _mConditionParts;

        public string Condition { get; private set; }

        public object[] Arguments { get; private set; }

        public void Build(Expression expression)
        {
            var evaluator = new PartialEvaluator();
            var evaluatedExpression = evaluator.Eval(expression);

            this._mArguments = new List<object>();
            this._mConditionParts = new Stack<string>();

            this.Visit(evaluatedExpression);

            this.Arguments = this._mArguments.ToArray();
            this.Condition = this._mConditionParts.Count > 0 ? this._mConditionParts.Pop() : null;
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            if (b == null) return b;

            string opr;
            switch (b.NodeType)
            {
                case ExpressionType.Equal:
                    opr = "=";
                    break;
                case ExpressionType.NotEqual:
                    opr = "<>";
                    break;
                case ExpressionType.GreaterThan:
                    opr = ">";
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    opr = ">=";
                    break;
                case ExpressionType.LessThan:
                    opr = "<";
                    break;
                case ExpressionType.LessThanOrEqual:
                    opr = "<=";
                    break;
                case ExpressionType.AndAlso:
                    opr = "AND";
                    break;
                case ExpressionType.OrElse:
                    opr = "OR";
                    break;
                case ExpressionType.Add:
                    opr = "+";
                    break;
                case ExpressionType.Subtract:
                    opr = "-";
                    break;
                case ExpressionType.Multiply:
                    opr = "*";
                    break;
                case ExpressionType.Divide:
                    opr = "/";
                    break;
                default:
                    throw new NotSupportedException(b.NodeType + "is not supported.");
            }

            this.Visit(b.Left);
            this.Visit(b.Right);

            string right = this._mConditionParts.Pop();
            string left = this._mConditionParts.Pop();

            string condition = String.Format("({0} {1} {2})", left, opr, right);
            this._mConditionParts.Push(condition);

            return b;
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            if (c == null) return c;

            this._mArguments.Add(c.Value);
            this._mConditionParts.Push(String.Format("{{{0}}}", this._mArguments.Count - 1));

            return c;
        }

        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            if (m == null) return m;

            PropertyInfo propertyInfo = m.Member as PropertyInfo;
            if (propertyInfo == null) return m;

            this._mConditionParts.Push(String.Format("[{0}]", propertyInfo.Name));

            return m;
        }
    }
}
