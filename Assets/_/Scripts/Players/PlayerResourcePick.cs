using System;
using System.Collections.Generic;
using _.Scripts.GameplayResources;
using _.Scripts.GameplayResources.ResourceContainers;
using MyBase.Common.GameplayResources;
using UnityEngine;

namespace _.Scripts.Players
{
    public class PlayerResourcePick : MonoBehaviour
    {
        private int _storageMax;
        private PlayerHand _hand;

        public void Initialization(int maxStorage)
        {
            _storageMax = maxStorage;
            _hand = new PlayerHand();
        }

        public ResourceContainer GetContainer()
        {
            return _hand;
        }

        public void Pick(Collision other)
        {
            var interact = other.transform.GetComponent<IIntaractableMonobeh>();
            if (interact == null) return;
            var container = interact.GetContainer();
            switch (container)
            {
                case IResourceGive give:
                    if (_hand.ResourceCount >= _storageMax) return;
                    _hand.TakeResource(give);
                    break;
                case IResourceTake take:
                    take.TakeResource(_hand);
                    break;
                default:
                    Debug.Log("Я ?ч ");
                    break;
            }
        }
    }
}