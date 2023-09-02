using System;
using _.Scripts.GameplayResources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyBase.Common.GameplayResources
{
    [Serializable]
    public abstract class Resource : IResource
    {
        public event Action<int> ResourceChanged; 
        public ResourceName Name { get; protected set; }
        public Color Color { get; protected set; }
        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                if (_amount < 0)
                {
                    _amount = 0;
                }
                ResourceChanged?.Invoke(_amount);
            }
        }

        private int _amount;
        
        public Sprite Image { get; protected set; }
        
        public Resource(ResourceName name, int amount)
        {
            
        }        
        public abstract Resource CreateInstance();

        public void Subscribe(TextMeshProUGUI text)
        {
            ResourceChanged += i => text.text = i.ToString();
        }

        protected Resource(int amount)
        {
            _amount = amount;
        }
    }

    public enum ResourceName
    {
        Wood,
        Scrap
    }
}