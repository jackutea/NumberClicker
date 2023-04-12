using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace NumberClicker {

    public class UI_Game_NumberElement : MonoBehaviour, IPointerDownHandler {

        [SerializeField] int number;

        Image imgBg;
        Text txtNumber;

        Action<int> onNumberSelectedHandle;

        public void Init(Action<int> onNumberSelectedHandle) {

            this.onNumberSelectedHandle = onNumberSelectedHandle;

            imgBg = transform.Find("img_bg").GetComponent<Image>();
            txtNumber = transform.Find("txt_number").GetComponent<Text>();

            Debug.Assert(imgBg != null, "imgBg != null");
            Debug.Assert(txtNumber != null, "txtNumber != null");

            txtNumber.text = number.ToString();
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
            onNumberSelectedHandle.Invoke(number);
        }
    }

}