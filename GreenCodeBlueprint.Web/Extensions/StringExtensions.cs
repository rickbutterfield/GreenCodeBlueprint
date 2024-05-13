namespace GreenCodeBlueprint.Web.Extensions
{
    public static class StringExtensions
    {
        public static string ToCssClass(this string value)
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(value))
            {
                foreach (char c in value)
                {
                    if (char.IsLetterOrDigit(c))
                    {
                        result += c;
                    }
                    else
                    {
                        result += '-';
                    }
                }
            }

            return result.ToLower();
        }
    }
}
