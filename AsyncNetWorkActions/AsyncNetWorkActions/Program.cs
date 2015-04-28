using System;
using AsyncPingLinq;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace AsyncNetWorkActions
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//var pings = new AsyncPingFromSync ();
			var pings = new AsyncPingFromEvent ();

			#region AddData

			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("abc.proxyhash.net");
			pings.Add("addhaid.com");
			pings.Add("amelhost.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("www1.yahoo.co.jp");
			pings.Add("www.bing.com");
			pings.Add("www22.bing.com");
			pings.Add("www.google.com");
			pings.Add("resolver2.level3.net");
			pings.Add("resolver1.level3.net");
			pings.Add("google-public-dns-b.google.com");
			pings.Add("google-public-dns-a.google.com");
			pings.Add("ns2.recursive.dns.com");
			pings.Add("ns1.recursive.dns.com");
			pings.Add("resolver2.opendns.com");
			pings.Add("resolver1.opendns.com");
			pings.Add("rdns2.ultradns.net");
			pings.Add("rdns1.ultradns.net");
			pings.Add("rdns2.ultradns.net");
			pings.Add("rdns1.ultradns.net");
			pings.Add("209-88-198-133.bb.netvision.net.il");
			pings.Add("bzq-218-119-11.red.bezeqint.net");
			pings.Add("dns2.safedns.com");
			pings.Add("dns1.safedns.com");
			pings.Add("dns1.safedns.com");
			pings.Add("dementia.virtual-dope.com");
			pings.Add("mx1.sourpuss.net");
			#endregion


//			var pTasks = pings.GetPingReplies ();
//
//			var hosts = pTasks.Result.Select (c => c.HostName);
//			var replies = pTasks.Result.Select (c => c.Reply).Select (c => (c == null) ? "NG" : c.Status.ToString ());
//			foreach(var o in hosts.Zip (replies, (h, r) => new {Host = h,Reply = r})){
//				Console.WriteLine ("{0}  {1}", o.Host, o.Reply);
//			}


			var stpw = new Stopwatch ();
			stpw.Start ();
			var piTasks = pings.DoPingReplies ();
			ShowWhenAll(piTasks);
			stpw.Stop ();
			Console.WriteLine ("{0}ms",stpw.ElapsedMilliseconds);

			Console.WriteLine (new string('-',80));


			var pings02 = new AsyncPingFromEvent ();
			#region AddData

			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("abc.proxyhash.net");
			pings02.Add("addhaid.com");
			pings02.Add("amelhost.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("www1.yahoo.co.jp");
			pings02.Add("www.bing.com");
			pings02.Add("www22.bing.com");
			pings02.Add("www.google.com");
			pings02.Add("resolver2.level3.net");
			pings02.Add("resolver1.level3.net");
			pings02.Add("google-public-dns-b.google.com");
			pings02.Add("google-public-dns-a.google.com");
			pings02.Add("ns2.recursive.dns.com");
			pings02.Add("ns1.recursive.dns.com");
			pings02.Add("resolver2.opendns.com");
			pings02.Add("resolver1.opendns.com");
			pings02.Add("rdns2.ultradns.net");
			pings02.Add("rdns1.ultradns.net");
			pings02.Add("rdns2.ultradns.net");
			pings02.Add("rdns1.ultradns.net");
			pings02.Add("209-88-198-133.bb.netvision.net.il");
			pings02.Add("bzq-218-119-11.red.bezeqint.net");
			pings02.Add("dns2.safedns.com");
			pings02.Add("dns1.safedns.com");
			pings02.Add("dns1.safedns.com");
			pings02.Add("dementia.virtual-dope.com");
			pings02.Add("mx1.sourpuss.net");
			#endregion
			stpw = new Stopwatch ();
			stpw.Start ();
			var pTasks = pings02.DoPingReplies();
			ShowWhenAll(pTasks);
			stpw.Stop ();
			Console.WriteLine("{0}ms",stpw.ElapsedMilliseconds);
		}
		static async void  ShowWhenAll(IEnumerable<Task<AsyncPingList.PingResult>> tasks){
			var tempTasks = tasks.ToArray ();
			var results = await Task.WhenAll (tempTasks);

			foreach (var ipEnt in results) {
				string stat;
				long? miliSec;
				if (ipEnt.Reply == null) {
					stat = null;
					miliSec = null;
				}else{
					stat = ipEnt.Reply.Status.ToString();
					miliSec = ipEnt.Reply.RoundtripTime;
				}
				Console.WriteLine ("{0,-24} \tis {1,15} Stat:{2,8} Time:{3}", ipEnt.HostName, ipEnt.IPAddress, stat,miliSec);

			}
		}

		static async void  ShowWhenAny(IEnumerable<Task<AsyncPingList.PingResult>> tasks){
			//IEnumerable<Task<T>> を　ToList()でList<Task<T>>でインスタンス化
			var tmpTasks = tasks.ToList();
			while (tmpTasks.Count > 0) {
				//次に終了したTaskを待つ
				var res = await Task.WhenAny(tmpTasks);
				//Listから削除する。
				tmpTasks.Remove (res);
				//以下は必要なデータに対する処理
				var data = await res;
				string stat;
				long? miliSec;
				if (data.Reply == null){
					stat = null;
					miliSec = null;
				}else{
					stat = data.Reply.Status.ToString();
					miliSec = data.Reply.RoundtripTime;
				}
				Console.WriteLine ("{0,-24} \tis {1,15} Stat:{2,8} Time:{3}", data.HostName, data.IPAddress, stat, miliSec);
			}
		}
	}
}


