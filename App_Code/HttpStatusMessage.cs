namespace System.Net
{
  public class HttpStatusMessage
  {
    private static readonly string[,] codesAndMessages = new string[,]
    {
            {"200", "OK"},
            {"201", "Created"},
            {"202", "Accepted"},
            {"203", "Non-Authoritative Information"},
            {"204", "No Content"},
            {"205", "Reset Content"},
            {"206", "Partial Content"},
            {"207", "Multi-Status"},
            {"208", "Already Reported"},
            {"226", "IM Used"},
            {"300", "Multiple Choices"},
            {"301", "Moved Permanently"},
            {"302", "Found"},
            {"303", "See Other"},
            {"304", "Not Modified"},
            {"305", "Use Proxy"},
            {"306", "Unused"},
            {"307", "Temporary Redirect"},
            {"308", "Permanent Redirect"},
            {"400", "Bad Request"},
            {"401", "Unauthorized"},
            {"402", "Login Required"},
            {"403", "Forbidden"},
            {"404", "Page Not Found"},
            {"405", "Method Not Allowed"},
            {"406", "Not Acceptable"},
            {"407", "Proxy Authentication Required"},
            {"408", "Request Timeout"},
            {"409", "Conflict"},
            {"410", "Gone"},
            {"411", "Length Required"},
            {"412", "Precondition Failed"},
            {"413", "Request Entity Too Large"},
            {"414", "Request-URI Too Long"},
            {"415", "Unsupported Media Type"},
            {"416", "Requested Range Not Satisfiable"},
            {"417", "Expectation Failed"},
            {"420", "Enhance Your Calm"},
            {"422", "Unprocessable Entity"},
            {"423", "Locked"},
            {"424", "Failed Dependency"},
            {"425", "Reserved for WebDAV"},
            {"426", "Upgrade Required"},
            {"428", "Precondition Required"},
            {"429", "Too Many Requests"},
            {"431", "Request Header Fields Too Large"},
            {"444", "No Response"},
            {"449", "Retry With"},
            {"450", "Blocked by Windows Parental Controls"},
            {"451", "Unavailable For Legal Reasons"},
            {"499", "Client Closed Request"},
            {"500", "Internal Server Error"},
            {"501", "Not Implemented"},
            {"502", "Bad Gateway"},
            {"503", "Service Unavailable"},
            {"504", "Gateway Timeout"},
            {"505", "HTTP Version Not Supported"},
            {"506", "Variant Also Negotiates"},
            {"507", "Insufficient Storage"},
            {"508", "Loop Detected"},
            {"509", "Bandwidth Limit Exceeded"},
            {"510", "Not Extended"},
            {"511", "Network Authentication Required"},
            {"598", "Network read timeout error"},
            {"599", "Network connect timeout error"}
    };

    /// <summary>
    /// Retrieves the HTTP status message based on the provided integer code.
    /// </summary>
    /// <param name="code">The integer code representing the HTTP status.</param>
    /// <returns>The corresponding HTTP status message if found, otherwise an error message with the provided code.</returns>
    public static string Get(int code)
    {
      for (int i = 0; i < codesAndMessages.Length; i++)
      {
        if (codesAndMessages[i, 0].Equals($"{code}"))
        {
          return codesAndMessages[i, 1];
        }
      }

      return $"Error code {code}";
    }

    /// <summary>
    /// Retrieves the HTTP status message based on the provided string code.
    /// </summary>
    /// <param name="code">The string code representing the HTTP status.</param>
    /// <returns>The corresponding HTTP status message if found, otherwise an error message with the provided code.</returns>
    public static string Get(string code)
    {
      for (int i = 0; i < codesAndMessages.Length; i++)
      {
        if (codesAndMessages[i, 0].Equals(code))
        {
          return codesAndMessages[i, 1];
        }
      }

      return $"Error code {code}";
    }
  }
}