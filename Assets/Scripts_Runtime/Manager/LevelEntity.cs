using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace NumberClicker {

    public class LevelEntity {

        public int level;
        public int[] numbers;

        // ==== Temp ====
        public int index;
        List<int> cachedNumbers;

        public LevelEntity() {
            cachedNumbers = new List<int>();
            index = 0;
        }

        public bool TryGetCurrentAnswer(out int answer) {
            if (index >= numbers.Length) {
                answer = 0;
                return false;
            }
            answer = numbers[index];
            return true;
        }

        public void RecordInput(int number) {
            cachedNumbers.Add(number);
        }

        public GameResult TryCheckCorrect() {

            int answer = numbers[index];
            int count = cachedNumbers.Count;
            int total = 0;
            for (int i = 0; i < count; i += 1) {
                int digit = cachedNumbers[i] * (int)Mathf.Pow(10, count - i - 1);
                total += digit;
            }

            if (total == answer) {
                index += 1;
                cachedNumbers.Clear();
                if (index >= numbers.Length) {
                    NCLog.Log("Win");
                    return GameResult.Win;
                } else {
                    NCLog.Log("Correct");
                    return GameResult.Correct;
                }
            }

            if (total > answer) {
                NCLog.Log("Lose");
                return GameResult.Lose;
            }

            return GameResult.None;

        }

    }

}