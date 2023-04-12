using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NumberClicker {

    public class Main : MonoBehaviour {

        // ==== Template ====
        LevelTemplate levelTemplate;

        // ==== UI ====
        Canvas canvas;
        UI_Login ui_login;
        UI_LevelSelection ui_levelSelection;

        void Awake() {

            // ==== Template ====
            levelTemplate = Resources.Load<LevelTemplate>("Template/Level/so_levelTemplate");
            Debug.Assert(levelTemplate != null, "levelTemplate != null");

            canvas = transform.Find("Canvas").GetComponent<Canvas>();
            ui_login = canvas.transform.Find("UI_Login").GetComponent<UI_Login>();
            ui_levelSelection = canvas.transform.Find("UI_LevelSelection").GetComponent<UI_LevelSelection>();

            // ==== Ctor ====
            ui_login.Ctor();
            ui_levelSelection.Ctor();

            // ==== Inject ====
            ui_levelSelection.Inject(levelTemplate);

            // ==== Init ====
            ui_login.Init(UI_Login_OnStartGame);
            ui_levelSelection.Init(UI_LevelSelection_OnLevelSelected);

            // ==== Enter ====
            EnterLogin();

        }

        void EnterLogin() {
            ui_login.Show();
            ui_levelSelection.Hide();
        }

        void UI_Login_OnStartGame() {
            ui_login.Hide();
            ui_levelSelection.Show();
        }

        void UI_LevelSelection_OnLevelSelected(int level) {
            Debug.Log($"Level {level} selected");
        }

        // ==== Editor ====
#if UNITY_EDITOR
        [ContextMenu("Generate")]
        void Generate() {
            levelTemplate = Resources.Load<LevelTemplate>("Template/Level/so_levelTemplate");
            levelTemplate.Generate();
        }
#endif

    }

}
