using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    /// <summary>
    /// Public Inteface of the API
    /// </summary>
    public interface IConvert
    {
        Task ConvertAsync(string url, string outputFolder, IProgress<string> Status, IProgress<double> progress, IProgress<bool> Completed); 
    }
}
