using System;
using System.Collections.Generic;

namespace fjcLib
{
	public abstract class DirectoryEntory 
	{
		protected	int _CurrentID;
		public long Size {	get; protected set;}
		public string Name{ get; protected set; }
		public DirectoryEntory(string name,int id=0){
			Size = 0;
			Name = name;
			_CurrentID = id;
		}
		public DirectoryEntory():this(""){
		}
		protected string getDirDeap(int length){
			return  new string ('\t', length);
		}
		public override string ToString ()
		{
			return string.Format ("[Size={0:D6}, Name={1,-48}]", Size, Name);
		}
		public abstract void ShowEntryInfo ();

		
	}
}

