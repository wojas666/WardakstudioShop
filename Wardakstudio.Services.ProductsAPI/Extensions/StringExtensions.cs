namespace Wardakstudio.Services.ProductsAPI.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsAny(this string input, IEnumerable<char> containsCharacters)
        {
            var lowerInput = input.ToLower();

            foreach(char character in containsCharacters)
            {
                bool IsCharacterExist = lowerInput.Contains(character);

                if (IsCharacterExist)
                    return true;
            }

            return false;
        }
    }
}
