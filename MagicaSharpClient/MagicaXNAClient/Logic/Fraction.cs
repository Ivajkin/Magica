using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicaXNAClient
{
    /// <summary>
    /// Фракция к которой принадлежит персонаж.
    /// </summary>
    enum Fraction
    {
        /// <summary>
        /// Игроки 1: техника.
        /// </summary>
        techi,
        /// <summary>
        /// Игроки 2: магия.
        /// </summary>
        magi,
        /// <summary>
        /// Нейтральные монстры (например олень).
        /// </summary>
        neutral,
        /// <summary>
        /// Враждебные монстры (например медведь).
        /// </summary>
        hostile
    }
}
