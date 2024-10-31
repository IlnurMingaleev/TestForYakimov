using System;
using System.Collections.Generic;
using RpgUITest.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RpgUITest.UI
{
    public class ResourcesOfferWindow : Window
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private LayoutGroup _itemsLayoutGroup;
        [SerializeField] private Image _offerImage;
        [SerializeField] private Button _offerButton;
        [SerializeField] private TMP_Text _buyButtonText;
        [SerializeField] private ItemUIView[] _itemViews;
        [SerializeField] private TMP_Text _discountText;
        [SerializeField] private TMP_Text _discountPriceText;
        [SerializeField] private Transform _discountSection;
        private Action OnClose;

        private void OnDisable()
        {
            _offerButton.onClick.RemoveAllListeners();
        }

        public void Init(OfferData offerData, Dictionary<string, ItemData> itemDatas,Dictionary<int, OfferSpriteData> offerSpriteDatas, int itemsInOfferQuantity)
        {
            _title.text = offerData.Title;
            _description.text = offerData.Description;
            _offerImage.sprite = offerSpriteDatas[offerData.MainSpriteId].MainOfferSprite;
            _buyButtonText.text = $"$ {offerData.DiscountedPrice}";
            for (var i = 0; i < itemsInOfferQuantity; i++)
            {
                _itemViews[i].UpdateItemUIView(itemDatas[offerData.Items[i]].ItemSprite,
                    itemDatas[offerData.Items[i]].ItemQuantity);
                _itemViews[i].gameObject.SetActive(true);
            }

            if (offerData.Discounted)
            {
                _discountSection.gameObject.SetActive(true);
                _discountText.text = $"{offerData.DiscountAmount}%";
                _discountPriceText.text = $"${offerData.Price}";
            }
        }

        public void Subscribe(Action action)
        {
            OnClose += action;
            _offerButton.onClick.AddListener(() => { OnClose?.Invoke(); });
        }
    }
}