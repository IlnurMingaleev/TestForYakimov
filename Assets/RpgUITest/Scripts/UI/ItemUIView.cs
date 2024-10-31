using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RpgUITest.UI
{
    public class ItemUIView : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;
        [SerializeField] private TMP_Text _itemQuantity;

        public void UpdateItemUIView(Sprite itemSprite, int itemQuantity)
        {
            _itemImage.sprite = itemSprite;
            _itemQuantity.text = itemQuantity.ToString();
        }
    }
}