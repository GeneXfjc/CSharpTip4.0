using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Base40UseAsync
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var IDs = Enumerable.Range(11, 10);
            var used = new UseClass();
            //Async
            var tasks = IDs.Select(used.AsyncMethod);
            var taskEnume = new AsyncEnumerable<string>(tasks);
            //Sync
            foreach (var item in IDs.Select(i=>used.AsyncMethod(i)))
            {
                    Console.WriteLine (item.Result);
            }
//            for (int i = 0; i < 20; i++)
//            {
//                System.Threading.Thread.Sleep(100);
//            }
            StopWatchWrite(sw, "SyncMethod");

            //Async
            foreach (var item in taskEnume)
            {
                Console.WriteLine(item);
            }
            StopWatchWrite(sw, "EndAsync");
            var taks03 = IDs.Select(i =>
            {
                    var resTask =used.AsyncMethod(i);
                    //なんらかの加工が必要なばい
                    //task処理後のTaskをContinueWith内で処理する。
                    //終了タスクに変更を加える
                    return  resTask.ContinueWith(
                                tRes=> new NameInfo(i,tRes)
                            );
            });
            var Async03 = new AsyncEnumerable<NameInfo>(taks03);
            foreach (var item in Async03)
            {
                Console.WriteLine(item);
            }
        }
        public static void StopWatchWrite(Stopwatch sw,string msg)
        {
            Console.WriteLine("{0}:{1}",msg,sw.ElapsedMilliseconds);
        }

    }
}
