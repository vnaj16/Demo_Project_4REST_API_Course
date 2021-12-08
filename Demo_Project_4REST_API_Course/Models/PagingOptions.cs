﻿using System.ComponentModel.DataAnnotations;

namespace Demo_Project_4REST_API_Course.Models
{
    public class PagingOptions
    {
        [Range(1, 9999, ErrorMessage = "Offset must be greater than 0 and less than 9999")]
        public int? Offset { get; set; }
        [Range(1, 100, ErrorMessage = "Limit must be greater than 0 and less than 100")]
        public int? Limit { get; set; }

        public PagingOptions Replace(PagingOptions newer)
        {
            return new PagingOptions()
            {
                Offset = newer.Offset ?? this.Offset,
                Limit = newer.Limit ?? this.Limit
            };
        }
    }
}
