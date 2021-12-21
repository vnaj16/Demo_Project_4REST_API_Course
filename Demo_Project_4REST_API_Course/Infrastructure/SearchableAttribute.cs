using System;

namespace Demo_Project_4REST_API_Course.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SearchableAttribute : Attribute
    {
        public ISearchExpressionProvider ExpressionProvider { get; set; }
    = new DefaultSearchExpressionProvider();
    }
}
