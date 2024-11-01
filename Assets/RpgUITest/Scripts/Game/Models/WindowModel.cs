using System;
using UnityEngine;

namespace RpgUITest.Game
{
    public class WindowModel :IDisposable
    {
        private const int FULL_PERCENTAGE = 100;
        private OfferData _offerData;
        public OfferData OfferData => _offerData;
        public Action OnDataInitialized;
        public WindowModel(OfferData offerData, Action onDataInitialized)
        {
            
            offerData.DiscountedPrice = offerData.Price;
            if (offerData.Discounted)
                offerData.DiscountedPrice =
                    offerData.Price * (1.0f - (float) offerData.DiscountAmount / FULL_PERCENTAGE);
            _offerData = offerData;
            OnDataInitialized += onDataInitialized;
            OnDataInitialized?.Invoke();
        }
        
        public void PurchaseOffer()
        {
            Debug.Log(
                $"{_offerData.Title} has been purchased. Substract full amount of price if its without discount. And Discounted price if it should be discounted");
        }


        public void Dispose()
        {
            OnDataInitialized = null;
        }
    }
}