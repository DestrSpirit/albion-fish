using System.Collections.Generic;
using System.Drawing;

namespace firefox
{
    public static class Globals
    {
        public static int i = 0;
        // 960x790-b-0, 1280x540-r-1, 545x540-l-2, 960x260-t-3
        public static double confidance = 0.8;
        public static List<Point> corrections = new List<Point> { new Point(840, 735),
                                                                  new Point(1210, 540),
                                                                  new Point(720, 540),
                                                                  new Point(960, 315)};
        public static List<int> d1x = new List<int> {   377, 1530, 480 };
        public static List<int> d1y = new List<int> {   380, 650, 960 };

        public static bool stopvar = false;
        public static int counter = 0;
        internal static bool isAction = false;
        
    }
}
