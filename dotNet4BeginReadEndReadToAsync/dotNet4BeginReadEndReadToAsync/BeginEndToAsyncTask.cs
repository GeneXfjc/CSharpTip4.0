using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Text;

namespace dotNet4BeginReadEndReadToAsync
{
	public class BeginEndToAsyncTask
	{
		string _Command;
		public BeginEndToAsyncTask (string cmd)
		{
			_Command = cmd;
		}
		private ProcessStartInfo createProcessSInf(){
			ProcessStartInfo resPSInf = new ProcessStartInfo ();
			resPSInf.FileName = _Command;
			resPSInf.RedirectStandardInput = false;
			resPSInf.RedirectStandardOutput = true;
			resPSInf.CreateNoWindow = true;
			resPSInf.UseShellExecute = false;
			return resPSInf;
		}
		private Process createProcess(){
			var prs = new Process ();
			prs.StartInfo = createProcessSInf ();
			return prs;
		}
		public void ReadAsync(){
			byte[] buff = new byte[1024];
			StringBuilder sb = new StringBuilder ();
			var cts = new TaskCompletionSource<string>();
			using (var pro = new Process ()) {
				pro.StartInfo = createProcessSInf ();
				pro.Start ();
				pro.BeginOutputReadLine ();
				System.IO.Stream outStream = null;

//				var resInt = Task<int>.Factory.FromAsync (
//					pro.StandardOutput. ,
//					pro.StandardOutput.BaseStream.EndRead,
//					            buff, 0, buff.Length, null);

//				resInt.ContinueWith (task => {
//				while (outStream.CanRead) {
//					var res = task.Result;
//					if (res < buff.Length) {
//						Array.Resize (ref buff, res);
//					}
//					sb.Append (Encoding.GetEncoding ("UTF-8").GetString (buff));
//				}});
				Console.WriteLine (sb.ToString());
				}
		}

	}
}

