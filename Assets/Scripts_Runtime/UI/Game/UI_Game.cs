using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NumberClicker {

    public class UI_Game : MonoBehaviour {

        [SerializeField] Text txtCheatNumber;

        Dictionary<int, UI_Game_NumberElement> all;
        [SerializeField] UI_Game_NumberElement n0;
        [SerializeField] UI_Game_NumberElement n1;
        [SerializeField] UI_Game_NumberElement n2;
        [SerializeField] UI_Game_NumberElement n3;
        [SerializeField] UI_Game_NumberElement n4;
        [SerializeField] UI_Game_NumberElement n5;
        [SerializeField] UI_Game_NumberElement n6;
        [SerializeField] UI_Game_NumberElement n7;
        [SerializeField] UI_Game_NumberElement n8;
        [SerializeField] UI_Game_NumberElement n9;

        public void Ctor() {
            all = new Dictionary<int, UI_Game_NumberElement>();
            all.Add(0, n0);
            all.Add(1, n1);
            all.Add(2, n2);
            all.Add(3, n3);
            all.Add(4, n4);
            all.Add(5, n5);
            all.Add(6, n6);
            all.Add(7, n7);
            all.Add(8, n8);
            all.Add(9, n9);
        }

        public void Inject() {

        }

        public void Init(Action<int> onNumberSelectedHandle) {
            foreach (var kv in all) {
                kv.Value.Init(onNumberSelectedHandle);
            }
        }

        public void SetCurrentAnswer(int answer) {
            txtCheatNumber.text = answer.ToString();
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

    }

}