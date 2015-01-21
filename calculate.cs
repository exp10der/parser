using System;
using Pars.MyToolsLibrary;

namespace Pars
{
    class calculate
    {
        public static int Price(string cost, string site)
        {
            // Проверяем пдфка или страница html
            site = site.Contains("pdf") ? pdf_reоader.Pdf(site) : HtmlDownloadHelper.DownloadHtml(site);

            // Если вернуло -1 то значит произошел эксепшен при скачивании
            if (site == "-1")
                return -1;

            /*
             * Вот этот мусор нужно править и использовать методы с TrySkip в while 
             * А не на эксепшенах
             * нужно фиксить
             */
            #region Мусор
            var siteScan = new TextScanner(site);
            var scan = new TextScanner(cost);
            int value = 0;
            for (; ; )
            {
                try
                {
                    scan.Skip("&");
                    string times = scan.ReadTo("&");
                    int b = Convert.ToInt32(times);

                    for (int i = 1; i <= b; )
                    {
                        scan.Skip("(");
                        string from = scan.ReadTo(")");
                        siteScan.Skip(from);
                        i++;
                    }

                    scan.Skip("[");
                    string to = scan.ReadTo("]");
                    string finalcost = siteScan.ReadTo(to);

                    finalcost = finalcost.Trim().Replace(" ", string.Empty);
                    finalcost = finalcost.Trim().Replace("&nbsp;", string.Empty);
                    value = value + Convert.ToInt32(finalcost);

                }
                catch { break; }

            }
            #endregion

            return value;

        }
    }
}




