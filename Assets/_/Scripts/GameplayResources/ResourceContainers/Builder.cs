using System.Collections.Generic;
using System.Linq;
using _.Scripts.GameplayResources.MonoBehavior;
using _.Scripts.Rafts;
using MyBase.Common.GameplayResources;
using TMPro;
using UnityEngine;

namespace _.Scripts.GameplayResources.ResourceContainers
{
    public class Builder : ResourceContainer, IResourceTake
    {
        private RaftPart _me;
        private PartNames _name;
        private List<Resource> _needForBuild = new List<Resource>();
        private TextMeshProUGUI _textField;
        
        public Builder(Resource[] needs, RaftPart part)
        {
            _needForBuild = needs.ToList();
            _me = part;
        }

        public void TakeResource(IResourceGive giver)
        {
            
            if (_needForBuild.Count == 0 ) return;
            var newResource = giver.GiveThisResource(_needForBuild[0].CreateInstance());
            if(newResource == null | newResource is EmptyResource) return;
            AddResource(newResource);
            _needForBuild[0].Amount -= newResource.Amount;

            _textField.text = _needForBuild[0].Amount.ToString();
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
            _me.SwitchContent(_name);
        }

        public override void Subscribe(TextMeshProUGUI text)
        {
            _textField = text;
        }
    }
}