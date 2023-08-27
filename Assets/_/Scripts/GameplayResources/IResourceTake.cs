namespace _.Scripts.GameplayResources
{
    public interface IResourceTake : IInteractionType
    {
        public void TakeResource(IResourceGive giver);
    }
}