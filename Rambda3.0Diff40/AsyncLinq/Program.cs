using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace AsyncLinq
{
	// mono/.Net4.5で記述しています。
	// こういう拡張メソッドを定義しておけば
	// Linqの拡張メソッド
	public static class TaskEnumerableExtensions
	{
		public static Task WhenAll(this IEnumerable<Task> tasks)
		{
			return Task.WhenAll(tasks);
		}

		public static Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> tasks)
		{
			return Task.WhenAll(tasks);
		}
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			var empEnum = Enumerable.Empty<int> ();
			foreach (var i in empEnum) {
				var k = i;
				Console.WriteLine (k.ToString());
			}
			var stopwatch = new Stopwatch ();
			var IDs = Enumerable.Range (1, 100);
			//同期バージョンで 1〜50で2820ms
			stopwatch.Start ();
			var list =IDs.AsParallel().Select (i => new { ID = i,Name = GetName (i)}).ToList ();
			foreach (var item in list) {
				Console.WriteLine ("{0:D2} : {1}",item.ID,item.Name);
			}
			stopwatch.Stop ();
			Console.WriteLine ("--------------同期の経過時間{0}ms---------------------",stopwatch.ElapsedMilliseconds);
			stopwatch = new Stopwatch ();

			//非同期バージョンで　1〜50で1038ms 100ms X 50回で5000msになるはずが2/5になっている。
			stopwatch.Start ();
			var listAync =   Task.WhenAll( IDs.Select(async (a) => new {ID = a, Name = await GetNameAsync(a)}));
			listAync.Wait ();
			foreach (var t in listAync.Result) {
				Console.WriteLine ("{0:D2} : {1}",t.ID,t.Name);
			}
			stopwatch.Stop ();
			Console.WriteLine ("--------------非同期の経過時間{0}ms---------------------",stopwatch.ElapsedMilliseconds);
			stopwatch = new Stopwatch ()
			            ;
			//非同期バージョンで
			//拡張メソッドでスッキリ書ける 1〜50で812ms 本来なら5000msが拡張メッソドを使うことで1/5
			stopwatch.Start ();
			listAync = IDs.Select (async (a) => new {ID = a, Name = await GetNameAsync (a)}).WhenAll ();
			//listAync.ResultがWait()と同等となる。
			//そもそもWhenAll()の意味するところは　=> 
			foreach (var t in listAync.Result) {
				Console.WriteLine ("{0:D2} : {1}",t.ID,t.Name);
			}
			stopwatch.Stop ();
			Console.WriteLine ("--------------非同期の経過時間{0}ms---------------------",stopwatch.ElapsedMilliseconds);
			stopwatch = new Stopwatch ();

			//非同期で尚かつパラレルで実施必ず待たなければならないWait()必須
			//1から50で623ms
			stopwatch.Start ();
			var array = IDs.Select (async (s) => {
				Console.WriteLine ("{0:D2} : {1}",s,await GetNameAsync (s) );
			}).WhenAll ();
			array.Wait();
			stopwatch.Stop ();
			Console.WriteLine ("--------------非同期の経過時間{0}ms---------------------",stopwatch.ElapsedMilliseconds);
			stopwatch = new Stopwatch ();
			Console.ReadKey();
			//array.Wait();

			 
		}
//		static IEnumerable<Task<string>> GetEnumerableNameAsync(IEnumerable rng){
//			foreach
//		}

		static string GetName(int i){
			System.Threading.Thread.Sleep (100);
			return string.Format ("HogeHoge{0:D2}", i);
		}
		async static Task<string> GetNameAsync(int i){
			await Task.Delay (TimeSpan.FromMilliseconds (100));
			return string.Format ("HogeHoge{0:D2}", i);
		}


	}
}
