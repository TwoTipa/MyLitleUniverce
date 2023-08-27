using System;
using MyBase.Common.GameplayResources;
using UnityEngine;
using Random = UnityEngine.Random;

namespace @_.Scripts.GameplayResources.MonoBehavior
{
    public class ResourceBehavior : MonoBehaviour, IIntaractableMonobeh, IResourceGive
    {
        private Resource _resource;
        private bool _inWorld = true;
        
        public void Initialization(Resource resource)
        {
            _resource = resource.CreateInstance();

            MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
            propertyBlock.SetColor("_Color", _resource.Color);
            GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        
        private void Start()
        {
            Resource randomResource;
            if (Random.value > 0.5f)
            {
                randomResource = new WoodResource(1);
            }
            else
            {
                randomResource = new ScrapResource(1);
            }
            
            Initialization(randomResource);
        }

        public IInteractionType GetContainer()
        {
            return this;
        }

        public Resource GiveResource()
        {
            if (!_inWorld) return new EmptyResource(0);

            _inWorld = false;
            gameObject.SetActive(false);
            return _resource.CreateInstance();
        }

        public Resource GiveThisResource(Resource resource)
        {
            return _resource.CreateInstance();
        }
    }
}