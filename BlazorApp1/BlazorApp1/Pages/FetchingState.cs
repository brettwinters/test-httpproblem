﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public class FetchingState
    {
        public bool IsFetching { get; }

        public FetchingState(bool isFetching) => IsFetching = isFetching;
    }
}
