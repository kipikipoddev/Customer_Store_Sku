
using Customer_Store_Sku.Interfaces;

namespace Customer_Store_Sku.Implementations;

public class Hash_Parameters_Library : IParameters_Library
{
    private readonly Dictionary<string, Parameter_Data> parameter_to_data = [];

    public void Set_Parameter(string key, object value)
    {
        parameter_to_data[key] = new Parameter_Data(value, [], [], [], []);
    }

    public void Set_Customer_Parameter(string key, object value, string customer)
    {
        parameter_to_data[key].Customers[customer] = value;
    }

    public void Set_Store_Parameter(string key, object value, string customer, string store)
    {
        parameter_to_data[key].Stores[(customer, store)] = value;
    }

    public void Set_Sku_Parameter(string key, object value, string customer, string sku)
    {
        parameter_to_data[key].Skus[(customer, sku)] = value;
    }

    public void Set_Store_Sku_Parameter(string key, object value, string customer, string store, string sku)
    {
        parameter_to_data[key].Stores_Skus[(customer, store, sku)] = value;
    }

    public object Get_Parameter(string key, string customer, string store, string sku)
    {
        var data = parameter_to_data[key];
        if (data.Stores_Skus.TryGetValue((customer, store, sku), out var value))
            return value;
        if (data.Skus.TryGetValue((customer, sku), out value))
            return value;
        if (data.Stores.TryGetValue((customer, store), out value))
            return value;
        if (data.Customers.TryGetValue(customer, out value))
            return value;
        return data.Value;
    }

    private record Parameter_Data(
            object Value,
            Dictionary<string, object> Customers,
            Dictionary<(string, string), object> Stores,
            Dictionary<(string, string), object> Skus,
            Dictionary<(string, string, string), object> Stores_Skus);
}