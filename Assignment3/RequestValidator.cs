using System.Collections.Generic;

namespace Assignment3
{
    public class Request
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public string Date { get; set; }
        public string Body { get; set; }
        //public List<string> RequestFields = new List<string> { Method,};

    }

    public class Response
    {
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public class RequestValidator
    {
        public List<string> RequiredFields = new List<string> { "method", "path", "date" };
        public List<string> ValidMethods = new List<string> { "create", "read", "update", "delete", "echo" };
        public List<string> Fields;

        public Response ValidateRequest(Request request)
        {
            Response re = new Response();
            int count = 0;
            List<string> MissingFields = new List<string>();

            if (!ValidMethods.Contains(request.Method) && request.Method != null)
            {
                re.Status = "illegal method";
                return re;
            }
            if ((request.Method == "create" || request.Method == "update" || request.Method == "echo") && request.Body.Length == 0)
            {
                re.Status = "missing body";
                return re;
            }
            //if
            if (request.Date == null || request.Date.Length == 0)
            {
                re.Status = "missing date";
                return re;
            }
            if (request.Path == null || request.Path.Length ==0)
            {
                re.Status = "missing path";
                return re;
            }

            if (request.Date.Length == 0)
            {
                re.Status = "missing date";
                return re;
            }
            if (request.Method == null)
            {
                count++;
                MissingFields.Add("method");
            }
            if (request.Path == null)
            {
                count++;
                MissingFields.Add("path");
            }
            if (request.Date == null)
            {
                count++;
                MissingFields.Add("date");
            }

            if (count > 0)
            {
                re.Status = "4 missing ";
                foreach (string field in MissingFields)
                {
                    re.Status += field + ", ";
                }

            }
            if (count == 0)
            {
                re.Status = "1 ok";
            }
            return re;
        }
    }
}



