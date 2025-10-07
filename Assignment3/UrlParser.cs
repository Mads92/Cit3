using System;
namespace Assignment3;
class UrlParser
{
    public bool HasId { get; set; }
    public string Id { get; set; }
    public string Path { get; set; }

    public UrlParser()
    { 
    HasId = false;
    Id = string.Empty;
    Path = string.Empty;
    }


    public bool ParseUrl(string url)
    {
        if ((HasId) &
            url == Path)
        {
            return true;
        }
        else return false;
        
    }

}


