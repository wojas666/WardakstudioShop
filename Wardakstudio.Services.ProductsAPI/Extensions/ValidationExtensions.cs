using FluentValidation;

namespace Wardakstudio.Services.ProductsAPI.Extensions
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> MustSeoFriendly<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            char[] unexcepted = new[] { 'ą', 'ś', 'ł', 'ó', 'ź', 'ż', 'ń', '0', '1', '2', '3', '4', '5','6', '7', '8', '9', '@', '#', '$', '%', '^', '&', '*', '(', ')', '?','_', '=','+', '`', '\\', ',', '.' };

            bool UrlIsSeoFriendly(string input) => !input.ToLower().ContainsAny(unexcepted);

            return ruleBuilder.Must(UrlIsSeoFriendly);
        }

        public static IRuleBuilderOptions<T, string> MustSectionPartialUrl<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            bool UrlIsValidUri(string url) => url.Length > 2 
                && url.Count(x=>x == '/') == 2 
                && url.EndsWith('/') 
                && url.StartsWith('/');

            return ruleBuilder.Must(UrlIsValidUri);
        }
    }
}
