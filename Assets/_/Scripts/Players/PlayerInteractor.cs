using System;
using _.Scripts.Rafts;
using Unity.VisualScripting;
using UnityEngine;

namespace _.Scripts.Players
{
    public class PlayerInteractor
    {
        public static event Action<Collision> OnInteractableTouch;
        public static event Action<Collision> OnInteractableTouchOut;
        public void Interact(Collision other)
        {
            if (other.gameObject.CompareTag("Interactable"))
            {
                OnInteractableTouch?.Invoke(other);
            }
        }
        
        public void InteractOut(Collision other)
        {
            if (other.gameObject.CompareTag("Interactable"))
            {
                OnInteractableTouchOut?.Invoke(other);
            }
        }
    }
}