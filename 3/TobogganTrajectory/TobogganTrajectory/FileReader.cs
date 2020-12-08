using System;
using System.Collections.Generic;

namespace TobogganTrajectory
{
    internal class FileReader
    {
        internal IReadOnlyList<string> GetLines()
        {
            string line;
            var lines = new List<string>();

            System.IO.StreamReader file = new System.IO.StreamReader(@"input.txt");
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            file.Close();

            return lines;
        }
    }
}
