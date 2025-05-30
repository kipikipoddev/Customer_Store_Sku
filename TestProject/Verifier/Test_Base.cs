namespace Customer_Store_Sku.Tests;

public abstract class Test_Base
{
    protected abstract IEnumerable<string> Get_Subject();

    [TearDown]
    public virtual void Tear_Down()
    {
        try
        {
            Verifier.Verify(Get_Subject());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}