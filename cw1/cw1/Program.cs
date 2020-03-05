using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = args[0];

            try
            {
                var client = new HttpClient();
                var result = await client.GetAsync(url);

                if (!result.IsSuccessStatusCode) return;

                string html = await result.Content.ReadAsStringAsync();
                Regex regex = new Regex(@"\b\w*[0-9]*@\b[\w,\.]*");
                MatchCollection matches = regex.Matches(html);

                Console.WriteLine(matches.Count);
                Console.WriteLine("");

                for (int i = 0; i < matches.Count; i++)
                {
                    Console.WriteLine(matches[i]);
                }
            } catch (Exception exc)
            {
                //string s = string.Format("Wystapil blad {0}", exc.ToString());
                Console.WriteLine("Wystapil blad" + exc.ToString());
            }
        }
    }
}
