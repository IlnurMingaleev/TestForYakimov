using UnityEngine;

namespace RpgUITest.UI
{
    public abstract class Window : MonoBehaviour
    {
        private IWindowManager _manager;

        public virtual void Init(IWindowManager windowManger)
        {
            _manager = windowManger;
        }

        public void Open(Transform activeParent)
        {
            transform.SetParent(activeParent);
        }

        public void Close(Transform nonActiveParent)
        {
            transform.SetParent(nonActiveParent);
        }
    }
}