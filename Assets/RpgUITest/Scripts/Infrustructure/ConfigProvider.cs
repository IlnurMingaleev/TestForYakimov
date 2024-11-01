using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RpgUITest.Game;
using Unity.RemoteConfig;
using UnityEngine;

namespace RpgUITest
{
    public class ConfigProvider : MonoBehaviour
    {
        public struct UserAttributes { }
        public struct AppAttributes { }

        [SerializeField] private List<ItemDataSO> _itemDatas;
        [SerializeField] private List<OfferDataSO> _offerDatas;
        private OfferData _offerData;
        public Dictionary<string, ItemData> ItemsDictionary = new Dictionary<string, ItemData>();
        public Dictionary<int, OfferSpriteData> OfferDataDictionary = new Dictionary<int, OfferSpriteData>();
        public OfferData OfferData => _offerData;
        public Action OnGetConfigSuccess;
        private void FetchOfferData()
        {
            ConfigManager.FetchCompleted += ApplyRemoteSettings;
            
            ConfigManager.FetchConfigs(new UserAttributes(), new AppAttributes());
        }

        public void Init(Action startGame)
        {
            OnGetConfigSuccess += startGame;
            FetchOfferData();
            ItemsDictionary.Clear();
            OfferDataDictionary.Clear();
            foreach (var itemSO in _itemDatas) ItemsDictionary.Add(itemSO.ItemData.ItemName, itemSO.ItemData);


            foreach (var offerDataSO in _offerDatas)
                OfferDataDictionary.Add(offerDataSO.OfferSpriteData.Id, offerDataSO.OfferSpriteData);
        }

        private void ApplyRemoteSettings(ConfigResponse configResponse)
        {
            
            if (configResponse.status == ConfigRequestStatus.Success)
            {
                string json = ConfigManager.appConfig.GetJson("offerData");
                if (!string.IsNullOrEmpty(json))
                {
                    _offerData = JsonConvert.DeserializeObject<OfferData>(json);
                    Debug.Log($"Offer Title: {_offerData.Title}");
                    Debug.Log($"Discounted Price: {_offerData.DiscountedPrice}");
                    OnGetConfigSuccess?.Invoke();
                }
                else
                {
                    Debug.LogError("OfferData key not found in Remote Config.");
                }
            }
            else
            {
                Debug.LogError("Failed to fetch Remote Config.");
            }
        }

        private void OnDestroy()
        {
            ConfigManager.FetchCompleted -= ApplyRemoteSettings;
            OnGetConfigSuccess = null;
        }
    }
}