namespace Common;

public interface IParameters_Library
{
    void Set_Parameter(string key, object value);
    void Set_Customer_Parameter(string key, object value, string customer);
    void Set_Store_Parameter(string key, object value, string customer, string store);
    void Set_Sku_Parameter(string key, object value, string customer, string sku);

    object Get_Parameter(string key, string customer, string store, string sku);
}