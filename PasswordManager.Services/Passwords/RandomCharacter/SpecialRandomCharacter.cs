/**************************************************************************
 *                                                                        *
 *  File:        SpecialRandomCharacter.cs                                *
 *  Copyright:   (c) 2023, Budaca Marius-Andrei                           *
 *  E-mail:      marius-andrei.budaca@student.tuiasi.ro                   *
 *  Description: Generates a random special character.                    *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


using System;

namespace PasswordManager.Services.Password.RandomCharacter
{
    /// <summary>
    /// Generates a random special character
    /// </summary>
    internal class SpecialRandomCharacter : IRandomCharacter
    {
        private readonly Random _random;
        private readonly string _chars;

        /// <summary>
        /// Generates a random special character
        /// </summary>
        public SpecialRandomCharacter(int seed)
        {
            _random = new Random(seed);
            _chars = "!#$%&()*+,-./:;<=>?@[\\]^_`{|}~";
        }
        public char NextChar()
        {
            return _chars[_random.Next(_chars.Length)];
        }
    }
}
