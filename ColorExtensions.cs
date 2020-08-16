using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Windows.UI;

public static class ColorExtensions
{
    public static string GetName(this Color color) =>
        ColorNameTuples
        .Where(c => c.Item1.Equals(color))
        .Select(c => c.Item2).FirstOrDefault();

    public static Color GetContrastingForegroundColor(this Color c) =>
        c.R * 0.3 + c.G * 0.59 + c.B * 0.11 > 127 ? Colors.Black : Colors.White;

    private static List<Tuple<Color, string>> ColorNameTuples =>
        typeof(Colors).GetRuntimeProperties()
        .Select(p => Tuple.Create((Color)p.GetValue(null), p.Name))
        .ToList();
}