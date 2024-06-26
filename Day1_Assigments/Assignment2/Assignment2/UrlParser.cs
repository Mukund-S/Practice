namespace Assignment2;
using System;
using System.Text.RegularExpressions;
public class UrlParser
{
    public UrlParser(string url)
    {
        var parts = ParseUrl(url);
        Console.WriteLine("[protocol] = \"" + parts.protocol + "\"");
        Console.WriteLine("[server] = \"" + parts.server + "\"");
        Console.WriteLine("[resource] = \"" + parts.resource + "\"");
        }
    static (string protocol, string server, string resource) ParseUrl(string url)
    {
        string pattern = @"^(?:(?<protocol>\w+):\/\/)?(?<server>[\w.-]+)(?:\/(?<resource>.*))?$";
        var match = Regex.Match(url, pattern);
        string protocol = match.Groups["protocol"].Value;
        string server = match.Groups["server"].Value;
        string resource = match.Groups["resource"].Value;
        if (string.IsNullOrEmpty(server))
        {
            throw new ArgumentException("The server part is mandatory in the URL.");
        }

        return (protocol, server, resource);
    }
}