using SgkRaspFilter.Models;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        DateTime start = new DateTime(2022, 10, 01);
        DateTime end = new DateTime(2022, 12, 30);
        
        DateTime _current = start;

        List<GroupApi> groups_for_search = new List<GroupApi>();

        while (_current.Date != DateTime.Now.Date)
        {
            
            var json = Response($"https://asu.samgk.ru//api/schedule/cabs/{_current.Date.ToString("yyyy-MM-dd")}/cabNum/дист_дист");
            var lessons = JsonSerializer.Deserialize<Lessons>(json);

            var whitelist = new List<string> { "СА", "КС", "ИС", "ОБ", "ОТЗ" };
            Console.Write($"[{lessons.date}] -> ");

            List<string> groups_today = new List<string>();

            foreach (var lesson in lessons.lessons)
            {

                string[] curs = lesson.nameGroup.Split('-');

                if (lesson.cab != "дист/дист")
                    continue;

                if (curs == null)
                    continue;

                //if (curs[1] != "22")
                //    continue;

                //if (curs[0] is not "СА" or "КС" or "ИС" or "ОБ" or "ОТЗ")
                if (!whitelist.Contains(curs[0]))
                    continue;

                if (!groups_today.Contains(lesson.nameGroup.ToString()))
                {
                    groups_today.Add(lesson.nameGroup);
                    //Console.Write($"{lesson.}")
                }
            }

            foreach (var item in groups_today)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("");
            _current = _current.AddDays(1);
        }
        //groups_for_search = 

    }

    public static string Response(string url)
    {
        try
        {
            using (var wb = new WebClient())
            {
                wb.Headers.Set("Accept", "application/json");
                wb.Headers.Set("origin", "http://samgk.ru");
                wb.Headers.Set("Referer", "samgk.ru");
                return wb.DownloadString(url);
            }
        }
        catch (Exception ex)
        {
            //WriteError(ex.ToString());
        }

        return null;
    }
}