using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Dff4.Rambda
{

	 
	class PingResult{
		public PingResult(string s,bool b){
			Uri = s;
			Result = b;
		}
		public string Uri {
			get;
			private set;
		}
		public bool Result {
			get;
			private set;
		}
	}
	/// <summary>
	/// Pinggin Use .Net4.5 Ping.SendPingAsync() for await
	/// </summary>
	public class PingginList
	{
		public event EventHandler SendResult;
		public event Action<string ,bool > SendResult2;

		public List<string> _pings;
		Ping _pinger;

		public PingginList ()
		{
			_pings = new List<string> ();
			_pinger = new Ping ();
			//Regist AsyncEvent
			_pinger.PingCompleted += (object sender, PingCompletedEventArgs e) => {
				if(SendResult2 !=null){
					bool r=false;
					if(e.Reply.Status==IPStatus.Success)
						r = true;

					SendResult2(e.Reply.Address.ToString(),r);
				}
			};
		}

		public IEnumerable PingList{
			get{ return _pings; }
		}
		public void Add(string uri){
			this._pings.Add(uri);
		}


		/// <summary>
		//AsParallel()を利用してPingタスクを作成
		/// </summary>
		public void AsParallelPings(){
			Task.WaitAll (
				_pings.AsParallel ().Select (uri => Task.Factory.StartNew (doAsyncEventPing, uri)).ToArray ()
			);
		}
		#region DoAsyncEventPing

		/// <summary>
		/// Dos the async event ping.
		/// </summary>
		/// <param name="u">U.(uri)</param>
		private void doAsyncEventPing(object u){
			string uri = (string)u;
			doAsyncEventPing (uri);
		}
		/// <summary>
		/// Dos the async event ping.
		/// </summary>
		/// <param name="uri">URI.</param>
		void doAsyncEventPing(string uri){

			try {
				_pinger.SendAsync(uri,null);
			} catch (System.Net.Sockets.SocketException ex) {
				System.Diagnostics.Debug.WriteLine (ex.Message);
			} 
		}
		#endregion

		/// <summary>
		/// AsyncEventPings
		/// </summary>
		public void DoAsyncEventPings()
		{
			foreach (var uri in _pings) {
				this.doAsyncEventPing (uri);
				//Task.WaitAny (res);
			}
		}

		public   void ResultEnume(){
			foreach (var uri in _pings) {
				var pintask =  new Task<int>( ()=> {
					Task<PingReply> res = _pinger.SendPingAsync (uri);
					//await Task.Delay (500);
					if(res != null){
						if ( res.Result.Status == IPStatus.Success)
							return 1;
					}
					return 0;
				});
				pintask.Start ();

				pintask.ContinueWith ((Task<int> arg) => {
					int k = arg.Result;
					Console.WriteLine (k.ToString());
				});
			}
		}
		public async Task<string> GetFastest()
		{
		
			var replies = await GetPingReplies();
			var hostsAndReplies = 
				_pings.Zip(replies, (host, reply) => new{host,reply});
			var fastest=
				hostsAndReplies
					.Where(x => x.reply.Status == IPStatus.Success)
					.OrderBy(x => x.reply.RoundtripTime)
					.FirstOrDefault();
			return fastest == null ? null : fastest.host;
		}
		public async Task<IEnumerable<PingReply>> GetPingReplies()
		{
			var tasks = _pings.Select(host => new Ping().SendPingAsync(host)).ToArray();
			await Task.WhenAll(tasks);
			return tasks.Select(task=>task.Result);

		}
		public void ResultPingging(){
//			var reslist =	_pings.Select (
//				uri => Task.Factory.StartNew<Task<bool>> (doAsyncEventPing, uri)
//			           ).ToArray ();
//			Task.WaitAll (reslist);
//			foreach (var s in reslist) {
//				var r = s.Result;
//				r.Wait ();
//				Console.WriteLine (r.Result.ToString());
//			}

		}
//		async Task<bool> doAsyncPing(object u){
//			string uri = (string)u;
//			Task<PingReply> res = await _pinger.SendPingAsync (uri);
//			//res.Wait ();
//			//await Task.Delay (500);
//			PingReply tmp = await res.Result;
//			if(await tmp != null){
//				if ( tmp.Status == IPStatus.Success)
//					return true;
//			}
//			return false;
//		}
	}
}

