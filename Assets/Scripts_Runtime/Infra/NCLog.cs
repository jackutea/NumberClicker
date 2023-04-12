using UnityEngine;

namespace NumberClicker {

    public static class NCLog {

        public static void Log(object message) {
            Debug.Log(message);
        }

        public static void Warning(object message) {
            Debug.LogWarning(message);
        }

        public static void Error(object message) {
            Debug.LogError(message);
        }

    }
}