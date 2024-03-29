﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using XstitchXcelLib;
using XstitchXcelLib.Config;
using XstitchXcelLib.DataClasses;
using XstitchXcelLib.Tools;

namespace XstitchXcelConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Run();
            }
            //catch (Exception e) { Console.WriteLine(e); }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                Console.WriteLine();
                Console.WriteLine("====");
                Console.WriteLine("DONE");
            }
        }
        static void Run()
        {
            //var patternInputFile = @"C:\my\example\file.xlsx";

            //var api = EzApi.LoadPattern(patternInputFile);


            //api.ReportNonDmc();


            //var oldHex = "C00000"; // non dmc
            //var newHex = "BB051F"; // dmc
            //// can replace as targeted or naive
            //// static naive replace also available: no Pattern parsing required
            //api.TargetedReplaceColors(oldHex, newHex);


            //api.PrintStitchStatsReport();


            //api.ConvertToPattern();


            //api.PrintCrtBlurConsole();
            //api.SaveCrtBlurFile();


            //// sort test
            //var list = new List<DmcColorName>
            //{
            //    new DmcColorName(456),
            //    new DmcColorName(123),
            //    new DmcColorName('E', 123),
            //    new DmcColorName("white"),
            //    new DmcColorName("ecru"),
            //    new DmcColorName('C', "ecru"),
            //};
            //list.Sort();


            //analyzePalettes();


            //api.ExcelToPng();


            //api.ExcelToPngResize(5);


            //var dmcColorProcessor = new DmcColorProcessor();
            //var colors = dmcColorProcessor.GetNearestNaive(HelperMethods.HexToColor("475566"))
            //    .Take(5)
            //    .ToList();


            //findMissingColors();
        }

        static void analyzePalettes()
        {
            var dir = "palettes";
            var files = Directory.GetFiles(dir);

            var palettes = Directory
                .EnumerateFiles(dir)
                .Select(file => Newtonsoft.Json.JsonConvert.DeserializeObject<Palette>(File.ReadAllText(file)))
                .ToList();

            var averagePalette = new Palette { Name = "[Average]" };

            static int avgColor(int oldCount, byte oldV, byte newV)
            {
                var ints = Enumerable
                    .Range(0, oldCount)
                    .Select(_ => (int)oldV)
                    .Append(newV)
                    .ToList();
                return (int)Math.Round(ints.Average(), MidpointRounding.AwayFromZero);
            }

            foreach (var (key, value) in palettes.SelectMany(x => x.ColorMap))
            {
                if (key.PaletteType != "DMC")
                    continue;

                var oldKvp = averagePalette.ColorMap.SingleOrDefault(cm => cm.Key.ID == key.ID);
                var notFound = oldKvp.Equals(default(KeyValuePair<PaletteEntry, System.Drawing.Color>));
                if (notFound)
                {
                    averagePalette.ColorMap.Add(new PaletteEntry("DMC", key.ID, "1"), value);
                    continue;
                }

                var oldCount = int.Parse(oldKvp.Key.Name);

                var newR = avgColor(oldCount, oldKvp.Value.R, value.R);
                var newG = avgColor(oldCount, oldKvp.Value.G, value.G);
                var newB = avgColor(oldCount, oldKvp.Value.B, value.B);
                var newValue = System.Drawing.Color.FromArgb(newR, newG, newB);

                averagePalette.ColorMap.Remove(oldKvp.Key);
                averagePalette.ColorMap.Add(
                    oldKvp.Key with { Name = $"{oldCount + 1}" },
                    newValue);
            }
            palettes.Add(averagePalette);

            // compare single color
            var hex = "310";
            Console.WriteLine(hex);
            foreach (var palette in palettes)
            {
                var kvp = palette.ColorMap.SingleOrDefault(cm => cm.Key.ID == hex && cm.Key.PaletteType == "DMC");
                var notFound = kvp.Equals(default(KeyValuePair<PaletteEntry, System.Drawing.Color>));
                if (notFound)
                    continue;

                Console.Write($"{palette.Name.PadRight(24)}\t");
                Console.Write($"{kvp.Value.R}\t");
                Console.Write($"{kvp.Value.G}\t");
                Console.Write($"{kvp.Value.B}\t");
                Console.Write($"{kvp.Value.ToHex()}");

                Console.WriteLine();
            }
        }

        static void findMissingColors()
        {
            var localDmcColors = Configuration.GetDmcColors(true);
            var localDmcNumbers = localDmcColors.Select(d => d.DmcNumber.ToLower()).ToList();

            var dir = "palettes";
            var libidanJson = Directory
                .EnumerateFiles(dir)
                .Select(file => JsonConvert.DeserializeObject<Palette>(File.ReadAllText(file)))
                .Single(p => p.Name == "Lord Libidan")
                .ColorMap;
            var libidanDmcNumbers = libidanJson.Keys.Select(e => e.ID.ToLower()).ToList();

            // get missing entries from palette
            {
                var libidanOnly = libidanDmcNumbers.Except(localDmcNumbers).ToList();
                var missingColors = libidanJson
                    .Where(kvp => libidanOnly.Contains(kvp.Key.ID))
                    .Select(kvp =>
                        new DmcColor
                        {
                            Name = kvp.Key.Name,
                            DmcNumber = kvp.Key.ID,
                            Color = kvp.Value
                        }
                        .ToDmcColorEntry())
                    .ToList();

                // paste into dmc_colors.json
                var json = File.ReadAllText(@"Config\dmc_colors.json");
                var dmcJsonAsList = JsonConvert.DeserializeObject<List<DmcColorEntry>>(json).ToList();
                dmcJsonAsList.AddRange(missingColors);
                var newJson = JsonConvert.SerializeObject(dmcJsonAsList, Formatting.Indented);
            }
        }
    }
}
