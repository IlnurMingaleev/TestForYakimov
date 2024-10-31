using UnityEngine;

namespace RpgUITest.Game
{
    [CreateAssetMenu(fileName = "ItemDataSO", menuName = "ItemDataSO", order = 1)]
    public class ItemDataSO : ScriptableObject
    {
        public ItemData ItemData;
    }
}