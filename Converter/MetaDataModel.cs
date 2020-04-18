using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    /// <summary>
    /// Public Model for the MetaData
    /// </summary>
    public class MetaDataModel
    {
        public string Title { get; set; }
        public string Duration { get; set;  }
        public string Artist { get; set; }
        public Bitmap Image { get; set; }
    }
}
