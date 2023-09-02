using MyBase.Common.GameplayResources;
using UnityEngine;

namespace _.Scripts.GameplayResources
{
    public class ScrapResource : Resource
    {
        public ScrapResource(int amount) : base(amount)
        {
            Name = ResourceName.Scrap;
            Color = Color.blue;
            Image = Resources.Load<Sprite>("DynamicData/ResourceImage/itemicon_scrap");
        }

        public override Resource CreateInstance()
        {
            return new ScrapResource(Amount);
        }
    }
}