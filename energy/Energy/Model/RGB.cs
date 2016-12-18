using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct RGB
    {
        public byte R;
        public byte G;
        public byte B;

        public RGB(byte r, byte g, byte b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }
    }
}
