using System.Threading.Tasks;
using _.Scripts.Players;
using UnityEngine;

namespace _.Scripts.Rafts.RaftParts
{
    [CreateAssetMenu(menuName = "RaftParts/SelectorPart", fileName = "SelectorPart")]
    public class SelectorPart : RaftPartContent, ISelected, INotExpansion
    {
        public override void Enter(RaftPart part)
        {
            base.Enter(part);
            PlayerInteractor.OnInteractableTouch += Select;
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
            base.Exit();
            
            PlayerInteractor.OnInteractableTouch -= Select;
        }

        private void Select(Collision other)
        {
            if (other.gameObject == Model.gameObject)
            {
                MyParent.SwitchContent(PartNames.PreBuilder);
            }
        }
    }
}