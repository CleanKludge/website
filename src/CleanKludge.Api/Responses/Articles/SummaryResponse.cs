﻿using System;
using System.Collections.Generic;

namespace CleanKludge.Api.Responses.Articles
{
    public class SummaryResponse
    {
        public Location Location { get; set; }
        public string Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Keywords { get; set; }
        public string Author { get; set; }
        public bool Enabled { get; set; }
    }
}