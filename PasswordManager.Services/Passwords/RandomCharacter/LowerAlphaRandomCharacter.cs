/**************************************************************************
 *                                                                        *
 *  File:        LowerAlphaRandomCharacter.cs                             *
 *  Copyright:   (c) 2023, Budaca Marius-Andrei                           *
 *  E-mail:      marius-andrei.budaca@student.tuiasi.ro                   *
 *  Description: Generates a random lower case alpha character.           *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


using PasswordManager.Services.Password.RandomCharacter;

namespace asswordManager.Services.Password.RandomCharacter
{
    /// <summary>
    /// Generates a random lower case alpha character
    /// </summary>
    internal class LowerAlphaRandomCharacter : IRandomCharacter
    {
        private readonly Random _random;

        /// <summary>
        /// Generates a random lower case alpha character
        /// </summary>
        public LowerAlphaRandomCharacter(int seed)
        {
            _random = new Random(seed);
        }
        public char NextChar()
        {
            return (char)('a' + _random.Next(26));
        }
    }
}
