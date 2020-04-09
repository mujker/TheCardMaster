using System.Drawing;
using System.Windows.Forms;

namespace TheCardMaster
{
    public class CardConfig
    {
        public int ArgbYellowCard { get; set; }
        public int ArgbBlueCard { get; set; }
        public int ArgbRedCard { get; set; }

        public int KeyYellow { get; set; }
        public int KeyBlue { get; set; }
        public int KeyRed { get; set; }        
        
        public int CardPositionX { get; set; }
        public int CardPositionY { get; set; }

        public int KeyBlank { get; set; }
        public int TimeOut { get; set; }
    }
}