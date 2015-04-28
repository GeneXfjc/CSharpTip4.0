using System;
using fjcLib;
namespace CompositeDirectoryEntory
{
	/* 第一段階
	 * Composite パターンを利用してLinq の利用価値を考える。
	 * 登場Classは抽象クラスの[DirectoryEntory],[Directory],[File]
	 * 集約クラスは[Directory]クラス内にファイルとディレクトリを内包している。
	 * それをそれぞれのクラスで保有するのではなく抽象クラス[DirectoryEntory]で保有することでそれぞれの振る舞いを決定する。
	 * ディレクトリーの中にはデレクとリーとファイルが存在する。
	 */


	class MainClass
	{
		public static void Main (string[] args)
		{
			string rootPath = "/Users/fujic/Projects/Rambda3.0Diff40/CompositeDirectoryEntory/";
			var dir = new Directory (rootPath);

			dir.ShowEntryInfo ();
		}
	}
}
