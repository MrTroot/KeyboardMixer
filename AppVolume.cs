using System;

namespace KeyboardMixer
{
    class AppVolume
    {
        public string Identifier { get; set; }
        public int Pid { get; set; }
        public Guid Guid { get; set; }
        public float Volume { get; set; }
        public string DisplayName { get; set; }
    }
}
