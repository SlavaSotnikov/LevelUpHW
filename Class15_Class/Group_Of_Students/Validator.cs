
namespace Group_Of_Students
{
    class Validator
    {
        public static bool IsValidateText(string input)
        {
            bool result = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static bool IsValidateNumber(string input)
        {
            bool result = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]) && !char.IsWhiteSpace(input[i]))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
