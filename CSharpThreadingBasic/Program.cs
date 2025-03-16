// See https://aka.ms/new-console-template for more information

#region single thread example
// single thread example
//Method1();
//Method2();
//Method3();
#endregion 

#region multi thread example
// multi thread example

//Console.WriteLine("Main Thread Started");
////Creating Threads
//Thread t1 = new Thread(Method1)
//{
//    Name = "Thread1"
//};
//Thread t2 = new Thread(Method2)
//{
//    Name = "Thread2"
//};
//Thread t3 = new Thread(Method3)
//{
//    Name = "Thread3"
//};
////Executing the methods
//t1.Start();
//t2.Start();
//t3.Start();

//Console.WriteLine("All the methods processed");
#endregion

#region async programming with sequentially process
// async programming with sequentially process, it can run single or multiple thread but it handled by automatically
//Console.WriteLine("Main execution started " + Thread.CurrentThread.ManagedThreadId);
//await Method1Async();
//await Method2Async();
//await Method3Async();
#endregion 

#region async programming with concurrent process 
// async programming with concurrent process, it can run single or multiple thread but it handled by automatically

// Best for network calls, database queries, and file I/O.

var method1Task = Method1Async();
var method2Task = Method2Async();
var method3Task = Method3Async();

await Task.WhenAll(method1Task, method2Task, method3Task);

Console.WriteLine("Complete it");
#endregion

#region Parallel for paralle processing
// Automatically distributes work across multiple CPU cores, cores is important for fast processing it.
// Uses Task Parallel Library (TPL) for better performance.
var names = new List<string>() { "string1", "string2", "string3" };
Parallel.ForEach(names, x => Console.WriteLine(x));
#endregion

static async Task Method1Async()
{
    Console.WriteLine("Method1 Started using " + Thread.CurrentThread.ManagedThreadId);
    for (int i = 1; i <= 5; i++)
    {
        await Task.Delay(1000);
        Console.WriteLine("Method1 delayed processed " + Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("Method1 :" + i);
    }
    Console.WriteLine("Method1 Ended using " + Thread.CurrentThread.ManagedThreadId);
}
static async Task Method2Async()
{
    Console.WriteLine("Method2 Started using " + Thread.CurrentThread.ManagedThreadId);
    for (int i = 1; i <= 5; i++)
    {
        if (i == 3)
        {
            Console.WriteLine("Performing the Database Operation Started");
            await Task.Delay(100000);
            Console.WriteLine("Performing the Database Operation Completed");
        }
    }
    Console.WriteLine("Method2 Ended using " + Thread.CurrentThread.ManagedThreadId);
}
static async Task Method3Async()
{
    Console.WriteLine("Method3 Started using " + Thread.CurrentThread.ManagedThreadId);
    for (int i = 1; i <= 5; i++)
    {
        await Task.Delay(1);
        Console.WriteLine("Method3 :" + i);
    }
    Console.WriteLine("Method3 Ended using " + Thread.CurrentThread.ManagedThreadId);
}

static void Method1()
{
    Console.WriteLine("Method1 Started using " + Thread.CurrentThread.Name);
    for (int i = 1; i <= 5; i++)
    {
        Thread.Sleep(1000);
        Console.WriteLine("Method1 :" + i);
    }
    Console.WriteLine("Method1 Ended using " + Thread.CurrentThread.Name);
}
static void Method2()
{
    Console.WriteLine("Method2 Started using " + Thread.CurrentThread.Name);
    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine("Method2 :" + i);
        if (i == 3)
        {
            Console.WriteLine("Performing the Database Operation Started");
            //Sleep for 10 seconds
            Thread.Sleep(10000);
            Console.WriteLine("Performing the Database Operation Completed");
        }
    }
    Console.WriteLine("Method2 Ended using " + Thread.CurrentThread.Name);
}
static void Method3()
{
    Console.WriteLine("Method3 Started using " + Thread.CurrentThread.Name);
    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine("Method3 :" + i);
    }
    Console.WriteLine("Method3 Ended using " + Thread.CurrentThread.Name);
}