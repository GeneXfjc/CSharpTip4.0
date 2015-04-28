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

namespace AsyncPingLinq
{
	/// <summary>
	/// ホスト名を複数保持し非同期でPingの結果を保持します。
	/// 必要に応じて最新のPingの結果も保持します。
	/// </summary>
	public class AsyncPingList 
	{
		public class PingResult{
			public string HostName { get; set;}
			public PingReply Reply { get; set;}
		}

		List<string> _hostNames;

		public AsyncPingList ()
		{
			_hostNames = new List<string> ();
		}
		public void Add(string host){
			if (host == null)
				return;
			if (host == string.Empty)
				return;
			_hostNames.Add (host);
		}
		public void Remove(string host){
			_hostNames = this._hostNames.Where (h => h.Equals(host) == false).ToList ();
		}
		public void Clear(){
			_hostNames.Clear ();
		}

		//AsyncでPingを複数実行する勿論、非同期です。
		public Task<PingResult[]> GetPingReplies(){
			var tasks = _hostNames.Select (async (h, i) => {
				var r = await DoPingAsync (h);
				return new PingResult{ HostName = string.Format ("Async {0:D2} {1}", i, h), Reply = r };
			}).WhenAll ();
			return  tasks;
		}
		public IEnumerable<string> EnumeHostNames{
			get{ return _hostNames; }
		}
		public async Task<PingResult> GetPingReplyAsync(string host){
			var rep =  await DoPingAsync (host);
			return new PingResult{ HostName = host, Reply = rep };
		}
		/// <summary>
		/// SendPingTaskが使えないので自前です。
		/// </summary>
		/// <param name="hostName">Host name.</param>
		private Task<PingReply> DoPingAsync(string host){
//			System.Threading.Thread.Sleep (50);
			IPAddress[] ips;
			IPAddress	ip;
			try {
				ips = Dns.GetHostAddresses (host);
			} catch (Exception) {
				ips = null;
			}
			if (ips == null) {
				//DNSでIPAddressが引けない場合はNullを返す　その際は　as 演算子　で型を明示的にする。
				return Task<PingReply>.Run ( () =>  null as PingReply );

			} else {
				ip = ips [0];
				return  Task<PingReply>.Run(() => {
					using (Ping ping = new Ping ()) {
						return  ping.Send (ip);
					}});

			}
		}

		public PingReply GetPingReply(string host){
//			System.Threading.Thread.Sleep (50);
			IPAddress[] ips;
			IPAddress	ip;
			try {
				ips = Dns.GetHostAddresses(host);
			} catch (Exception) {
				ips = null;
			}
			if (ips == null) {
				return null as PingReply;
			} else {
				ip = ips [0];
				using (Ping p = new Ping ()) {
					return p.Send(ip);
				}
			}
		}
	}
	//拡張LinqでWhenAll()をメソッドチェーン出来ます。
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
}

