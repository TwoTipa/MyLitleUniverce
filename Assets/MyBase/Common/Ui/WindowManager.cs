using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyBase.Common.Ui
{
    public class WindowManager : MonoBehaviour, ICanvasOpened
    {
        public List<WindowBase> windows { get; }

        private int _sortingOrder;

        public WindowManager()
        {
            windows = new List<WindowBase>();
        }

        public T Show<T>() where T : WindowBase
        {
            _sortingOrder++;

            var existWindow = windows.FirstOrDefault(w => w is T);
            if (existWindow != null)
            {
                existWindow.canvas.sortingOrder = _sortingOrder;
                return existWindow as T;
            }

            var type = typeof(T);
            var windowPrefab = Resources.Load<T>($"UI/Windows/{type.Name}");
            var window = Instantiate(windowPrefab, transform, false);
            

            window.Bind(this).canvas.sortingOrder = _sortingOrder;
            windows.Add(window);

            return window;
        }

        public T Get<T>() where T : WindowBase
        {
            var existWindow = windows.FirstOrDefault(w => w is T);
            if (existWindow == null)
                return default;

            return existWindow as T;
        }

        public void Close(WindowBase window)
        {
            var lastWindow = windows.LastOrDefault();
            if (lastWindow == window)
                _sortingOrder--;

            DestroyWindow(window);
        }

        public void Close<T>() where T : WindowBase
        {
            var lastWindow = windows.LastOrDefault();
            if (lastWindow is T)
            {
                _sortingOrder--;
                DestroyWindow(lastWindow);
                return;
            }

            DestroyWindow(windows.LastOrDefault(w => w is T));
        }

        public void CloseAll()
        {
            foreach (var window in windows)
                Destroy(window.gameObject);

            windows.Clear();
            _sortingOrder = 0;
        }

        private void DestroyWindow(WindowBase window)
        {
            if (window == null)
                return;

            windows.Remove(window);
            Destroy(window.gameObject);

            if (windows.Count <= 0)
                _sortingOrder = 0;
        }
    }
}