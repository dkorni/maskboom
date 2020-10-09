using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Debuger
{
    public static void RadiusCalculationDebug(float gameCoef, double result)
    {
        using (var stringWriter = new StreamWriter("RadiusCalculationStatistic.stats", true))
        {
            stringWriter.WriteLine($"{gameCoef} {result}");
        }
    }
}
