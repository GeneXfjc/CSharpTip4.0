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
	//基底クラスにします。
	public class AsyncPingList
	{
		public class PingResult{
			public string HostName { get; set;}
			public IPAddress IPAddress { get; set; }
			public PingReply Reply { get; set;}
		}

		protected List<string> _hostNames;

		public AsyncPingList ()
		{
		}
		#region List操作をこのクラスで纏めています。
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
		public IEnumerable<string> EnumeHostNames{
			get{ return _hostNames; }
		}
		#endregion
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

