namespace MyBase.Common.Ui
{
    public interface ICanvasOpened
    {
        public T Show<T>() where T : WindowBase;
    }
}