using Common;
using Engine;

namespace TestProject.Tests;

public class Parameters_Library_Tests
{
    private IParameters_Library library;

    private const string Parameter_A = "Parameter_A";
    private const string Parameter_B = "Parameter_B";

    private const string Customer_1 = "Customer_1";
    private const string Customer_2 = "Customer_2";

    private const string Store_1 = "Store_1";
    private const string Store_2 = "Store_2";

    private const string Sku_1 = "Sku_1";
    private const string Sku_2 = "Sku_2";

    private const string Value_1 = "Value_1";
    private const string Value_2 = "Value_2";
    private const string Value_3 = "Value_3";
    private const string Value_4 = "Value_4";

    [SetUp]
    public void Setup()
    {
        library = new Hash_Parameters_Library();
        library.Set_Parameter(Parameter_A, Value_1);
        library.Set_Parameter(Parameter_B, Value_2);
    }

    [Test]
    public void Test_No_Override()
    {
        Assert_Value(value: Value_1);
        Assert_Value(parameter: Parameter_B, value: Value_2);
    }

    [Test]
    public void Test_Override_Parameter()
    {
        library.Set_Parameter(Parameter_A, Value_2);
        Assert_Value(value: Value_2);
    }

    [Test]
    public void Test_Override_Customer()
    {
        library.Set_Customer_Parameter(Parameter_A, Value_2, Customer_1);
        Assert_Value();
    }

    [Test]
    public void Test_Override_Customer_Again()
    {
        library.Set_Customer_Parameter(Parameter_A, Value_2, Customer_1);
        library.Set_Customer_Parameter(Parameter_A, Value_3, Customer_1);

        Assert_Value(value: Value_3);
    }

    [Test]
    public void Test_Override_By_Store()
    {
        library.Set_Customer_Parameter(Parameter_A, Value_2, Customer_1);
        library.Set_Store_Parameter(Parameter_A, Value_3, Customer_1, Store_2);

        Assert_Value();
        Assert_Value(store: Store_2, value: Value_3);
    }

    [Test]
    public void Test_Override_By_Sku()
    {
        library.Set_Customer_Parameter(Parameter_A, Value_2, Customer_1);
        library.Set_Sku_Parameter(Parameter_A, Value_3, Customer_1, Sku_2);

        Assert_Value();
        Assert_Value(sku: Sku_2, value: Value_3);
    }

    [Test]
    public void Test_Override_By_Store_And_Sku()
    {
        library.Set_Customer_Parameter(Parameter_A, Value_2, Customer_1);
        library.Set_Store_Parameter(Parameter_A, Value_3, Customer_1, Store_2);
        library.Set_Sku_Parameter(Parameter_A, Value_4, Customer_1, Sku_2);

        Assert_Value();
        Assert_Value(store: Store_2, value: Value_3);
        Assert_Value(sku: Sku_2, value: Value_4);
    }

    [Test]
    public void Test_Override_Two_Customers()
    {
        library.Set_Customer_Parameter(Parameter_A, Value_2, Customer_1);
        library.Set_Customer_Parameter(Parameter_A, Value_3, Customer_2);

        Assert_Value();
        Assert_Value(customer: Customer_2, value: Value_3);
    }

    [Test]
    public void Benchmark()
    {
        Benchmarks.Run(library, 50);
    }

    private void Assert_Value(
        string parameter = Parameter_A,
        string customer = Customer_1,
        string store = Store_1,
        string sku = Sku_1,
        string value = Value_2)
    {
        var result = library.Get_Parameter(parameter, customer, store, sku);
        Assert.That(result, Is.EqualTo(value));
    }
}