using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NumberClicker {

    public class UI_LevelSelection : MonoBehaviour {

        // ==== External ====
        LevelTemplate levelTemplate;

        // ==== Binding ====
        [SerializeField] Transform levelGroup;
        [SerializeField] UI_LevelSelection_LevelElement elementPrefab;

        // ==== Temp ====
        List<UI_LevelSelection_LevelElement> all;
        Action<int> onLevelSelectedHandle;

        public void Ctor() {
            all = new List<UI_LevelSelection_LevelElement>();
        }

        public void Inject(LevelTemplate levelTemplate) {
            this.levelTemplate = levelTemplate;
        }

        public void Init(Action<int> onLevelSelectedHandle) {

            this.onLevelSelectedHandle = onLevelSelectedHandle;

            // 读取所有关卡
            var levels = levelTemplate.Levels;
            for (int i = 0; i < levels.Length; i += 1) {
                var level = levels[i];
                CreateOneLevel(i, level.Name);
            }

        }

        void CreateOneLevel(int level, string levelName) {
            UI_LevelSelection_LevelElement element = Instantiate(elementPrefab, levelGroup);
            element.Ctor();
            element.Init(level, levelName, OnLevelSelected);
            all.Add(element);
        }

        void OnLevelSelected(int level) {
            onLevelSelectedHandle.Invoke(level);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

        public void Show() {
            gameObject.SetActive(true);
        }

    }

}