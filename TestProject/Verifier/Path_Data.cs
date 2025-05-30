namespace Customer_Store_Sku.Tests;

internal class Path_Data
{
    private const string Tests_Folder_Path = @".\..\..\..\Tests_Files\";
    public string Path { get; }

    public Path_Data()
    {
        Path = Tests_Folder_Path + Get_Subfix();
    }

    private static string Get_Subfix()
    {
        var test = TestContext.CurrentContext.Test;
        return $"{test.DisplayName}\\{test.MethodName}.txt";
    }
}