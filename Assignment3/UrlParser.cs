using System;
using Assignment3;

namespace Assignment3
{
    public class UrlParser
    {
        public Request ParseUrl(string url)
        {
            var parts = url.Split(' ', 4, StringSplitOptions.RemoveEmptyEntries);
            var req = new Request();

            if (parts.Length > 0) req.Method = parts[0];
            if (parts.Length > 1) req.Path = parts[1];
            if (parts.Length > 2) req.Date = parts[2];
            if (parts.Length > 3) req.Body = parts[3];

            return req;
        }
    }
}