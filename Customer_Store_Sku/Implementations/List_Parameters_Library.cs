using Customer_Store_Sku.Interfaces;

namespace Customer_Store_Sku.Implementations;

public class List_Parameters_Library : IParameters_Library
{
    private readonly Dictionary<string, List<Data>> parameter_to_data = [];

    public void Set_Parameter(string key, object value)
    {
        parameter_to_data[key] = [new Data(value)];
    }

    public void Set_Customer_Parameter(string key, object value, string customer)
    {
        parameter_to_data[key].Add(new Data(value, customer));
    }

    public void Set_Store_Parameter(string key, object value, string customer, string store)
    {
        parameter_to_data[key].Add(new Data(value, customer, store));
    }

    public void Set_Sku_Parameter(string key, object value, string customer, string sku)
    {
        parameter_to_data[key].Add(new Data(value, customer, null, sku));
    }

    public void Set_Store_Sku_Parameter(string key, object value, string customer, string store, string sku)
    {
        parameter_to_data[key].Add(new Data(value, customer, store, sku));
    }

    public object Get_Parameter(string key, string customer, string store, string sku)
    {
        var level = Level.None;
        object? value = null;

        foreach (var data in parameter_to_data[key])
        {
            if (data.Customer == customer)
            {
                if (data.Store == store)
                {
                    if (data.Sku == sku)
                        return data.Value;
                    else if (data.Sku == null && level < Level.Sku)
                    {
                        value = data.Value;
                        level = Level.Store;
                    }
                }
                else if (data.Sku == sku && data.Store == null)
                {
                    level = Level.Sku;
                    value = data.Value;
                }
                else if (level < Level.Store && data.Store == null && data.Sku == null)
                {
                    value = data.Value;
                    level = Level.Customer;
                }
            }
            else if (level == Level.None)
                value = data.Value;
        }
        return value!;
    }

    private enum Level
    {
        None,
        Customer,
        Store,
        Sku
    }

    private record Data(object Value, string? Customer = null, string? Store = null, string? Sku = null);
}