using UnityEngine;

namespace _.Scripts.Rafts
{
    public abstract class RaftPartContent : ScriptableObject
    {
        [SerializeField] protected GameObject modelPrefab;
        public GameObject Model { get; protected set; }
        protected RaftPart MyParent;

        public virtual void Enter(RaftPart part)
        {
            MyParent = part;
            var parentTransform = MyParent.transform;
            Model = Instantiate(modelPrefab, parentTransform.position, Quaternion.identity, parentTransform);
        }
        public abstract void Execute();

        public virtual void Exit()
        {
            Destroy(Model);
        }
    }
}