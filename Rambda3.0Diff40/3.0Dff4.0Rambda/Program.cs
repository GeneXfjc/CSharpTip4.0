using System;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
//using PingTasks;

namespace Dff4.Rambda
{
	class MainClass
	{
		public async static Task<IEnumerable<PingReply>> tGetPingReplies(IEnumerable<string> hostList)
		{
			var tasks = hostList.Select(host => new Ping().SendPingAsync(host)).ToArray();
			await Task.WhenAll(tasks);
			return tasks.Select(task=>task.Result);

		}
		static void ShowPingResult(PingTasks.PingResult re)
		{
			Console.WriteLine("{0}({1})=\t{2}ms", re.HostName, re.Reply.Address, re.Reply.RoundtripTime);
		}

		public static void Main (string[] args)
		{
			#region PingをTaskで実装してみました。Take1
//			PingginList pin = new PingginList ();
//			pin.Add ("www.google.co.jp");
////			pin.Add ("www2.yahoo.co.jp");
////			pin.Add ("www.yahoo.co.jp");
////			pin.Add ("www.bing.com");
//			List<string> hosts = new List<string> ();
//			hosts.Add ("www.google.co.jp");
//			hosts.Add ("www.bing.com");
//			Ping myPin = new Ping ();
//			var tas = hosts.Select (host =>  myPin.SendPingAsync (host));
//			var tasks = tas.Where(c => c != null).ToArray();
//			Task.WaitAll (tasks);
//			foreach (var t in tasks) {
//				Console.WriteLine (t.Result.ToString ());
//			}
			#endregion

			#region PingをTaskで実装してみました。Take2

			PingTasks.PingTasks ping = new PingTasks.PingTasks();
			ping.Add("www.google.com");
			ping.Add("www.yahoo.co.jp");
			ping.Add("www.bing.com");
			ping.Add("www1.yahoo.co.jp");

			//var tsk = ping.GetFastest();
			//tsk.Wait();
			//PingResult pr = tsk.Result;
			//ShowPingResult(pr);

			Console.WriteLine("-------------------------------");
			var ts = ping.GetPingTasks();
			//ts.Wait();
			foreach (var item in ts.Result)
			{
				if(item != null)
					Console.WriteLine(item.Address);
			}
			var t = ping.GetAllResult();
			t.Wait();
			foreach (var item in t.Result)
			{
				ShowPingResult(item);
			}
			ping.RePing();
			Console.WriteLine("------------ RePing -------------------");

			t = ping.GetAllResult();
			t.Wait();
			foreach (var item in t.Result)
			{
				ShowPingResult(item);
			}
			#endregion
		}

	}
}
