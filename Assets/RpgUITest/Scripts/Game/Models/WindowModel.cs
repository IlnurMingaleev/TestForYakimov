using UnityEngine;

namespace RpgUITest.Game
{
    public interface IPurchaseable
    {
        void PurchaseOffer();
    }

    public class WindowModel : IPurchaseable
    {
        private const int FULL_PERCENTAGE = 100;
        private readonly OfferData _offerData;
        public OfferData OfferData => _offerData;

        public WindowModel(OfferData offerData)
        {
            offerData.DiscountedPrice = offerData.Price;
            if (offerData.Discounted)
                offerData.DiscountedPrice =
                    offerData.Price * (1.0f - (float) offerData.DiscountAmount / FULL_PERCENTAGE);
            _offerData = offerData;
        }
        
        public void PurchaseOffer()
        {
            Debug.Log(
                $"{_offerData.Title} has been purchased. Substract full amount of price if its without discount. And Discounted price if it should be discounted");
        }

        
    }
}