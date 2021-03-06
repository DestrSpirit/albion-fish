//using System;
//using System.Collections.Generic;
using System;
using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Threading;
using System.Windows.Forms;
using wintool;
//using System.Threading.Tasks;


namespace firefox
{
    class Threads : Form1
    {
        static KeyboardControl keyboard = new KeyboardControl();
        static MouseControl mouse = new MouseControl();
        static Util util = new Util(); 
        static Util util1 = new Util();

        static Point bobber = new Point();
        static int dif = 0;
        static Bitmap cursor = new Bitmap("action.png");
        static Bitmap b = new Bitmap("save.png");
        //isfishing? loop
        public void isaction()
        {
            while (true)
                try
                {
                    GC.Collect();
                    Globals.isAction = util.isOnImage(MouseCapturer.Capture(), cursor, .98);
                    Thread.Sleep(55);
                }
                catch { }
        }
        public void bot()
        {
            while (true)
            {
                //bobber xy to 0x0
                bobber = new Point();

                //if reached last spot start again
                if (Globals.i >= Globals.d1x.Count)
                    Globals.i = 0;

                //move on spot and press lmb
                mouse.MouseMoveTo(Globals.d1x[Globals.i],
                                  Globals.d1y[Globals.i]);
                mouse.MousePress();

                //wait for charge rod and realease lmb
                util.Waiter(Globals.d1x[Globals.i],
                            Globals.d1y[Globals.i]);
                mouse.MouseRelease();
                b.Dispose();
                b = new Bitmap("save.png");
                //optional
                Thread.Sleep(1000);
                //find bobber pic
                b = util1.CaptureScreenfd();

                //optional
                Thread.Sleep(600);
                //locate bobber xy
                bobber = util.LocateOnScreen(b, 0.6);
                //continue if doesnt exists
                if (bobber.X < 1)
                {
                    Thread.Sleep(1000);
                    continue;
                }
                //optional 

                //bobbers position difference to catch
                dif = bobber.Y + 6;
                for (int i = 0; i < 1200; i++)
                {
                    //bobber xy 
                    bobber = util.LocateOnScreen(b, 0.7);
                    //debug
                    Console.Write(bobber.Y.ToString());
                    //if <diff - continue
                    if (bobber.Y < dif && bobber.Y != 0)
                    {
                        continue;
                    }
                    //act for qte
                    mouse.MouseClick();
                    Thread.Sleep(200);

                    for (int a = 0; a < 1200; a++)
                    {
                        if (!Globals.isAction) break;

                        //color at midl qte progress bar 
                        Color c = util.GetColorAt(955, 550);
                        if (c.G > 150)
                            mouse.MouseRelease();
                        else
                            mouse.MousePress();
                    }

                    break;
                }
                Globals.counter++;
                Thread.Sleep(2000);
                mouse.MouseRelease();
                keyboard.fastkey("x");
                b.Dispose();
                Globals.i++;

            }
        }
    }
}
