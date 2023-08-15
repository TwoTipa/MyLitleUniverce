using _.Scripts.Ui.Windows;
using MyBase.Common;
using MyBase.Common.Ui;
using UnityEngine;

namespace _.Scripts
{
    public class App : Singleton<App>
    {
        public WindowManager windowManager { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            windowManager = new GameObject("WindowManager").AddComponent<WindowManager>();
            windowManager.transform.SetParent(transform);
        }

        
        private void Start()
        {
            windowManager.Show<MainMenuWindow>();
        }
    }
}