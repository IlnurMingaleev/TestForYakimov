using UnityEngine;
using UnityEngine.Serialization;

namespace RpgUITest.Controllers
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private ConfigProvider configProvider;

        [Header("WindowManager")] 
        [SerializeField]
        private Transform canvasRoot;
        [SerializeField] private Transform nonActiveParent;

        private MainController _mainController;

        private void Awake()
        {
            configProvider.Init(StartGame);
        }

        private void StartGame()
        {
            _mainController = new MainController(configProvider, canvasRoot, nonActiveParent);
            
        }
    }
}