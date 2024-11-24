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

        [HideInCallstack]
        public void Log(ILogSource logSource, string message) => Debug.Log($"[{logSource.Name}] {message}");

        [HideInCallstack]

        public void Log(string message) => Log(null, message);


        [HideInCallstack]
        public void LogWarning(string message) => LogWarning(null, message);

        [HideInCallstack]
        public void LogWarning(ILogSource logSource,  string message) => Debug.LogWarning($"[{logSource.Name}] {message}");


        [HideInCallstack]

        public void LogError(string message) => LogError(null, message);

        [HideInCallstack]
        public void LogError(ILogSource logSource, string message) => Debug.LogError($"[{logSource.Name}] {message}");
    }
}