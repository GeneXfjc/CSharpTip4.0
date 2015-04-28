using System;

namespace dotNet4BeginReadEndReadToAsync
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var beAsnc = new BeginEndToAsyncTask ("/bin/ls");
			beAsnc.ReadAsync ();


			Console.ReadKey ();
		}
	}
}
