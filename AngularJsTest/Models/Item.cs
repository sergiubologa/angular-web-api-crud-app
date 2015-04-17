using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJsTest.Models
{
    public class Item
    {
        public int id { get; set; }
        public string description { get; set; }
        public decimal? measure { get; set; }
        public int um { get; set; }
        public string unitOfMeasure { get; set; }
    }
}