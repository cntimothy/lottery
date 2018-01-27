using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormsApplication1
{
    class FileUtils
    {
        public static List<string> readFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            List<string> content = new List<string>();
            string line;
            while ((line = sr.ReadLine()) != null) 
            {
                content.Add(line);
            }
            sr.Close();
            return content;
        }

        public static void writeFile(String path, List<string> content)
        {
            StreamWriter sw = new StreamWriter(path, true);
            foreach (String line in content)
            {
                sw.WriteLine(line);
            }
            sw.Flush();
            sw.Close();
        }
    }
}
