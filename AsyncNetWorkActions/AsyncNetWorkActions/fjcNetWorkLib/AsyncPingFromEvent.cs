using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net;

namespace AsyncPingLinq
{
	public class AsyncPingFromEvent: AsyncPingList
	{
		public AsyncPingFromEvent ()
		{
			_hostNames = new List<string> ();

		}
		private IEnumerable<byte> GetByteArray(int length){
			var buffquery = Enumerable.Range ('a', 26).Select (c => (byte)c);
			for (int i = 0; i < length; ) {
				foreach (var item in buffquery) {
					yield return item;
					i++;
				}
			}
		}
		/// <summary>
		/// 複数のIPAddressを問い合わせる。
		/// </summary>
		/// <returns>The IP entrise.</returns>
		public  IEnumerable<Task<PingResult>> GetIPEntrise(){
			return  _hostNames.Select (async host => {
				try {
					var res = await Dns.GetHostEntryAsync(host);
					return new PingResult{ HostName = host,IPAddress =   res.AddressList[0]};
				} catch (Exception) {
					return new PingResult{HostName = host,IPAddress = null};
				}
			});
		}
		/// <summary>
		/// IPAddressを複数取得しPingを実施してPingResultを返す。
		/// </summary>
		/// <returns>The ping replies.</returns>
		public IEnumerable<Task<PingResult>> DoPingReplies(){
			return GetIPEntrise ().Select (async c => {
				var res = await DoPing (c.Result.IPAddress);
				c.Result.Reply = res;
				return c.Result;
			});
		}
		/// <summary>
		/// Event型のPingAsync を変更して　sync/awaitに変更します。
		/// </summary>
		/// <returns>The ping.</returns>
		/// <param name="ipAdd">Ip add.</param>
		private Task<PingReply> DoPing(IPAddress ipAdd){
			//空のタスクを返す
			if (null == ipAdd)
				return Task.Run (() => null as PingReply);

			TaskCompletionSource<PingReply> tcs = new TaskCompletionSource<PingReply> ();
			Ping pi = new Ping ();
			pi.PingCompleted += (sender, e) => {
				if(e.Error != null) tcs.SetException(e.Error);
				else if (e.Cancelled)tcs.SetCanceled();
				else tcs.SetResult(e.Reply);
			};
			var buff = GetByteArray (3200).ToArray ();
			pi.SendAsync (ipAdd,2000,buff, null);
			return tcs.Task;
		}
		private Task<IPAddress> GetIPAddress(string host){
			return null as Task<IPAddress>;
		}
		static Task<string> DownloadStringAsTask(Uri address) {
			TaskCompletionSource<string> tcs = 
				new TaskCompletionSource<string>();
			WebClient client = new WebClient();
			client.DownloadStringCompleted += (sender, args) => {
				if (args.Error != null) tcs.SetException(args.Error);
				else if (args.Cancelled) tcs.SetCanceled();
				else tcs.SetResult(args.Result);
			};
			client.DownloadStringAsync(address);
			return tcs.Task;
		}
	}
}

