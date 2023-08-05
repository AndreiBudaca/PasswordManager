/**************************************************************************
 *                                                                        *
 *  File:        GeneratorOptions.cs                                      *
 *  Copyright:   (c) 2023, Budaca Marius-Andrei                           *
 *  E-mail:      marius-andrei.budaca@student.tuiasi.ro                   *
 *  Description: Options for random string generation.                    *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


namespace PasswordManager.Services.Password.Option
{
    /// <summary>
    /// Options for random string generation
    /// </summary>
    public enum GeneratorOptions
    {
        None = 0,
        LowerAlpha = 1,
        UpperAlpha = 2,
        Numeric = 4,
        Special = 8,
    }
}
