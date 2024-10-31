using System;
using RpgUITest.UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RpgUITest
{
    public interface IWindowFactory
    {
        T CreateWindow<T>(Transform nonActiveParent, WindowManager windowManager) where T : Window;
    }

    public class WindowFactory : IWindowFactory
    {
        public T CreateWindow<T>(Transform nonActiveParent, WindowManager windowManager) where T : Window
        {
            T window = null;
            try
            {
                var windowGO = (GameObject) Object.Instantiate(Resources.Load($"Windows/{typeof(T).Name}"),
                    nonActiveParent);
                window = windowGO.GetComponent<T>();
            }
            catch (Exception e)
            {
                Debug.LogError($"Couldn't retrieve window type {typeof(T)} from Resorces folder");
            }

            return window;
        }
    }
}