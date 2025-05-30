using Customer_Store_Sku.Interfaces;
using Customer_Store_Sku.Tests;

namespace TestProject.Base;

public abstract class Parameters_Library_Tests_Base<T> : Test_Base
    where T : IParameters_Library
{
    protected IParameters_Library library;

    protected string[] Parameters = ["Parameter_A", "Parameter_B"];
    protected string[] Customers = ["Customer_1", "Customer_2"];
    protected string[] Stores = ["Store_1", "Store_2"];
    protected string[] SKUs = ["Sku_1", "Sku_2"];
    protected string[] Values = ["Value_1", "Value_2", "Value_3", "Value_4", "Value_5"];


    [SetUp]
    public virtual void Setup()
    {
        library = Activator.CreateInstance<T>();
        library.Set_Parameter(Parameters[0], Values[0]);
        library.Set_Parameter(Parameters[1], Values[1]);
    }

    protected override IEnumerable<string> Get_Subject()
    {
        foreach (var data in Get_All_Args())
        {
            data.Value = Get_Value(data);
            yield return data.ToString();
        }
    }

    private object Get_Value(Data data)
    {
        return library.Get_Parameter(data.Parameter, data.Customer, data.Store, data.Sku);
    }

    private IEnumerable<Data> Get_All_Args()
    {
        foreach (var parameter in Parameters)
            foreach (var customer in Customers)
                foreach (var store in Stores)
                    foreach (var sku in SKUs)
                        yield return new Data(parameter, customer, store, sku);
    }

    private record Data(string Parameter, string Customer, string Store, string Sku)
    {
        public object? Value;

        public override string ToString()
        {
            return $"{Parameter} {Customer} {Store} {Sku} {Value}";
        }
    }
}