﻿using System;
using System.Collections.Generic;
using System.Text;
using SUS.HTTP;

namespace SUS.MvcFramework
{
    public abstract class BaseHttpAttribute : Attribute
    {
        public string Url { get; set; }
        public abstract HttpMethod Method { get; }
    }
}
