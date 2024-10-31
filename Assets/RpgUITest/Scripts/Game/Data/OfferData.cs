using System;
using System.Collections.Generic;
using UnityEngine;

namespace RpgUITest.Game
{
    public struct OfferData
    {
        public int Id;
        public string Title;
        public string Description;
        public string[] Items;
        public float Price;
        public bool Discounted;
        public float DiscountedPrice;
        public int DiscountAmount;
        public int MainSpriteId;
    }

   
}