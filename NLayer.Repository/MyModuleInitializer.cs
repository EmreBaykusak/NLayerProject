using System.Runtime.CompilerServices;

namespace NLayer.Repository;

public static class MyModuleInitializer
{
    [ModuleInitializer]
    public static void Initializer()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}