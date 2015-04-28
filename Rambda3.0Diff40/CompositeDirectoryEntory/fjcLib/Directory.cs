using System;
using SIO =  System.IO;
using System.Collections.Generic;
using System.Collections;
namespace fjcLib
{
	public class Directory:DirectoryEntory,IEnumerable<DirectoryEntory>
	{

		List<DirectoryEntory> _Entorise;
		public Directory (string path,int id=0):base(path,id)
		{
			if(!SIO.Directory.Exists (path))
				throw new ArgumentException("Not Exist at Directory PathName!");


			this.Size = 0;
			_Entorise = new List<DirectoryEntory> ();

			var fils = SIO.Directory.GetFiles (path);
			foreach (var n in fils) {
				_Entorise.Add (new fjcFile (n,id+1));
			}
			//Directoryを登録
			var dirs = SIO.Directory.GetDirectories (path);
			foreach(var p in dirs){
				_Entorise.Add(new Directory (p,id+1));
			}

		}

		public override string ToString ()
		{
			int tabLength = (0 == _CurrentID) ?  0 : _CurrentID - 1;
			return "Directory: \n"+ getDirDeap(tabLength) + base.ToString ();
		}
		public override	void ShowEntryInfo(){

			
			foreach (var n in _Entorise) {
				Console.WriteLine (getDirDeap(_CurrentID) + n.ToString());
				n.ShowEntryInfo();
			}
		}
		#region イテレータの実装

		IEnumerator IEnumerable.GetEnumerator() 
		{ 
			return GetEnumerator(); 
		} 
		public IEnumerator<DirectoryEntory> GetEnumerator(){
			foreach (var dent in _Entorise) {
				yield return dent;
			}
		}

		#endregion
	}
}

