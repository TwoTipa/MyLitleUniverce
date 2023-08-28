using System.Linq;
using _.Scripts.GameplayResources.ResourceContainers;
using _.Scripts.Rafts;
using MyBase.Common.GameplayResources;
using UnityEngine;

namespace @_.Scripts.GameplayResources.MonoBehavior
{
    public class ResourceContainerBehavior : MonoBehaviour, IIntaractableMonobeh
    {
        [SerializeField] private ContainerType type;
        private ResourceContainer _container;

        public void Initialization(ResourceContainer container)
        {
            _container = container;
        }

        public IInteractionType GetContainer()
        {
            return (IInteractionType)_container;
        }
    }

    public enum ContainerType
    {
        Chest,
        Generator
    }
}