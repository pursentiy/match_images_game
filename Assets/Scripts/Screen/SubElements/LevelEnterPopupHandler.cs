using System;
using Plugins.FSignal;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screen.SubElements
{
    public class LevelEnterPopupHandler : MonoBehaviour
    {
        [SerializeField] private Image _lockImage;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private Button _levelEnterButton;

        private int _levelNumber;

        public FSignal<int> LevelEnterClickedSignal { get; } = new FSignal<int>();

        public void Initialize(int levelNumber, bool isLocked)
        {
            _levelText.text = "Level " + levelNumber;
            _levelNumber = levelNumber;

            _levelEnterButton.interactable = !isLocked;
            _lockImage.gameObject.SetActive(!isLocked);

            _levelEnterButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            LevelEnterClickedSignal.Dispatch(_levelNumber);
        }

        private void OnDestroy()
        {
            _levelEnterButton.onClick.RemoveAllListeners();
        }
    }
}