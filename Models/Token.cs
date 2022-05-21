using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Token
    {
        public string Type { get; set; }
        public string Text { get; set; }

        public int LineNum { get; set; }
        public Token()
        {

        }
        public Token(string type, string text)
        {
            this.Type = type;
            this.Text = text;
            this.LineNum = 1;

        }
    }
    }