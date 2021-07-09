
namespace GroupOfStudents
{
    class Validator
    {
        #region Validators

        public static bool IsValidText(string input)
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

        public static bool IsValidNumber(string input)
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

        #endregion
    }
}
