using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Advanced_C_Sharp;

public class Program
{
    public static void Main(string[] args)
    {
        string email_1 = "Ebrahem.Outlook@outlook.com";
        bool isValid_1 = IsValidateEmail_1(email_1);
        Console.WriteLine($"Is |{email_1}| a valid email? |{isValid_1}|");

        Console.WriteLine("********************************************");

        string email_2 = "Ebrahem.Outlook@outlook.com";
        bool isValid_2 = IsValidateEmail_2(email_2);
        Console.WriteLine($"Is |{email_2}| a valid email? |{isValid_2}|");

        Console.WriteLine("********************************************");

        string email_3 = "Ebrahem.Outlook@outlook.com";
        bool isValid_3 = IsValidateEmail_2(email_3);
        Console.WriteLine($"Is |{email_3}| a valid email? |{isValid_3}|");

        Console.WriteLine("********************************************");

        string email_4 = "Ebrahem.Outlook@outlook.com";
        bool isValid_4 = IsValidateEmail_2(email_4);
        Console.WriteLine($"Is |{email_4}| a valid email? |{isValid_4}|");
    }


    // Validate Email Format Manually
    public static bool IsValidateEmail_1 (string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }

        string[] parts = email.Split('@');
        if (parts.Length != 2)
        {
            return false; //email must have exactly one @ symbol
        }

        string localPart = parts[0];
        string domainPart = parts[1];
        if (string.IsNullOrEmpty(localPart) || string.IsNullOrEmpty(domainPart))
        {
            return false;
        }

        // check local part for valid characters
        foreach (char c in localPart)
        {
            if (!char.IsLetterOrDigit(c) && c != '.'&& c !='_' && c != '-')
            {
                return false; // local part contains invalid character
            }
        }

        // check domain part for valid format
        if (domainPart.Length < 2 || !domainPart.Contains(".")|| domainPart.Split("." ).Length != 2 || domainPart.StartsWith(".") || domainPart.EndsWith("."))
        {
            return false; // domain part is not a vild format
        }

        return true;
    }


    // Validate Email Format using regex
    public static bool IsValidateEmail_2 (string email)
    {
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        if (string.IsNullOrEmpty(email))
            return false;

        Regex regex = new Regex(emailPattern);
        return regex.IsMatch(email);
    }

    // Validate Email using MailAddress => The Best
    public static bool IsValidateEmail_3 (string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }

        try
        {
            // Use MailAddress class to validate email format
            var address = new MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }

    // Validate Domain
    public static bool IsValidateEmail_4 (string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        string[] parts = email.Split('@');
        if(parts.Length != 2)
        {
            return false; // email must have exactly one @ synbol
        }

        string localPart = parts[0];
        string domainPart = parts[1];

        try
        {
            // check if domain name hae a valid MX record
            var hostEntry = Dns.GetHostEntry(domainPart);
            return hostEntry.HostName.Length > 0;
        }
        catch
        {
            return false; // domain name is invalid or does not have aa valid MX record
        }
    }
}