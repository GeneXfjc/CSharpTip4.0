using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;


namespace PingTasks
{
	public class PingResult
	{
		public string HostName { get; set; }
		public PingReply Reply { get; set; }
	}
	public class PingTasks
	{
		List<string> _hosts;
		Task<PingReply>[] _pingTasks;
		public PingTasks()
		{
			_hosts = new List<string>();
			_pingTasks = null;
		}
		public void Add(string s)
		{
			_hosts.Add(s);
		}
		//ホスト名一覧から非同期タスクをまとめる。
		public async Task<IEnumerable<PingReply>>  GetPingTasks(){
			if (_pingTasks == null)
			{
				//_pingTasks = _hosts.Select(h => new Ping().SendPingAsync(h)).ToArray();
				_pingTasks = testPingTasks().ToArray();
			}
			await Task.WhenAll(_pingTasks);
			return _pingTasks.Select(task => (task == null)? null : task.Result);
		}
		//yieldでTask<PingReply>を返す。
		//名前解決ができない場合はlocalhostのTask<PingReply>を返す。
		public IEnumerable<Task<PingReply>> testPingTasks(){
			foreach (var host in _hosts)
			{
				var p = new Ping();
				System.Net.IPAddress[] ips;
				try
				{
					ips = System.Net.Dns.GetHostAddresses(host);
				}
				catch
				{
					ips = null;
				}
				yield return (ips == null) ? p.SendPingAsync("127.0.0.1") : p.SendPingAsync(host);
			}
		}
		public async Task<IEnumerable<PingResult>> GetAllResult()
		{
			var replies = await GetPingTasks();
			var hostAndReplies = 
				_hosts.Zip(replies,(host,reply)=> new PingResult{ HostName = host, Reply = reply });
			return hostAndReplies;
		}
		public async Task<PingResult> GetFastest()
		{
			var replies = await GetPingTasks();
			var hostsAndReplies =
				_hosts.Zip(replies, (host, reply) => new { host, reply });
			var fastest =
				hostsAndReplies
					.Where(x => x.reply.Status == IPStatus.Success)
					.OrderByDescending(x => x.reply.RoundtripTime)
					.FirstOrDefault();
			return fastest == null ? null : new PingResult { HostName = fastest.host, Reply = fastest.reply };
		}

		internal void RePing()
		{
			//_pingTasks = _hosts.Select(h => new Ping().SendPingAsync(h)).ToArray();
			_pingTasks = testPingTasks().ToArray();
		}
	}
}