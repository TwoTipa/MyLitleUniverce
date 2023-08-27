using System.Collections.Generic;
using MyBase.Common.GameplayResources;
using Unity.VisualScripting;
using UnityEngine;

namespace _.Scripts.GameplayResources.ResourceContainers
{
    public class Chest : ResourceContainer, IResourceGive
    {
        public Chest(Resource[] resources) : base(resources)
        {
            
        }
        
        public Resource GiveResource()
        {
            Resource givenResource = Resources[0].CreateInstance();
            givenResource.Amount = 1;
            if (TryRemoveResource(givenResource))
            {
                return givenResource;
            }

            return new EmptyResource(0);
        }

        public Resource GiveThisResource(Resource resource)
        {
            throw new System.NotImplementedException();
        }
    }
}