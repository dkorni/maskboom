using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameMath
{
    /// <summary>
    /// Калькулирует сложность игровых процессов.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="humpHeightCoefficient">Высота горба.</param>
    /// <param name="humpWidthCoefficient">Длина горба.</param>
    /// <param name="offset">Расстояние между правой нижней точкой горба и абсциссы.</param>
    /// <returns></returns>
    public static float CalculateComplexity(float x,
        float humpHeightCoefficient, float humpWidthCoefficient, float offset)
    {
        // определяем ширину и высоту горба
        var result = Mathf.Pow(x, 2) * Mathf.Sin(humpWidthCoefficient * x) * humpHeightCoefficient;

        result = result / x;

        // считаем модуль
        result = Mathf.Abs(result);

        // приподымаем нижнюю правую точку горба над абсциссой
        result = result + x / (Mathf.PI * offset);

        return result;
    }

    /// <summary>
    /// Calculates the logarithmic complexity.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="o">The o.</param>
    /// <param name="b">The b.</param>
    /// <returns></returns>
    public static float CalculateLogarithmicComplexity(float x, float o, float b)
    {
        var result = Mathf.Log(x + o) * b;
        return result;
    }
}
