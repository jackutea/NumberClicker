using System;
using UnityEngine;
using UnityEngine.UI;

namespace NumberClicker {

    public class UI_LevelSelection : MonoBehaviour {

        public void Ctor() {
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

        public void Show() {
            gameObject.SetActive(true);
        }

    }

}