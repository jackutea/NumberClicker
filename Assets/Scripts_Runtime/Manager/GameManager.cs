using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace NumberClicker {

    public class GameManager {

        LevelTemplate levelTemplate;
        UI_Game ui_game;

        LevelEntity levelEntity;

        bool inLevel;

        public GameManager() {}

        public void Inject(LevelTemplate levelTemplate, UI_Game ui_game) {
            this.levelTemplate = levelTemplate;
            this.ui_game = ui_game;
        }

        public void EnterLevel(int level) {

            bool has = levelTemplate.TryGet(level, out var tm);
            if (!has) {
                NCLog.Error("Level not found: " + level);
                return;
            }

            levelEntity = new LevelEntity();
            levelEntity.level = level;
            levelEntity.numbers = tm.Numbers;

            ui_game.Show();
            ui_game.Init(OnNumberSelected);

            bool hasAnswer = levelEntity.TryGetCurrentAnswer(out var answer);
            if (!hasAnswer) {
                NCLog.Error("Level not found: " + level);
                return;
            }

            ui_game.SetCurrentAnswer(answer);

            inLevel = true;

        }

        KeyCode[] keys = new KeyCode[] {
            KeyCode.Keypad0,
            KeyCode.Keypad1,
            KeyCode.Keypad2,
            KeyCode.Keypad3,
            KeyCode.Keypad4,
            KeyCode.Keypad5,
            KeyCode.Keypad6,
            KeyCode.Keypad7,
            KeyCode.Keypad8,
            KeyCode.Keypad9,
        };
        Dictionary<KeyCode, int> keyMap = new Dictionary<KeyCode, int>(){
            {KeyCode.Keypad0, 0},
            {KeyCode.Keypad1, 1},
            {KeyCode.Keypad2, 2},
            {KeyCode.Keypad3, 3},
            {KeyCode.Keypad4, 4},
            {KeyCode.Keypad5, 5},
            {KeyCode.Keypad6, 6},
            {KeyCode.Keypad7, 7},
            {KeyCode.Keypad8, 8},
            {KeyCode.Keypad9, 9},
        };

        public void Tick() {

            if (!inLevel) {
                return;
            }

            // Get Input Number
            KeyCode key = KeyCode.None;
            for (int i = 0; i < keys.Length; i += 1) {
                if (Input.GetKeyDown(keys[i])) {
                    key = keys[i];
                    break;
                }
            }
            bool has = keyMap.TryGetValue(key, out var number);
            if (!has) {
                return;
            }
            OnNumberSelected(number);
        }

        void OnNumberSelected(int number) {

            levelEntity.RecordInput(number);
            GameResult res = levelEntity.TryCheckCorrect();
            if (res == GameResult.Correct) {
                levelEntity.TryGetCurrentAnswer(out var answer);
                ui_game.SetCurrentAnswer(answer);
            } else if (res == GameResult.Win) {

            } else if (res == GameResult.Lose) {
                // 弹窗
            }

            // 1. LevelEntity -> Record Input
            // 2. LevelEntity -> Check Complete Number
            // 3. LevelEntity -> IsCorrect

        }

    }

}