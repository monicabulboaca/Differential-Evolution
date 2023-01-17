using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEAlgorithm.FileData;

public class ReadFromFile
{
    public static string[] symbolsGenes = { "B", "F", "P", "F", "C", "P", "B", "L", "Lg", "Lg", "C", "B", "C", "P", "Lg", "F", "Lg" };
    private static Random _rand = new Random();

    public static double[] readKcal()
    {
        double[] kcals = new double[17];

        for(int i = 0; i < symbolsGenes.Length; i++)
        {
            var columnName = symbolsGenes[i];
            var fileName = ".\\" +  columnName + ".txt";
            string[] fileLines = System.IO.File.ReadAllLines(fileName);
            string[] kcList = new string[fileLines.Length];
            for(var j = 0; j < fileLines.Length; j++)
            {
                var lines = fileLines[j].Split(" ");
                var kc = lines[2];
                kcList[j] = kc;
            }

            kcals[i] = double.Parse(kcList[_rand.Next(fileLines.Length)]);
        }
        return kcals;
    }
}
