using System;
using SIO = System.IO;

namespace fjcLib
{
	public class fjcFile:DirectoryEntory
	{
		public fjcFile (string fName ,int id=0):base(fName,id)
		{

			var f = new SIO.FileInfo (fName);

			this.Size = f.Length;
		}
		public override string ToString ()
		{
			return "File: \n" + getDirDeap(_CurrentID-1) + base.ToString ();
		}
		public override void ShowEntryInfo ()
		{
			return;
		}
	}
}

