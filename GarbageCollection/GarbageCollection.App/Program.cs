// See https://aka.ms/new-console-template for more information
using GarbageCollection;

Console.WriteLine("Hello, World!");

#region MemoryLeakTasks
//InfiniteLoop infiniteLoop = new InfiniteLoop();

//Console.WriteLine(infiniteLoop.AddNumbers());
#endregion

#region GarbageCollectorTasks
string filePath = "C:\\Users\\User\\Desktop\\Learning Programming\\Student\\C#\\GarbageCollection\\MemoryLeak\\InfiniteLoop.cs";
using (FinalizerTask result = new FinalizerTask(filePath))
{
    Console.WriteLine("Using resource ...");
}
GC.Collect();
GC.WaitForPendingFinalizers();

#endregion
