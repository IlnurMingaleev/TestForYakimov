using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RpgUITest.UI
{
    public class StartWindow : Window
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _openOfferWindow;
        private Action OnOfferWindowOpened;
        public string InputFieldText => _inputField.text;

        private void OnDisable()
        {
            _openOfferWindow.onClick.RemoveAllListeners();
        }

        public void Subscribe(Action OnNextWindow)
        {
            OnOfferWindowOpened += OnNextWindow;
            _openOfferWindow.onClick.AddListener(() => { OnOfferWindowOpened?.Invoke(); });
        }
    }
}