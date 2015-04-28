using System;
using System.IO;
using System.Collections.Generic;

namespace GetFilesAsync
{
	public class RecursiveDirectories
	{
		string _rootPath;
		public RecursiveDirectories (string root)
		{
			_rootPath = root;
		}
		private IEnumerable<string> GetDirectories(string path){
			foreach (var item in Directory.GetDirectories(path)) {
				yield return item;
				var res = GetDirectories (item);
				foreach (var r in res) {
					yield return r;
				}
			}
		}
		public IEnumerable<string> GetDirectories(){
			return GetDirectories (_rootPath);
		}
	}
}

