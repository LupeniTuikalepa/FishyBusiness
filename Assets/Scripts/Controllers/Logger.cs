using UnityEngine;

namespace FishyBusiness
{
    public interface ILogSource
    {
        string Name { get; }
    }

    /// <summary>
    /// Log like [OBJECT] blablabla
    /// </summary>
    public class Logger
    {
        private static Logger Global => GameController.Logger;

        public void Log(ILogSource logSource, string message) => Debug.Log($"[{logSource.Name}] {message}");

        public void Log(string message) => Log(null, message);


        public void LogWarning(string message) => LogWarning(null, message);
        public void LogWarning(ILogSource logSource,  string message) => Debug.LogWarning($"[{logSource.Name}] {message}");


        public void LogError(string message) => LogError(null, message);
        public void LogError(ILogSource logSource, string message) => Debug.LogError($"[{logSource.Name}] {message}");
    }
}