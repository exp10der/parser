using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pars.MyToolsLibrary;

namespace Pars
{
    /// <summary>
    /// Движок базы данных
    /// </summary>
    class BaseEngine
    {
        private List<Price> baseDataList;
        private List<string> textList;

        public BaseEngine()
        {
            baseDataList = new List<Price>();
            textList = new List<string>();
            GetListText("input.txt");
        }

        public Tuple<List<Price>, Exception> Run()
        {
            try
            {

                GetPrice();
                // PrintExel.ExportToExcel(baseDataList);
                return new Tuple<List<Price>, Exception>(baseDataList, null);
            }
            catch (Exception exception)
            {
                return new Tuple<List<Price>, Exception>(new List<Price>(), exception);
            }
        }

        public async Task<Tuple<List<Price>, Exception>> RunAsync()
        {
            return await Task.Run(() => Run());
        }

        /// <summary>
        /// Заполняем список строками из файла
        /// </summary>
        /// <param name="text">Текст</param>
        private void GetListText(string text)
        {
            string line;

            var file =
                new System.IO.StreamReader(text, System.Text.Encoding.GetEncoding(1251));

            while ((line = file.ReadLine()) != null)
            {
                textList.Add(line);
            }

            file.Close();
        }

        private void GetPrice()
        {
            Parallel.For(0, textList.Count, i =>  
         {
                var scan = new TextScanner(textList[i]);
             
                // Debug.Print("Тест "+Thread.CurrentContext.ToString());
                // Debug.Print(Thread.CurrentThread.GetHashCode().ToString());
                scan.Skip("{");
                string tmpName = scan.ReadTo("}");

                scan.Skip("{");
                string tmpSite = scan.ReadTo("}");

                scan.Skip("{");
                string tmpCost = scan.ReadTo("}");

                scan.Skip("{");
                string tmpeToken = scan.ReadTo("}");


                int a = calculate.Price(tmpCost, tmpSite);
                int b = calculate.Price(tmpeToken, tmpSite);

                baseDataList.Add(new Price() { Name = tmpName, Site = tmpSite, Cost = a, eToken = b });

            });
        }

    }
}
