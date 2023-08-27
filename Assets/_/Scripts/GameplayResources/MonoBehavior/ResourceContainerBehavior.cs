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

        public void Initialization()
        {
            
        }

        public IInteractionType GetContainer()
        {
            return (IInteractionType)_container;
        }

        
        private void Start()
        {
            SetContainer();
        }

        private void SetContainer()
        {
            
            Resource[] resources = new Resource[] { new ScrapResource(10), new WoodResource(15) };
            switch (type)
            {
                case ContainerType.Chest:
                    
                    _container = new Chest(resources);
                    
                    break;
                case ContainerType.Generator:
                    _container = new Chest(resources);
                    break;
                default:
                    
                    break;
            }
        }
    }

    public enum ContainerType
    {
        Chest,
        Generator
    }
}