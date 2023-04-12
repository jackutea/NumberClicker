using System;
using UnityEngine;
using UnityEngine.UI;

namespace NumberClicker {

    public class UI_LevelSelection_LevelElement : MonoBehaviour {

        Button btn;
        Text txtLevel;

        public void Ctor() {
            btn = GetComponent<Button>();
            txtLevel = transform.Find("txt_level").GetComponent<Text>();

            Debug.Assert(btn != null, "btn != null");
            Debug.Assert(txtLevel != null, "txtLevel != null");
        }

        public void Init(int level, string levelName, Action<int> onLevelSelectedHandle) {
            txtLevel.text = $"Lv.{level} {levelName}";
            btn.onClick.AddListener(() => {
                onLevelSelectedHandle.Invoke(level);
            });
        }

    }

}