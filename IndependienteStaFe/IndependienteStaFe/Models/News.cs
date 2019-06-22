using System;
using System.Collections.Generic;
using System.Text;

namespace IndependienteStaFe.Models
{
    public class News
    {
        public class NewsHead
        {
            public string Status { get; set; }
            public string Message { get; set; }
            public NewsDetail[] NewsDetail { get; set; }
        }

        public class NewsDetail
        {
            public string NewsId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
            public string Date { get; set; }
            public string Profile { get; set; }
        }
    }
}
