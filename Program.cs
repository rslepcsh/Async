using System.Diagnostics;

RunSynchronous();
await RunAsynchronous();

void RunSynchronous()
{
    Stopwatch syncSW = Stopwatch.StartNew();

    ProcessData("File 1");
    ProcessData("File 2");
    ProcessData("File 3");

    Console.WriteLine($"Finished synchronous operations in {syncSW.Elapsed.TotalSeconds} seconds");
}

async Task RunAsynchronous()
{
    Stopwatch asyncSW = Stopwatch.StartNew();

    Task task1 = ProcessDataAsync("File 1");
    Task task2 = ProcessDataAsync("File 2");
    Task task3 = ProcessDataAsync("File 3");
    await Task.WhenAll(task1, task2, task3);

    Console.WriteLine($"Finished asynchronous operations in {asyncSW.Elapsed.TotalSeconds} seconds");
}
void ProcessData(string dataName)
{
    Thread.Sleep(3000);
    Console.WriteLine($"Finished working on {dataName}");
}

async Task ProcessDataAsync(string dataName)
{
    await Task.Delay(3000);
    Console.WriteLine($"Finished working on {dataName}");
}
