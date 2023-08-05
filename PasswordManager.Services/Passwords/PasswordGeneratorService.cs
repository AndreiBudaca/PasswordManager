/**************************************************************************
 *                                                                        *
 *  File:        PasswordGenerator.cs                                     *
 *  Copyright:   (c) 2023, Budaca Marius-Andrei                           *
 *  E-mail:      marius-andrei.budaca@student.tuiasi.ro                   *
 *  Description: Generates random passwords.                              *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using asswordManager.Services.Password.RandomCharacter;
using PasswordManager.Services.Password.Option;
using PasswordManager.Services.Password.RandomCharacter;

namespace PasswordManager.Services.Password
{
    /// <summary>
    /// Generates random passwords
    /// </summary>
    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        private GeneratorOptions _options;
        private int _length;

        /// <summary>
        /// Generates random passwords (Default length: 10. Default GeneratorOptions: None)
        /// </summary>
        public PasswordGeneratorService()
        {
            _options = GeneratorOptions.None;
            _length = 10;
        }

        public string Generate()
        {
            var seed = (int)(DateTime.Now.Ticks % int.MaxValue);
            var characterSet = new List<IRandomCharacter>();
            var generatedPass = new char[_length];
            var random = new Random(seed);

            if (_options == GeneratorOptions.None)
                _options = GeneratorOptions.LowerAlpha;

            if ((_options & GeneratorOptions.LowerAlpha) != 0)
            {
                characterSet.Add(new LowerAlphaRandomCharacter(seed));
            }

            if ((_options & GeneratorOptions.UpperAlpha) != 0)
            {
                characterSet.Add(new UppderAlphaRandomCharacter(seed));
            }

            if ((_options & GeneratorOptions.Numeric) != 0)
            {
                characterSet.Add(new NumericRandomCharacter(seed));
            }

            if ((_options & GeneratorOptions.Special) != 0)
            {
                characterSet.Add(new SpecialRandomCharacter(seed));
            }

            var setLength = characterSet.Count;

            for (int i = 0; i < generatedPass.Length; i++)
            {
                generatedPass[i] = characterSet[random.Next(setLength)].NextChar();
            }

            // Generate a character from all character generators to ensure that the password will
            // contain a character from all character sets
            int startPos = 0;
            for (int i = 0; i < setLength; i++)
            {
                var posToChange = random.Next(startPos, _length - setLength + i + 1);
                generatedPass[posToChange] = characterSet[i].NextChar();
                startPos = posToChange + 1;
            }

            return new string(generatedPass);
        }

        public void SetLength(int length)
        {
            if (length > 3 && length < 33)
                _length = length;
            else
                throw new ArgumentOutOfRangeException(nameof(length), "Length should be between 4 and 32!");
        }

        public void SetLowerAlpha()
        {
            _options |= GeneratorOptions.LowerAlpha;
        }

        public void SetNumeric()
        {
            _options |= GeneratorOptions.Numeric;
        }

        public void SetSpecial()
        {
            _options |= GeneratorOptions.Special;
        }

        public void SetUpperAlpha()
        {
            _options |= GeneratorOptions.UpperAlpha;
        }
    }
}
