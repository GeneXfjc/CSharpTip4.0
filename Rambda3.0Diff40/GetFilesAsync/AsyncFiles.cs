using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace GetFilesAsync
{
	public class AsyncFiles
	{
		public AsyncFiles ()
		{
		}
		public async Task<IEnumerable<string>> GetFilesAsync(string dir){
			return await Task.Run<IEnumerable<string>> (() => {
				var files = Directory.GetFiles(dir);
				return files;
			});
		}

	}
}

