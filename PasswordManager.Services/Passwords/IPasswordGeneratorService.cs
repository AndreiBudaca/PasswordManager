/**************************************************************************
 *                                                                        *
 *  File:        IGenerator.cs                                            *
 *  Copyright:   (c) 2023, Budaca Marius-Andrei                           *
 *  E-mail:      marius-andrei.budaca@student.tuiasi.ro                   *
 *  Description: Interface for generating random strings.                 *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


namespace PasswordManager.Services.Password
{
    /// <summary>
    /// Interface for generating random strings
    /// </summary>
    public interface IPasswordGeneratorService
    {
        /// <summary>
        /// Set the generated string length
        /// </summary>
        /// <param name="length">Length of the string to generate</param>
        void SetLength(int length);

        /// <summary>
        /// Add possibility for string to contain lower alpha characters
        /// </summary>
        void SetLowerAlpha();

        /// <summary>
        /// Add possibility for string to contain upper alpha characters
        /// </summary>
        void SetUpperAlpha();

        /// <summary>
        /// Add possibility for string to contain numeric characters
        /// </summary>
        void SetNumeric();

        /// <summary>
        /// Add possibility for string to contain special characters
        /// </summary>
        void SetSpecial();

        /// <summary>
        /// Generate string with set options
        /// </summary>
        /// <returns>The generated string</returns>
        string Generate();
    }
}
