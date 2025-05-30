using Customer_Store_Sku.Interfaces;

namespace Customer_Store_Sku.Implementations;

public class Dictionary_Parameters_Library : IParameters_Library
{
    private readonly Dictionary<string, Dictionary<Data, object>> parameter_to_data = [];

    public void Set_Parameter(string key, object value)
    {
        parameter_to_data[key] = [];
        parameter_to_data[key][new Data()] = value;
    }

    public void Set_Customer_Parameter(string key, object value, string customer)
    {
        parameter_to_data[key][new Data(customer)] = value;
    }

    public void Set_Store_Parameter(string key, object value, string customer, string store)
    {
        parameter_to_data[key][new Data(customer, store)] = value;
    }

    public void Set_Sku_Parameter(string key, object value, string customer, string sku)
    {
        parameter_to_data[key][new Data(customer, null, sku)] = value;
    }

    public void Set_Store_Sku_Parameter(string key, object value, string customer, string store, string sku)
    {
        parameter_to_data[key][new Data(customer, store, sku)] = value;
    }

    public object Get_Parameter(string key, string customer, string store, string sku)
    {
        var data_dic = parameter_to_data[key];
        var data = new Data(customer, store, sku);
        if (data_dic.TryGetValue(data, out var value)) //customer store sku
            return value;
        data.Store = null;
        if (data_dic.TryGetValue(data, out  value)) //customer sku
            return value;
        data.Sku = null;
        data.Store = store;
        if (data_dic.TryGetValue(data, out value))  //customer store
            return value;
        data.Store = null;
        if (data_dic.TryGetValue(data, out value))  //customer 
            return value;
        data.Customer = null;
        return data_dic[data];
    }

    private class Data
    {
        public string? Customer;
        public string? Store;
        public string? Sku;

        public Data(string? customer = null, string? store = null, string? sku = null)
        {
            Customer = customer;
            Store = store;
            Sku = sku;
        }

        public override int GetHashCode()
        {
            var hash = 0;
            if (Customer != null)
                hash += Customer.GetHashCode();
            if (Store != null)
                hash += Store.GetHashCode();
            if (Sku != null)
                hash += Sku.GetHashCode();
            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Data data) return false;
            return data.Customer == Customer && data.Store == Store && data.Sku == Sku;
        }
    }
}