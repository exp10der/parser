/*
 * Скорее всего можно удалять 
 * пришел с беты
 * 
*/
using System;

namespace Pars
{
    /// <summary>
    /// Класс для извлечения из текста цены
    /// </summary>
    public class Parcer
    {
        //--- members ---------------------------------------------------------
        string mText;
        int price = 0;

        //--- public ----------------------------------------------------------
        /// <summary>
        /// Конструктор убирает пробелы \n \t
        /// </summary>
        public Parcer(string text)
        {
            mText = text.Trim(); ;
        }
        /// <summary>
        /// Убрать из текста все символы оставить только цифры
        /// </summary>
        /// <returns>Число</returns>
        public int GetNum()
        {
            //int number = Convert.ToInt32("Enter a number between −2,147,483,648 and +2,147,483,647 (inclusive).");
            //mText = mText.Trim('р','у');
            price = Convert.ToInt32(mText);

            return price;
        }
    }
}
