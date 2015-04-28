using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;

namespace dotNet4.ReadAsync
{
	public class progAsync
	{
		Process _process;
		public progAsync (string cmd,string arg)
		{
			_process = new Process();
			_process.StartInfo = createPSI (cmd,arg);

		}
		private ProcessStartInfo createPSI(string cmd,string arg){
			var res = new ProcessStartInfo ();
			res.Arguments = arg;
			res.FileName = cmd;
			res.UseShellExecute = false;
			res.RedirectStandardOutput = true;
			res.RedirectStandardInput = true;
			res.CreateNoWindow = true;
			return res;
		}
		public StreamReader Start(){
			_process.Start ();
			return _process.StandardOutput;
		}


	}
}

