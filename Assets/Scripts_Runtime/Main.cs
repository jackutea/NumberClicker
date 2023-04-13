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
        UI_Game ui_game;

        // ==== Manager ====
        GameManager gameManager;

        void Awake() {

            // ==== Template ====
            levelTemplate = Resources.Load<LevelTemplate>("Template/Level/so_levelTemplate");
            Debug.Assert(levelTemplate != null, "levelTemplate != null");

            canvas = transform.Find("Canvas").GetComponent<Canvas>();
            ui_login = canvas.transform.Find("UI_Login").GetComponent<UI_Login>();
            ui_levelSelection = canvas.transform.Find("UI_LevelSelection").GetComponent<UI_LevelSelection>();
            ui_game = canvas.transform.Find("UI_Game").GetComponent<UI_Game>();

            gameManager = new GameManager();

            // ==== Ctor ====
            ui_login.Ctor();
            ui_levelSelection.Ctor();
            ui_game.Ctor();

            // ==== Inject ====
            ui_levelSelection.Inject(levelTemplate);
            gameManager.Inject(levelTemplate, ui_game);

            // ==== Init ====
            ui_login.Init(UI_Login_OnStartGame);
            ui_levelSelection.Init(UI_LevelSelection_OnLevelSelected);

            // ==== Enter ====
            EnterLogin();

        }

        void Update() {
            gameManager.Tick();
        }

        void EnterLogin() {
            ui_login.Show();
            ui_levelSelection.Hide();
            ui_game.Hide();
        }

        void UI_Login_OnStartGame() {
            ui_login.Hide();
            ui_levelSelection.Show();
            ui_game.Hide();
        }

        void UI_LevelSelection_OnLevelSelected(int level) {
            ui_login.Hide();
            ui_levelSelection.Hide();
            gameManager.EnterLevel(level);
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
