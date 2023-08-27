using UnityEngine;

namespace MyBase.Common.Ui
{ 
    [RequireComponent(typeof(Canvas))]
    public abstract class WindowBase : MonoBehaviour
    {
        public Canvas canvas { get; private set; }

        protected WindowManager WindowManager;

        public WindowBase Bind(WindowManager windowManager)
        {
            WindowManager = windowManager;
            return this;
        }

        public virtual void Close()
        {
            WindowManager.Close(this);
        }

        protected virtual void Awake()
        {
            canvas = GetComponent<Canvas>();
        }
    }
}