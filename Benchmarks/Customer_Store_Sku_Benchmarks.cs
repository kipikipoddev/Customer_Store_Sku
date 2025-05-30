using BenchmarkDotNet.Attributes;
using Customer_Store_Sku.Implementations;
using TestProject.Base;

[MemoryDiagnoser]
public class Customer_Store_Sku_Benchmarks
{
    private const int Scale = 10;

    [Benchmark]
    public void Dictionary_Benchmarks()
    {
        var bench = new Dictionary_Parameters_Library();
        Benchmarks.Run(bench, Scale);
    }

    [Benchmark]
    public void Hash_Benchmarks()
    {
        var bench = new Hash_Parameters_Library();
        Benchmarks.Run(bench, Scale);
    }

    [Benchmark]
    public void Dictionary_Benchmarks_Five()
    {
        var bench = new Dictionary_Parameters_Library();
        Benchmarks.Run(bench, Scale * 5);
    }

    [Benchmark]
    public void Hash_Benchmarks_Five()
    {
        var bench = new Hash_Parameters_Library();
        Benchmarks.Run(bench, Scale * 5);
    }

    [Benchmark]
    public void Linq_Benchmarks()
    {
        var bench = new Linq_Parameters_Library();
        Benchmarks.Run(bench, Scale);
    }

    [Benchmark]
    public void List_Benchmarks()
    {
        var bench = new List_Parameters_Library();
        Benchmarks.Run(bench, Scale);
    }
}
