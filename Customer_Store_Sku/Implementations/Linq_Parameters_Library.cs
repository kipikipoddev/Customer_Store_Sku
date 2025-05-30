using Customer_Store_Sku.Interfaces;

namespace Customer_Store_Sku.Implementations;

public class Linq_Parameters_Library : IParameters_Library
{
    private readonly List<Data> data = [];

    public void Set_Parameter(string key, object value)
    {
        Remove(key);
        data.Add(new Data(key, value));
    }

    public void Set_Customer_Parameter(string key, object value, string customer)
    {
        Remove(key, customer);
        data.Add(new Data(key, value, customer));
    }

    public void Set_Store_Parameter(string key, object value, string customer, string store)
    {
        Remove(key, customer, store);
        data.Add(new Data(key, value, customer, store));
    }

    public void Set_Sku_Parameter(string key, object value, string customer, string sku)
    {
        Remove(key, customer, null, sku);
        data.Add(new Data(key, value, customer, null, sku));
    }

    public void Set_Store_Sku_Parameter(string key, object value, string customer, string store, string sku)
    {
        Remove(key, customer, store, sku);
        data.Add(new Data(key, value, customer, store, sku));
    }

    public object Get_Parameter(string key, string customer, string store, string sku)
    {
        return data.Where(d => d.Key == key)
            .OrderBy(d => Order_Func(d, customer, store, sku))
            .First().Value;
    }

    private int Order_Func(Data data, string customer, string store, string sku)
    {
        return data.Customer == customer ?
            data.Sku == sku ? data.Store == store ? 1 : 2 :
            data.Store == store ? 3 : 4 : 5;
    }

    private void Remove(string key, string? customer = null, string? store = null, string? sku = null)
    {
        var data = this.data.FirstOrDefault(d => d.Key == key && d.Customer == customer && d.Store == store && d.Sku == sku);
        if (data != null)
            this.data.Remove(data);
    }

    private record Data(string Key, object Value, string? Customer = null, string? Store = null, string? Sku = null);
}