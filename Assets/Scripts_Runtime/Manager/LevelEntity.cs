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
            int answerMaxDigit = (int)Mathf.Log10(answer) + 1;

            int count = cachedNumbers.Count;

            if (answerMaxDigit > count) {
                // 已输入的位数不够, 但也要匹配

                /*  Example:
                        10, 1
                        answerMaxDigit = 2, count = 1
                */
                int tmp = answer;
                int offset = answerMaxDigit - count;
                for (int i = 0; i < cachedNumbers.Count; i += 1) {
                    int d = (int)(Mathf.Pow(10, answerMaxDigit - i - 1));
                    int num = cachedNumbers[i];
                    int digitInAnswer = tmp / d;
                    tmp -= digitInAnswer * d;
                    if (num != digitInAnswer) {
                        cachedNumbers.Clear();
                        NCLog.Log("Lose: " + num + " != " + digitInAnswer);
                        return GameResult.Lose;
                    }
                }

                return GameResult.None;

            } else if (answerMaxDigit == count) {

                // 已输入的位数与答案位数相同

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
                        return GameResult.Correct;
                    }
                }

                cachedNumbers.Clear();
                NCLog.Log("Lose total: " + total + " != " + answer);
                return GameResult.Lose;

            } else {

                // 已输入的位数超过答案位数
                cachedNumbers.Clear();
                NCLog.Log("Lose: 输入位数超过答案位数");
                return GameResult.Lose;

            }

        }

    }

}