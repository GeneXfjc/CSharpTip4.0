using System;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;


namespace Dff4.Rambda
{
	/// <summary>
	/// Parallel for dotNet4.0
	/// </summary>
	public class tesParallel
	{
		static void Method(int i){
			Thread.Sleep ((100 - i )* 100);
			Console.WriteLine ("私は{0}番目のパラレル！",i);
		}
		public static void tMain (string[] args)
		{
			Action<int> act = c => {
				Thread.Sleep ((100 - c) * 10);
				Console.WriteLine ("私は{0}番目のパラレル！", c);
			};

			Parallel.For (2,10, act);
		}
	}

}

