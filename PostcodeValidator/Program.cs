using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace PostcodeValidator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			//Check ();
		}

		/// <summary>
		/// Very rough and ready method used to read in the postcode database downloaded from OS, 
		/// and validate every code as a sanity check for the validation routine and to provide
		/// a reference harness for performance tuning.
		/// </summary>
		private static void Check()
		{
			bool allPassed;
			int count;
			Stopwatch stopWatch = new Stopwatch ();
			long rawParseTimeMs;
			long reformatParseTimeMs;
			long createObjectsTimeMs;
			long validateTimeMs;

			foreach (var f in Directory.GetFiles("/Users/brett/Downloads/codepo_gb/Data/CSV"))
			{
				Console.Write (f);
				allPassed = true;
				count = 0;
				stopWatch.Reset ();
				stopWatch.Start ();

				foreach (var c in File.ReadAllLines(f))
				{
					List<string> codes = new List<string> ();
					codes.Add (c.Split (',') [0]);

				}

				stopWatch.Stop ();
				rawParseTimeMs = stopWatch.ElapsedMilliseconds;


				stopWatch.Reset ();
				stopWatch.Start ();

				foreach (var c in File.ReadAllLines(f))
				{
					List<string> codes = new List<string> ();
					var rawCode = c.Split (',') [0];
					codes.Add (string.Format ("{0} {1}",
						rawCode.Substring (0, rawCode.Length - 4).Trim (), 
						rawCode.Substring (rawCode.Length - 4)));
				}

				stopWatch.Stop ();
				reformatParseTimeMs = stopWatch.ElapsedMilliseconds;

				stopWatch.Reset ();
				stopWatch.Start ();

				foreach (var c in File.ReadAllLines(f))
				{
					List<string> codes = new List<string> ();
					var rawCode = c.Split (',') [0];
					codes.Add (string.Format ("{0} {1}",
						rawCode.Substring (0, rawCode.Length - 4).Trim (), 
						rawCode.Substring (rawCode.Length - 4)));

					var reformattedCode = string.Format ("{0} {1}",
						                      rawCode.Substring (0, rawCode.Length - 4).Trim (), 
						                      rawCode.Substring (rawCode.Length - 4));

					Postcode postcode = new Postcode (reformattedCode);
				}

				stopWatch.Stop ();
				createObjectsTimeMs = stopWatch.ElapsedMilliseconds;

				stopWatch.Reset ();
				stopWatch.Start ();

				foreach (var c in File.ReadAllLines(f))
				{
					List<string> codes = new List<string> ();
					var rawCode = c.Split (',') [0];
					codes.Add (string.Format ("{0} {1}",
						rawCode.Substring (0, rawCode.Length - 4).Trim (), 
						rawCode.Substring (rawCode.Length - 4)));

					var reformattedCode = string.Format ("{0} {1}",
						rawCode.Substring (0, rawCode.Length - 4).Trim (), 
						rawCode.Substring (rawCode.Length - 4));

					Postcode postcode = new Postcode (reformattedCode);

					postcode.Validate ();

					count++;
				}

				stopWatch.Stop ();
				validateTimeMs = stopWatch.ElapsedMilliseconds;

				Console.WriteLine (" - {0}, {1} checked in {2}ms, {3}/s, Raw: {4}, Parse: {5}, Object: {6}, Validate: {7}", 
					allPassed ? "OK" : "Failures", 
					count, 
					stopWatch.ElapsedMilliseconds, 
					((float)count / (float)stopWatch.ElapsedMilliseconds) * 1000,
					rawParseTimeMs,
					reformatParseTimeMs,
					createObjectsTimeMs,
					validateTimeMs);
			}

			Console.ReadKey ();
		}
	}
}
