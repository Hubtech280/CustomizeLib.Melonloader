using System;
using System.Collections;
using System.Text;
using MelonLoader;
using UnityEngine;

// Minimal source-compatibility surface for CustomizeLib and mods that inherited
// its BepInEx-era CorePlugin. These types delegate lifecycle and logging to
// MelonLoader; no BepInEx assembly is required at runtime.
namespace BepInEx
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class BepInPlugin : Attribute
    {
        public string GUID { get; }
        public string Name { get; }
        public string Version { get; }

        public BepInPlugin(string guid, string name, string version)
        {
            GUID = guid;
            Name = name;
            Version = version;
        }
    }
}

namespace BepInEx.Core.Logging.Interpolation
{
    public class BepInExLogInterpolatedStringHandler
    {
        private readonly StringBuilder _builder;

        public BepInExLogInterpolatedStringHandler(int literalLength, int formattedCount, ref bool shouldAppend)
        {
            _builder = new StringBuilder(Math.Max(0, literalLength));
            shouldAppend = true;
        }

        public void AppendLiteral(string value) => _builder.Append(value);

        public void AppendFormatted<T>(T value) => _builder.Append(value);

        public override string ToString() => _builder.ToString();
    }

    public sealed class BepInExInfoLogInterpolatedStringHandler : BepInExLogInterpolatedStringHandler
    {
        public BepInExInfoLogInterpolatedStringHandler(int literalLength, int formattedCount, ref bool shouldAppend)
            : base(literalLength, formattedCount, ref shouldAppend) { }
    }

    public sealed class BepInExWarningLogInterpolatedStringHandler : BepInExLogInterpolatedStringHandler
    {
        public BepInExWarningLogInterpolatedStringHandler(int literalLength, int formattedCount, ref bool shouldAppend)
            : base(literalLength, formattedCount, ref shouldAppend) { }
    }

    public sealed class BepInExErrorLogInterpolatedStringHandler : BepInExLogInterpolatedStringHandler
    {
        public BepInExErrorLogInterpolatedStringHandler(int literalLength, int formattedCount, ref bool shouldAppend)
            : base(literalLength, formattedCount, ref shouldAppend) { }
    }
}

namespace BepInEx.Logging
{
    using BepInEx.Core.Logging.Interpolation;

    public sealed class ManualLogSource
    {
        private readonly MelonLogger.Instance _logger;

        public string SourceName { get; }

        public ManualLogSource(string sourceName)
            : this(sourceName, null) { }

        internal ManualLogSource(string sourceName, MelonLogger.Instance logger)
        {
            SourceName = string.IsNullOrWhiteSpace(sourceName) ? "CustomizeLib" : sourceName;
            _logger = logger ?? new MelonLogger.Instance(SourceName);
        }

        public void LogInfo(object data) => _logger.Msg(data ?? "null");
        public void LogDebug(object data) => _logger.Msg(data ?? "null");
        public void LogMessage(object data) => _logger.Msg(data ?? "null");
        public void LogWarning(object data) => _logger.Warning(data ?? "null");
        public void LogError(object data) => _logger.Error(data ?? "null");
        public void LogFatal(object data) => _logger.Error(data ?? "null");

        public void LogInfo(BepInExInfoLogInterpolatedStringHandler data) => LogInfo(data?.ToString());
        public void LogWarning(BepInExWarningLogInterpolatedStringHandler data) => LogWarning(data?.ToString());
        public void LogError(BepInExErrorLogInterpolatedStringHandler data) => LogError(data?.ToString());
    }
}

namespace BepInEx.Unity.IL2CPP
{
    using BepInEx.Logging;

    public abstract class BasePlugin : MelonMod
    {
        private ManualLogSource _log;

        public ManualLogSource Log => _log ??= new ManualLogSource(
            Info?.Name ?? GetType().Name,
            LoggerInstance);

        public new HarmonyLib.Harmony Harmony => HarmonyInstance;

        public abstract void Load();

        public virtual bool Unload() => true;

        public sealed override void OnInitializeMelon() => Load();

        public sealed override void OnDeinitializeMelon()
        {
            Unload();
        }
    }
}

namespace BepInEx.Unity.IL2CPP.Utils
{
    public static class MonoBehaviourExtensions
    {
        public static Coroutine StartCoroutine(MonoBehaviour self, IEnumerator routine)
        {
            object token = MelonCoroutines.Start(routine);
            return token as Coroutine;
        }
    }
}
