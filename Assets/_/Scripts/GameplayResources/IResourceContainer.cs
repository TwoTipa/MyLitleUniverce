using MyBase.Common.GameplayResources;

namespace _.Scripts.GameplayResources
{
    public interface IResourceContainer
    {
        public void AddResource(Resource addedResource);

        public bool TryRemoveResource(Resource removedResource);
    }
}