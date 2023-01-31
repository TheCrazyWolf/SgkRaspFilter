using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgkRaspFilter.Models
{
    internal class Lessons
    {
        public string date { get; set; }
        public List<_lesson> lessons { get; set; }
    }

    class _lesson
    {
        public string title { get; set; }
        public string num { get; set; }
        public string teachername { get; set; }
        public string nameGroup { get; set; }
        public string cab { get; set; }
        public string resource { get; set; }
    }
}
