using System.Collections.Generic;
using _.Scripts.GameplayResources;
using _.Scripts.Rafts.RaftParts;
using MyBase.Common.GameplayResources;
using UnityEngine;

namespace _.Scripts.Rafts.Conditions
{
    [CreateAssetMenu(fileName = "EmptyCondition", menuName = "Condition/Empty", order = 0)]
    public class EmptyCondition : Condition
    {
        public override bool Check(RaftPart[] parts)
        {
            Setting.NeedResources = new List<Resource>() { new WoodResource(2)};
            return true;
        }
    }
}