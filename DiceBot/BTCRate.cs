using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


// MARKC
namespace DiceBot
{
    public class BTCRate
    {
        static public Decimal GetRate()
        {
            Decimal rate = 0;

            try
            {
                WebClient wc = new WebClient();
                String s = wc.DownloadString(@"http://www.xe.com/currencytables/?from=XBT");

                String rateS = ExtractComponentFromString(s, 1, "<td>US Dollar</td><td class=\"historicalRateTable-rateHeader\">", "</td>");

                rate = Math.Round(Convert.ToDecimal(rateS), 2);
            }
            catch(Exception ex)
            {
                rate = 0;
            }
           
            return rate;
        }
        private static String ExtractComponentFromString(string s, int NthMatch, string startMatch, string endMatch, Boolean include=false)
        {
            string rtv = null;
            int i = 0;
            int sind = 0;
            int eind = 0;

            while (i < NthMatch)
            {
                sind = s.IndexOf(startMatch, sind) + 1;

                if (i == NthMatch - 1)
                {
                    sind--;
                }
                i++;
            }

            if (sind >= 0)
            {
                eind = s.IndexOf(endMatch, sind + startMatch.Length);

                if (eind != -1)
                {
                    int rsind = include ? sind : sind + startMatch.Length;
                    int reind = include ? eind + endMatch.Length : eind;

                    rtv = s.Substring(rsind, (reind - rsind));
                }
            }

            return rtv;

        }


    }
}
