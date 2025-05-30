using Newtonsoft.Json;

namespace Customer_Store_Sku.Tests;

internal static class Verifier
{
    public static void Verify(IEnumerable<string> data)
    {
        Handle_Expected(string.Join('\n',data), new Path_Data());
    }

    private static void Handle_Expected(string result, Path_Data path)
    {
        string? context = null;
        if (File.Exists(path.Path))
            context = File.ReadAllText(path.Path);

        Write_File(result, path.Path);

        if (context != null)
            Assert.That(result, Is.EqualTo(context));
    }

    private static void Write_File(string context, string path)
    {
        Directory.CreateDirectory(path[..path.LastIndexOf('\\')]);
        var file = File.CreateText(path);
        file.Write(context);
        file.Close();
    }
}
