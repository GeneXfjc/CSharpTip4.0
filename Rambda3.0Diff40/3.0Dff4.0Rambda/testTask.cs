using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace Dff4.Rambda
{
	public class testTask
	{
		public testTask ()
		{

	
		}
		public Task Task_Factory_StartNew(){
			Task task = Task.Factory.StartNew (() => {
				doAction();
				for (int i = 0; i < 30; i++) {
					Console.WriteLine ("Task.Factory!!");
					doActionWithSleep(1);
				}
			});
			//taskが終了したのでそのtaskに対して何らかのことができる。しかもそのスレッド内で
			task.ContinueWith (t => {
				doAction();
				Console.WriteLine ("Stop Task No.{0}",t.Id);
			});
			return task;
		}
		public Task Task_Run(){
			//此れ自体がスレッドと考えていいはず
			Task taskRun = Task.Run (() => {
				doAction();
				for (int i = 0; i < 20; i++) {
					Console.WriteLine("Task.Run!!");
					doActionWithSleep(5);
				}

			});
			taskRun.ContinueWith ((Task arg) => {
				doAction();
				Console.WriteLine ("Stop Task No.{0}",arg.Id);
			});
			return taskRun;
		}
		public void Task_ForEach(){
			//全てのスレッドしゅうりょうまで待機します。
			Task.WaitAll (
				Enumerable.Range (1, 10).AsParallel().Select (i => Task.Factory.StartNew (doActionWithSleep,i)
				).ToArray ()
			);
		}
		public void doAction(){
			Console.WriteLine ("Action:No.{0}",Thread.CurrentThread.ManagedThreadId);
		}
		public void doActionWithSleep(int num){
			doAction ();
			Thread.Sleep (100 * num);
		}
		public void doActionWithSleep(object num){
			doAction ();
			Console.WriteLine (((int)num).ToString());
			for (int i = 0; i < (int)num; i++) {
				Console.WriteLine ("TaskForEach!!");
			}
			Thread.Sleep (100 * (int)num);
		}
	}
}
