using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firefox
{
    class RichBoxWriter : TextWriter
    {
        public static RichBoxWriter Instance = new RichBoxWriter();

        public Label control;
        public RichTextBox richTextBox;
        public PictureBox pica;
        public RichBoxWriter()
        {

        }
        public override void Flush()
        {
            _Write(3, "");
           
        }
        public override void WriteLine(string value)
        {
            _Write(1, value);
        }

        public override void Write(string value)
        {
            _Write(0, value);
        }

        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }

        // Generic Write Method

        private void _Write(int i, string text)
        {
            if(i == 0)
            if (!control.IsDisposed)
            {
                Action f = () =>
                {
                    control.Text = (text);
                };

                if (control.InvokeRequired)
                    // Не ждем завершение UI операции.
                    control.BeginInvoke(f);
                else
                    f();
            }
            if (i == 1)
                if (!richTextBox.IsDisposed)
                {
                    Action f = () =>
                    {
                        richTextBox.Text = richTextBox.Text + '\n' +(text);
                        richTextBox.SelectionStart = richTextBox.Text.Length;
                        richTextBox.ScrollToCaret();
                    };

                    if (richTextBox.InvokeRequired)
                        // Не ждем завершение UI операции.
                        richTextBox.BeginInvoke(f);
                    else
                        f();
                }
            if (i == 3)
                if (!pica.IsDisposed)
                {
                    Action f = () =>
                    {
                        pica.Dispose();
                        pica = new PictureBox();
                        pica.Location = new System.Drawing.Point(0, 3);
                        pica.Name = "pictureBox1";
                        pica.Size = new System.Drawing.Size(107, 100);
                        pica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        pica.TabIndex = 0;
                        pica.TabStop = false;

                        Form1.pictureBox1 = (pica);
                    };

                    if (richTextBox.InvokeRequired)
                        // Не ждем завершение UI операции.
                        richTextBox.BeginInvoke(f);
                    else
                        f();
                }
           

        }
    }
}
