using System.Reflection;
using System.Runtime.Loader;

// Metadata inspection only: no library initialization or native patching.
string dll = Path.GetFullPath(args[0]);
string root = Path.GetFullPath(args[1]);
string[] dirs = { Path.GetDirectoryName(dll)!, Path.Combine(root, "net6"),
    Path.Combine(root, "Il2CppAssemblies") };
AssemblyLoadContext.Default.Resolving += (context, name) =>
{
    foreach (string dir in dirs)
    {
        string path = Path.Combine(dir, name.Name + ".dll");
        if (File.Exists(path)) return context.LoadFromAssemblyPath(path);
    }
    return null;
};
Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dll);
if (assembly.GetReferencedAssemblies().Any(a => a.Name!.StartsWith("BepInEx")))
    throw new Exception("Unexpected external BepInEx dependency.");
string? version = assembly.GetCustomAttributesData().First(a =>
    a.AttributeType.FullName == "System.Reflection.AssemblyInformationalVersionAttribute")
    .ConstructorArguments[0].Value as string;
if (version?.Split('+')[0] != "4.0.5.2-ml.5") throw new Exception("Unexpected release version: " + version);
int patches = 0;
foreach (Type type in assembly.GetTypes())
{
    var classAttributes = type.GetCustomAttributesData();
    foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
        BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
    {
        var methodAttributes = method.GetCustomAttributesData();
        if (!methodAttributes.Any(a => new[] { "HarmonyPrefix", "HarmonyPostfix", "HarmonyFinalizer", "HarmonyTranspiler" }
            .Contains(a.AttributeType.Name))) continue;
        Type? targetType = null;
        string? targetName = null;
        Type[]? signature = null;
        foreach (var attribute in classAttributes.Concat(methodAttributes))
        {
            if (attribute.AttributeType.FullName != "HarmonyLib.HarmonyPatch") continue;
            foreach (var arg in attribute.ConstructorArguments)
            {
                if (arg.ArgumentType == typeof(Type)) targetType = (Type)arg.Value!;
                else if (arg.ArgumentType == typeof(string)) targetName = (string)arg.Value!;
                else if (arg.ArgumentType == typeof(Type[])) signature =
                    ((IEnumerable<CustomAttributeTypedArgument>)arg.Value!).Select(v => (Type)v.Value!).ToArray();
                else throw new Exception("Unhandled patch declaration on " + type.FullName);
            }
        }
        if (targetType == null || targetName == null)
        {
            // This one resolver only reflects OptionMenu's nested methods;
            // it does not invoke native game code or initialize the library.
            if (type.FullName == "CustomizeLib.MelonLoader.OptionMenuPatch" &&
                type.GetMethod("GetTargetMethod")!.Invoke(null, null) is MethodBase)
            {
                patches++;
                continue;
            }
            throw new Exception("Incomplete target: " + type.FullName + "." + method.Name);
        }
        var candidates = targetType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static).Where(m => m.Name == targetName).ToArray();
        if (signature != null) candidates = candidates.Where(m =>
            m.GetParameters().Select(p => p.ParameterType).SequenceEqual(signature)).ToArray();
        if (candidates.Length != 1)
            throw new Exception("Missing/ambiguous target " + targetType.FullName + "." + targetName);
        patches++;
    }
}
Console.WriteLine($"PASS: {version}; {patches} patch methods resolve; no external BepInEx reference. No patches applied.");
