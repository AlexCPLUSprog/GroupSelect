using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GroupSelect
{
    public partial class Form1 : Form
    {
        Point start;
        Point finish;
        Graphics g;
        Rectangle rectangle;
        List<Control> controls_lst = new List<Control>();
        List<AreaComment> comments_lst = new List<AreaComment>();
        private int _counter = 0;
        //private bool MouseDown = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Visible = false;
            start = e.Location;
            //MouseDown = true;
        }
        
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //createMappedArea(sender, e);
            finish = e.Location;
            var size = new Size(Math.Abs((start.X - finish.X)),
                Math.Abs((start.Y - finish.Y)));
            Point _start = new Point(
                start.X < finish.X ? start.X : finish.X,
                start.Y < finish.Y ? start.Y : finish.Y);
            Rectangle _rectangle = new Rectangle(_start, size);
            this.rectangle = _rectangle;
            g = ((Form)sender).CreateGraphics();
            Brush brush = new SolidBrush(Color.Red);
            //g.FillRectangle(brush, _rectangle);
            Pen pen = new Pen(Color.Red, 5);
            //g.DrawRectangle(pen, rectangle);
            listBox1.Items.Clear();
            string name = string.Empty;
            foreach (var item in controls_lst)
            {
                if (item is Button)
                {
                    var loc = ((Button)item).Location;
                    if (rectangle.Contains(loc.X, loc.Y))
                    {
                        listBox1.Items.Add(((Button)item).Text);
                        //this.Update();
                    }
                    //rectangle.IntersectsWith()
                }
            }
            ////MessageBox.Show(name);
        }

        private void addButton(Point _location)
        {
            Button button = new Button();
            button.Text = button.Name = $"button{_counter++}";
            button.Location = _location;
            this.Controls.Add(button);
            controls_lst.Add(button);
        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            addButton(e.Location);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            finish = e.Location;
            textBox1.Clear();
            var size = new Size(Math.Abs((start.X - finish.X)),
                Math.Abs((start.Y - finish.Y)));
            Point _start = new Point(
                start.X < finish.X ? start.X : finish.X,
                start.Y < finish.Y ? start.Y : finish.Y);
            Rectangle _rectangle = new Rectangle(_start, size);
            //this.rectangle = _rectangle;
            textBox1.Visible = true;
            textBox1.Focus();

            textBox1.Enter += (object sender01, EventArgs e01) =>
            {
                var area = new AreaComment(textBox1.Text, _rectangle);
                comments_lst.Add(area);
            };
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //Text = $"{e.X} : {e.Y}";
            foreach (var item in comments_lst)
            {
                if (item.Area.Contains(e.X, e.Y))
                {
                    Text = item.Text;
                }
            }
        }
    }
}
