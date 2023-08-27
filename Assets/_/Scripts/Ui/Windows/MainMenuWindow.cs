using System;
using MyBase.Common.Ui;

namespace @_.Scripts.Ui.Windows
{
    public class MainMenuWindow : WindowBase
    {
        public static event Action<bool> MainMenuOpen;
        
        public void Button1Click()
        {
            WindowManager.Show<GamePlayUi>();
            WindowManager.Close(this);
            MainMenuOpen?.Invoke(false);
        }
    }
}