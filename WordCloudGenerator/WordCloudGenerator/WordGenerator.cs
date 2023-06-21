using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCloudGenerator
{
    public class WordGenerator
    {

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
