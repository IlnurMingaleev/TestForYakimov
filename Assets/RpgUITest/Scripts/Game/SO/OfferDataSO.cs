using UnityEngine;

namespace RpgUITest.Game
{
    [CreateAssetMenu(fileName = "OfferData", menuName = "ScriptableObject/OfferData")]
    public class OfferDataSO : ScriptableObject
    {
        [SerializeField] public OfferSpriteData OfferSpriteData;
    }
}