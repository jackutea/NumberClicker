using System;
using UnityEngine;

namespace NumberClicker {

    [Serializable]
    public class LevelTM {

        [SerializeField] int level;
        public int Level => level;
        public void SetLevel(int value)=> level = value;

        [SerializeField] string name;
        public string Name => name;
        public void SetName(string value)=> name = value;

        [SerializeField] int[] numbers;
        public int[] Numbers => numbers;
        public void SetNumbers(int[] value)=> numbers = value;

    }

}