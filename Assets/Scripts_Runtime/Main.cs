using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NumberClicker {

    public class Main : MonoBehaviour {

        // ==== UI ====
        Canvas canvas;
        UI_Login ui_login;
        UI_LevelSelection ui_levelSelection;

        void Awake() {

            canvas = transform.Find("Canvas").GetComponent<Canvas>();
            ui_login = canvas.transform.Find("UI_Login").GetComponent<UI_Login>();
            ui_levelSelection = canvas.transform.Find("UI_LevelSelection").GetComponent<UI_LevelSelection>();

            ui_login.Ctor(UI_Login_OnStartGame);
            ui_levelSelection.Ctor();

            ui_login.Show();
            ui_levelSelection.Hide();

        }

        void UI_Login_OnStartGame() {
            ui_login.Hide();
            ui_levelSelection.Show();
        }

    }

}
