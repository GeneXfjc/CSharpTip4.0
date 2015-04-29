using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base40UseAsync
{
    //LinqTask<T>から結果を非同期で列挙します。
    public class AsyncEnumerable<T>:IEnumerable<T>
    {
        List<Task<T>> _Tasks;
        public AsyncEnumerable(IEnumerable<Task<T>> task)
        {
            _Tasks = task.ToList();
        }
        public IEnumerator<T> GetEnumerator()
        {
            var tasks = new List<Task<T>>(_Tasks);
            while (tasks.Count > 0)
            {
                var endTask = Task.WhenAny(tasks);
                var t = endTask.Result;
                tasks.Remove(t);
                yield return t.Result;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() 
        {
            return this.GetEnumerator(); 
        } 
    }
    public class NameInfo
    {
        public NameInfo(int id,string name)
        {
            Index = id;
            _Name = name;
        }
        public NameInfo(int id,Task<string> tname)
        {
            Index = id;
            tName = tname;
        }
        public int Index { get; set; }
        private string _Name;
        public string Name 
        {
            get{ return _Name ?? tName.Result;}
            set{ _Name = value;} 
        }
        public Task<string> tName { get; set; }
        public override string ToString()
        {
            return string.Format("Inde:{0:d3},Name: {1}",Index,Name);
        }
    }
    public class UseClass
    {
        public UseClass()
        {
        }
        public string SyncMethod(int i)
        {
            return string.Format("Name{0:D3}", i);
        }
        public Task<string> AsyncMethod(int i)
        {
            return Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(800);
                return SyncMethod(i);
            });
        }
    }
}

