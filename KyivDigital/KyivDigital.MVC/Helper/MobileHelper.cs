using System.Linq;

namespace KyivDigital.MVC.Helper
{
    public class MobileHelper
    {
        public static bool ValidateMobile(string phone)
        {
            bool isValid = false;
            if (phone.StartsWith("+380"))
            {
                isValid = true;
                if (operatorIsValid(phone))
                    isValid = true;
                else
                    isValid = false;
            }
            return isValid;
        }

        private static bool operatorIsValid(string phone)
        {
            var partOperator = phone.Substring(3, 3);
            return availableOperators().FirstOrDefault(x => x == partOperator) != null ? true : false;
        }

        private static string[] availableOperators() => new string[]
        {
            "063",
            "073",
            "093",
            "095",
            "096",
            "097",
            "098",
            "099"
        };
    }
}