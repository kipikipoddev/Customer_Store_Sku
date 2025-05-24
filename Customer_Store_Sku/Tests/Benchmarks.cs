using Customer_Store_Sku.Interfaces;

namespace Customer_Store_Sku.Tests;

public static class Benchmarks
{
    public static void Run(IParameters_Library library, int scale)
    {
        Set_Parameters(library, scale);
        Get_Parameters(library, scale);
    }

    public static void Set_Parameters(IParameters_Library library, int scale)
    {
        for (int p_index = 0; p_index < scale; p_index++)
        {
            var parameter = p_index.ToString();
            library.Set_Parameter(parameter, Get());
            for (var customer_index = 0; customer_index < scale; customer_index++)
            {
                var customer = customer_index.ToString();
                library.Set_Customer_Parameter(parameter, Get(), customer);
                for (var store_index = 0; store_index < scale; store_index++)
                    library.Set_Store_Parameter(parameter, Get(), customer, store_index.ToString());

                for (var sku_index = 0; sku_index < scale; sku_index++)
                    library.Set_Sku_Parameter(parameter, Get(), customer, sku_index.ToString());
            }
        }
    }

    public static void Get_Parameters(IParameters_Library library, int scale)
    {
        for (int p_index = 0; p_index < scale; p_index++)
        {
            var parameter = p_index.ToString();
            for (var customer_index = 0; customer_index < scale; customer_index++)
            {
                var customer = customer_index.ToString();
                for (var store_index = 0; store_index < scale; store_index++)
                {
                    var store = store_index.ToString();
                    for (var sku_index = 0; sku_index < scale; sku_index++)
                    {
                        var sku = sku_index.ToString();
                        library.Get_Parameter(parameter, customer, store, sku);
                    }
                }
            }
        }
    }

    private static string Get() => Guid.NewGuid().ToString();
}