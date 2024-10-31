using RpgUITest.Game;
using RpgUITest.UI;
using UnityEngine;

namespace RpgUITest.Controllers
{
    public class MainController
    {
        private readonly ConfigProvider _configProvider;
        private readonly IWindowManager _windowManager;
        private readonly WindowModel _windowModel;

        public MainController(ConfigProvider configProvider, Transform canvasRoot, Transform nonActiveParent)
        {
            _configProvider = configProvider;
            _windowManager = new WindowManager(canvasRoot, nonActiveParent);
            _windowModel = new WindowModel(configProvider.OfferData);
        }

        public void OpenStartWindow()
        {
            var startWindow = _windowManager.GetWindow<StartWindow>();
            startWindow.Subscribe(() =>
            {
                var offerItemsQuantity = 0;
                if (int.TryParse(startWindow.InputFieldText, out offerItemsQuantity))
                {
                    if (3 <= offerItemsQuantity && offerItemsQuantity <= 6)
                    {
                        OpenOfferWindow(offerItemsQuantity);
                        _windowManager.Close<StartWindow>();
                    }
                    else
                    {
                        Debug.Log("The value is not within range. Please re-enter a valid integer from 3 to 6.");
                    }
                }
                else
                {
                    Debug.Log(
                        "FormatException in input field has been caught. Please re-enter a valid integer from 3 to 6.");
                }
            });
            _windowManager.Open<StartWindow>();
        }

        public void OpenOfferWindow(int offerItemsQuantity)
        {
            var offerWindow = _windowManager.GetWindow<ResourcesOfferWindow>();
            offerWindow.Init(_windowModel.OfferData, _configProvider.ItemsDictionary,_configProvider.OfferDataDictionary, offerItemsQuantity);
            offerWindow.Subscribe(() =>
            {
                _windowModel.PurchaseOffer();
                _windowManager.Close<ResourcesOfferWindow>();
            });
            _windowManager.Open<ResourcesOfferWindow>();
        }
    }
}