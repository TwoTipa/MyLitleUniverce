using System.Collections.Generic;
using System.Linq;
using _.Scripts.GameplayResources.MonoBehavior;
using _.Scripts.Rafts;
using MyBase.Common.GameplayResources;
using UnityEngine;

namespace _.Scripts.GameplayResources.ResourceContainers
{
    public class Builder : ResourceContainer, IResourceTake
    {
        private BuildersObject _me;
        private List<Resource> _needForBuild = new List<Resource>();
        
        public Builder(Resource[] needs, BuildersObject me)
        {
            _needForBuild = needs.ToList();
            _me = me;
        }

        public void TakeResource(IResourceGive giver)
        {
            if (_needForBuild.Count == 0 ) return;
            var newResource = giver.GiveThisResource(_needForBuild[0].CreateInstance());
            if(newResource == null | newResource is EmptyResource) return;
            AddResource(newResource);
            _needForBuild[0].Amount -= newResource.Amount;

            if (_needForBuild[0].Amount <= 0)
            {
                _needForBuild.RemoveAt(0);
            }
            
            if (_needForBuild.Count == 0)
            {
                BuildComplete();
            }
        }

        private void BuildComplete()
        {
            _me.OnBuild();
        }
    }
}