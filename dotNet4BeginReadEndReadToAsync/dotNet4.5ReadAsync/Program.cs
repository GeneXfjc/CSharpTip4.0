using System;
using System.IO;
using System.Threading.Tasks;

namespace dotNet4.ReadAsync
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var prog = new progAsync ("ls", " -la");
			var streamReader = prog.Start ();
			var task = showresult (streamReader);
			task.Wait ();
			Console.ReadKey ();

		}
		private static async Task showresult(StreamReader sr){
			while (true) {
				string str = await	sr.ReadLineAsync ();
				if (str == null)
					return;
				Console.WriteLine (str);
			}
		}
	}
}
