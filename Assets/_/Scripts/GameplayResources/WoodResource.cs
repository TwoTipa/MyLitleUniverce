using MyBase.Common.GameplayResources;
using UnityEngine;

namespace _.Scripts.GameplayResources
{
    public class WoodResource : Resource
    {
        public WoodResource(int amount) : base(amount)
        {
            Name = ResourceName.Wood;
            Color = Color.red;
            Image = Resources.Load<Sprite>("DynamicData/ResourceImage/itemicon_tree");
        }

        public override Resource CreateInstance()
        {
            return new WoodResource(Amount);
        }
    }
}