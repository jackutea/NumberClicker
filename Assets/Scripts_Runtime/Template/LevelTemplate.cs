using System.Collections.Generic;
using UnityEngine;

namespace NumberClicker {

    [CreateAssetMenu(fileName = "so_levelTemplate", menuName = "NumberClicker/LevelTemplate")]
    public class LevelTemplate : ScriptableObject {

        [SerializeField] LevelTM[] levels;
        public LevelTM[] Levels => levels;

#if UNITY_EDITOR
        public void Generate() {

            List<LevelTM> list = new List<LevelTM>();

            // Level 1: 1~100
            LevelTM lv1 = new LevelTM();
            lv1.SetLevel(1);
            lv1.SetName("1~100");
            int[] numbers = new int[100];
            for (int i = 0; i < numbers.Length; i += 1) {
                numbers[i] = i + 1;
            }
            lv1.SetNumbers(numbers);
            list.Add(lv1);

            levels = list.ToArray();

            UnityEditor.EditorUtility.SetDirty(this);

        }
#endif

    }

}