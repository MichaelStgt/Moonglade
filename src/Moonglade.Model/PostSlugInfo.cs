﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Moonglade.Model
{
    public struct PostSlugInfo
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Slug { get; set; }

        public override string ToString() => $"{Year}/{Month}/{Day}/{Slug}";

        public PostSlugInfo(int year, int month, int day, string slug)
        {
            Year = year;
            Month = month;
            Day = day;
            Slug = slug;
        }
    }
}