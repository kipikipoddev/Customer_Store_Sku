using Customer_Store_Sku.Interfaces;

namespace TestProject.Base;

public abstract class Parameters_Library_Tests<T> : Parameters_Library_Tests_Base<T>
    where T : IParameters_Library
{
    [Test]
    public void Test_Override_Parameter()
    {
        library.Set_Parameter(Parameters[0], Values[1]);
    }

    [Test]
    public void Test_Override_Customer()
    {
        library.Set_Customer_Parameter(Parameters[0], Values[1], Customers[0]);
    }

    [Test]
    public void Test_Override_Customer_Again()
    {
        library.Set_Customer_Parameter(Parameters[0], Values[1], Customers[0]);
        library.Set_Customer_Parameter(Parameters[0], Values[2], Customers[0]);
    }

    [Test]
    public void Test_Override_By_Store()
    {
        library.Set_Customer_Parameter(Parameters[0], Values[1], Customers[0]);
        library.Set_Store_Parameter(Parameters[0], Values[2], Customers[0], Stores[0]);
    }

    [Test]
    public void Test_Override_By_Sku()
    {
        library.Set_Customer_Parameter(Parameters[0], Values[1], Customers[0]);
        library.Set_Sku_Parameter(Parameters[0], Values[2], Customers[0], SKUs[0]);
    }

    [Test]
    public void Test_Override_By_Store_And_Sku()
    {
        library.Set_Customer_Parameter(Parameters[0], Values[1], Customers[0]);
        library.Set_Store_Parameter(Parameters[0], Values[2], Customers[0], Stores[0]);
        library.Set_Sku_Parameter(Parameters[0], Values[3], Customers[0], SKUs[0]);
        library.Set_Store_Sku_Parameter(Parameters[0], Values[4], Customers[0], Stores[0], SKUs[0]);
    }

    [Test]
    public void Test_Override_Two_Customers()
    {
        library.Set_Customer_Parameter(Parameters[0], Values[1], Customers[0]);
        library.Set_Customer_Parameter(Parameters[0], Values[2], Customers[1]);
    }

    [Test]
    public void Benchmark()
    {
        Benchmarks.Run(library, 10);
    }
}