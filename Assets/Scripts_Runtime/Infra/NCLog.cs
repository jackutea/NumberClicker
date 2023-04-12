using UnityEngine;

namespace NumberClicker {

    public static class NCLog {

        public static void Log(object message) {
            Debug.Log(message);
        }

        public static void LogWarning(object message) {
            Debug.LogWarning(message);
        }

        public static void LogError(object message) {
            Debug.LogError(message);
        }

    }
}