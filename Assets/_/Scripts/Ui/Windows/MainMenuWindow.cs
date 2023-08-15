using MyBase.Common.Ui;

namespace @_.Scripts.Ui.Windows
{
    public class MainMenuWindow : WindowBase
    {
        public void Button1Click()
        {
            App.instance.windowManager.Show<GamePlayUi>();
            App.instance.windowManager.Close(this);
        }
    }
}