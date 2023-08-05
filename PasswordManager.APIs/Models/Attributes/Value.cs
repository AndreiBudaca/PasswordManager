using System.ComponentModel.DataAnnotations;

namespace PasswordManager.APIs.Models.Attributes
{
    public class Value : ValidationAttribute
    {
        private readonly int _minValue;
        private readonly int _maxValue;

        public Value(int minValue, int maxValue)
        {
            _maxValue = maxValue;
            _minValue = minValue;
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            return _minValue <= (int)value && _maxValue >= (int)value;
        }
    }
}
