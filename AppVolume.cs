using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardMixer
{
    class AppVolume
    {
        public string Identifier { get; set; }
        public int Pid { get; set; }
        public Guid Guid { get; set; }
        public float Volume { get; set; }
    }
}
