using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace Pars
{
    class mail
    {
        public void send()
        {
            bool ept = true;
            string privet="";
            List<Price> listxml = XML.FU();
            List<Price> listmain = MainWindow.GG();
            for (int i = 0; i < listmain.Count; i++)
            {

                if (listmain[i].Cost != listxml[i].Cost)
                {
                    ept = false;
                    privet = privet +
                             String.Format("Изменилось " + listmain[i].Name + "|| Цена " + listxml[i].Cost + " -> " +
                                           listmain[i].Cost + "\n");
                    
                }
            }

        

            if (ept)
            {
                MessageBox.Show("Изменений не произошло.");
            }
            else
            {
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);

                string login = "";
                string pass = "";

                smtp.Credentials = new NetworkCredential(login, pass);
                MailMessage message = new MailMessage();


                string mymail = "info.sztls@yandex.ru";

                string КУДА = "ice-t-16@mail.ru";
                message.From = new MailAddress(mymail);
                message.To.Add(new MailAddress(КУДА));

                message.Subject = "Записи";
                message.Body = privet;

                MessageBox.Show(privet);
                

                XML bb = new XML();
                bb.Download(listmain);

                smtp.Send(message);
            }
        }
    }
}

