using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;


namespace GetFilesAsync
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var ints = GettestEnume ();

			foreach (var i in ints) {
				Console.WriteLine (i);

			}

			Console.ReadKey ();
		}
		static void AsyncMethod(){
			var fls = new AsyncFiles ();
			var Dir = new RecursiveDirectories ("/Users/fujic/Documents/");
			var stp = new Stopwatch ();
			stp.Start ();
			var tasks = Dir.GetDirectories ().AsParallel().Select(dir => {
				return Task.Run (async () => {
					var iter = await fls.GetFilesAsync (dir);
					foreach (var f in iter) {
						Console.WriteLine (f);
					}
				});
			}).ToArray ();
			Task.WhenAll (tasks);
			Task.WaitAll (tasks);
			stp.Stop ();
			Console.WriteLine (stp.ElapsedMilliseconds);
			Console.ReadKey ();
			stp = new Stopwatch ();
			stp.Start ();

			foreach (var dir in Dir.GetDirectories()) {
				foreach (var f in Directory.GetFiles(dir)) {
					Console.WriteLine (f);
				}
			}

			stp.Stop ();
			Console.WriteLine (stp.ElapsedMilliseconds);

		}
		static int[] tesAray = new int[]{10,20,30};
		             
		static IEnumerable<int> GettestEnume(){
			return new int[] { 1,2,3};
		}

	}
}
