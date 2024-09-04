using System.Diagnostics;
using System.Runtime.InteropServices;

namespace IrisUtils.Core;

public static class DotNet
{
    public static string? Path { get; } = TryGetPath();
    public static string PathOrDefault() => Path ?? "dotnet";

    private static string? TryGetPath()
    {
        var fileName = "dotnet";
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            fileName += ".exe";
        
        var mainModule = Process.GetCurrentProcess().MainModule;
        if(!string.IsNullOrEmpty(mainModule?.FileName) && 
            System.IO.Path.GetFileName(mainModule.FileName).Equals(fileName, StringComparison.OrdinalIgnoreCase))
            return mainModule.FileName;

        var root = Environment.GetEnvironmentVariable("DOTNET_ROOT");
        if(string.IsNullOrEmpty(root))
            root = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "C:\\Program Files\\dotnet" : "/usr/local/share/dotnet";

        return System.IO.Path.Combine(root, fileName);
    }
}
