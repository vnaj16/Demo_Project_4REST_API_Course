﻿using System;

namespace Demo_Project_4REST_API_Course.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SearchableIntAttribute : SearchableAttribute
    {
        public SearchableIntAttribute()
        {
            ExpressionProvider = new StringToIntSearchExpressionProvider();
        }
    }
}

