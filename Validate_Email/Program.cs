namespace Validate_Email;

public class Program
{
    public static void Main(string[] args)
    {
        string email = "Ebrahem.Outlook@outlook.com";
        bool isValid = ValidateEmail_1(email);
        Console.WriteLine($"Is |{email}| a valid email? |{isValid}|");
    }


    // Validate Email Format Manually
    static bool ValidateEmail_1 (string email)
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

}