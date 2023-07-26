using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GroupSelect
{
    internal class AreaComment
    {
        private string text;
        private Rectangle area;
        public AreaComment(string _text, Rectangle _rectangle)
        {
            this.text = _text;
            this.area = _rectangle;
        }
        public string Text { get { return text; } }
        public Rectangle Area { get { return area; } }
    }
}
