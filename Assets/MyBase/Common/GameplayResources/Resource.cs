using System;
using _.Scripts.GameplayResources;
using UnityEngine;

namespace MyBase.Common.GameplayResources
{
    [Serializable]
    public abstract class Resource : IResource
    {
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
            }
        }

        private int _amount;

        protected Resource(int amount)
        {
            _amount = amount;
        }

        public Resource(ResourceName name, int amount)
        {
            
        }

        public abstract Resource CreateInstance();
    }

    public enum ResourceName
    {
        Wood,
        Scrap
    }
}