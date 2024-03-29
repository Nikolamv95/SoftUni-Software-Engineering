﻿using System;

namespace SUS.HTTP
{
    public class Route
    {
        public Route(string path, HttpMethod httpMethod, Func<HttpRequest, HttpResponse> action)
        {
            this.Path = path;
            this.HttpMethod = httpMethod;
            this.Action = action;
        }

        public string Path { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public Func<HttpRequest, HttpResponse> Action { get; set; }
    }
}
