using System;
using System.Collections.Generic;
using System.Linq;
using MyBase.Common.GameplayResources;
using Unity.VisualScripting;
using UnityEngine;

namespace _.Scripts.GameplayResources
{
    public abstract class ResourceContainer : IResourceContainer
    {
         protected readonly List<Resource> Resources = new();

        protected ResourceContainer(Resource[] resources)
        {
            Resources.AddRange(resources);
        }

        protected ResourceContainer()
        {
            
        }
        
        public void AddResource(Resource addedResource)
        {
            if(addedResource is EmptyResource | addedResource == null) return;
            var resource = Resources.FirstOrDefault(p => p.Name == addedResource.Name);
            
            if (resource != null)
            {
                resource.Amount += addedResource.Amount;
            }
            else
            {
                Resources.Add(addedResource.CreateInstance());
            }
        }
        
        public bool TryRemoveResource(Resource removedResource)
        {
            var resource = Resources.FirstOrDefault(p => p.Name == removedResource.Name);
            if (resource == null) return false;

            if (resource.Amount < removedResource.Amount) return false;
            resource.Amount -= removedResource.Amount;
         
            Debug.Log($"Отнимаем из {resource.Name} {removedResource.Amount} Осталось {resource.Amount}");

            if (resource.Amount <= 0)
            {
                Resources.Remove(resource);
            }

            return true;
        }

        public void Subscribe()
        {
            
        }

        public void UnSubscribe()
        {
            
        }
    }
}