using System;
using System.Linq.Expressions;

namespace Demo_Project_4REST_API_Course.Infrastructure
{
    public class StringToIntSearchExpressionProvider : DefaultSearchExpressionProvider
    {
        public override ConstantExpression GetValue(string input)
        {
            if (!int.TryParse(input, out var result))
                throw new ArgumentException("Invalid search value");


            return Expression.Constant(result);
        }

        public override Expression GetComparison(
    MemberExpression left, string op, ConstantExpression right)
        {
            switch (op.ToLower())
            {
                case "gt": return Expression.GreaterThan(left, right);
                case "gte": return Expression.GreaterThanOrEqual(left, right);
                case "lt": return Expression.LessThan(left, right);
                case "lte": return Expression.LessThanOrEqual(left, right);

                // If nothing matches, fall back to base impl
                default: return base.GetComparison(left, op, right);
            }
        }
    }
}
