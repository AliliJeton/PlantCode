using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace PlantCode
{
    class GetPath
    {
        public static string getPath(ref List<string> lines, string textBoxInput)
        {
            string sourcePathTxt;

            Console.WriteLine("Funktioniert");
            sourcePathTxt = textBoxInput;
            lines = File.ReadAllLines(sourcePathTxt).ToList();
            //lines = lines.ConvertAll(p => p.ToUpper());
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = lines[i].Replace(" ", String.Empty);
            }
            //lines.ForEach(p => p = p.Replace(" ", String.Empty));
            lines.ForEach(p => Console.WriteLine(p));
            return File.ReadAllText(sourcePathTxt);
        }

    }
}
