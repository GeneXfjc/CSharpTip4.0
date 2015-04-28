using System;
// List<string>
using System.Collections.Generic;
using System.Linq;
//Ping PingReply Object
using System.Net.NetworkInformation;
//IPAddress DNS
using System.Net;
//Task
using System.Threading.Tasks;
using System.Diagnostics;

namespace AsyncPingLinq
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var Pingger = new AsyncPingList ();

			#region testData Input
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("abc.proxyhash.net");
			Pingger.Add("addhaid.com");
			Pingger.Add("amelhost.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			Pingger.Add("www.google.com");
			Pingger.Add("www1.yahoo.co.jp");
			Pingger.Add("www.bing.com");
			Pingger.Add("www22.bing.com");
			#endregion

			var pingger1 = new AsyncPingList ();

			#region testData Input
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("abc.proxyhash.net");
			pingger1.Add("addhaid.com");
			pingger1.Add("amelhost.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			pingger1.Add("www.google.com");
			pingger1.Add("www1.yahoo.co.jp");
			pingger1.Add("www.bing.com");
			pingger1.Add("www22.bing.com");
			#endregion
//			AsyncDoing (Pingger);
//			SyncDoing (Pingger);


//			AsyncDoing (Pingger);
//			SyncDoing (Pingger);
//			Console.WriteLine (	"---------------------------------------------------------------\n\n\n");
//			AsyncDoing (pingger1);
//			SyncDoing (pingger1);
//			AsyncDoing (pingger1);
//			SyncDoing (pingger1);


			#region Havy Process
			var stpw = new Stopwatch ();
//			stpw.Start ();
//			//重い処理なので別スレッドで実施
//			var g1 = Task.Run (() => Pingger.GetPingReplies ());
//			g1.ContinueWith( g => {
//				foreach (var r in  g.Result) {
//					Console.WriteLine ("Sync  {0,-20}\t{1}", r.HostName,
//						(r.Reply == null) ? "DNS Error!" : r.Reply.Status.ToString ());  
//				}
//			} );
//
//			g1.Wait ();
//			stpw.Stop ();
//			Console.WriteLine ("AllWait Done {0,-8}ms\n\n",stpw.ElapsedMilliseconds);
			#endregion
			//問題が発生
			stpw = new Stopwatch ();
			stpw.Start ();
			var pTasks = Pingger.GetPingReplies ();
			pTasks.Wait ();
			var hosts = pTasks.Result.Select (c => c.HostName);
			var replies = pTasks.Result.Select (c => c.Reply).Select (c => (c == null) ? "NG" : c.Status.ToString ());
			foreach(var o in hosts.Zip (replies, (h, r) => new {Host = h,Reply = r})){
				Console.WriteLine ("{0}  {1}", o.Host, o.Reply);
			}

			hosts = pTasks.Result.Select (c => c.HostName);
			replies = pTasks.Result.Select (c => c.Reply).Select (c => (c == null) ? "NG" : c.Status.ToString ());
			foreach(var o in hosts.Zip (replies, (h, r) => new {Host = h,Reply = r})){
				Console.WriteLine ("{0}  {1}", o.Host, o.Reply);
			}

			stpw.Stop();

			Console.WriteLine ("AllWait Done {0,-8}ms\n\n",stpw.ElapsedMilliseconds);

			Console.ReadKey();
		}
		static void SyncDoing(AsyncPingList pingObject){
			var stpw = new Stopwatch ();
			stpw.Start ();
			//同期方式の実行は何らかの値を作成する。
			var pings = pingObject.EnumeHostNames.Select( h => {
				var res = pingObject.GetPingReply(h);
				return new AsyncPingList.PingResult{ HostName = h,Reply = res};

			});
			foreach (var pRes in pings) {
				Console.WriteLine ("Sync  {0,-20}\t{1}", pRes.HostName,
					(pRes.Reply == null) ? "DNS Error!" : pRes.Reply.Status.ToString ());  
			}
			stpw.Stop ();
			Console.WriteLine ("Sync Done {0,-8}ms\n\n",stpw.ElapsedMilliseconds);
		}

		static void AsyncDoing(AsyncPingList pingObject){
			var stpw = new Stopwatch ();
			stpw.Start ();
			var pins = pingObject.EnumeHostNames.Select (async h => {
				var res = await pingObject.GetPingReplyAsync (h);
				Console.WriteLine ("Async {0,-20}\t{1}", res.HostName,
					(res.Reply == null) ? "DNS Error!" : res.Reply.Status.ToString ());  
			});
			var task = Task.WhenAll (pins);
			task.Wait ();
			stpw.Stop ();
			Console.WriteLine ("Async Done {0,-8}ms\n\n",stpw.ElapsedMilliseconds);
		}
	}
}
