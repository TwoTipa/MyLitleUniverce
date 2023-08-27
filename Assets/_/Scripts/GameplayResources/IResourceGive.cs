using MyBase.Common.GameplayResources;

namespace _.Scripts.GameplayResources
{
    public interface IResourceGive : IInteractionType
    { 
        public Resource GiveResource();
        public Resource GiveThisResource(Resource resource);
    }
}