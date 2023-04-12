using System;
using UnityEngine;
using UnityEngine.UI;

namespace NumberClicker {

    public class UI_Login : MonoBehaviour {

        Button btnLogin;

        public void Ctor() {
            btnLogin = transform.Find("btn_start").GetComponent<Button>();
            Debug.Assert(btnLogin != null, "btnLogin != null");
        }

        public void Init(Action onStartGameHandle) {
            btnLogin.onClick.AddListener(() => {
                onStartGameHandle.Invoke();
            });
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

    }

}