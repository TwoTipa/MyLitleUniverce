using MyBase.Common.GameplayResources;

namespace _.Scripts.GameplayResources
{
    public class EmptyResource : Resource
    {
        public EmptyResource(int amount) : base(amount)
        {
        }

        public override Resource CreateInstance()
        {
            return new EmptyResource(0);
        }
    }
}