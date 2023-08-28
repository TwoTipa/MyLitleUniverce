using System.Linq;
using MyBase.Common.GameplayResources;
using UnityEngine;

namespace _.Scripts.GameplayResources.ResourceContainers
{
    public class PlayerHand : ResourceContainer, IResourceGive, IResourceTake
    {
        public PlayerHand()
        {
            
        }

        public int ResourceCount
        {
            get
            {
                int ret = 0;

                foreach (var item in Resources)
                {
                    ret += item.Amount;
                }
                
                return ret;
            }
        }
        
        public void TakeResource(IResourceGive giver)
        {
            var takeResource = giver.GiveResource();
            AddResource(takeResource);
        }

        public Resource GiveResource()
        {
            throw new System.NotImplementedException();
        }

        public Resource GiveThisResource(Resource resource)
        {
            var reqResource = Resources.FirstOrDefault(x => x.Name == resource.Name);
            if (reqResource == null)
            {
                return new EmptyResource(0);
            }
            
            var ret = reqResource.CreateInstance();
            ret.Amount = 1;
            if (!TryRemoveResource(ret)) return new EmptyResource(0);
            return ret;
        }
    }
}