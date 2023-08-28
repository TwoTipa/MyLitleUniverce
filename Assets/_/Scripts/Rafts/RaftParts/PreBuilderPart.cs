using _.Scripts.Players;
using _.Scripts.Ui.Windows;
using MyBase.Common.Ui;
using UnityEngine;

namespace _.Scripts.Rafts.RaftParts
{
    [CreateAssetMenu(menuName = "RaftParts/PreBuilderPart", fileName = "PreBuilderPart")]
    public class PreBuilderPart : RaftPartContent, INotExpansion
    {
        private const float DistToDeselect = 2.2f;
        private float _distanceToPlayer;
        private Transform _player;
        private RaftPartContent _oldState;
        private ConditionChecker _conditionChecker;
        
        public override void Enter(RaftPart part)
        {
            base.Enter(part);
            
            _player = MyParent.Raft.Player.transform;
            var win = App.WindowManager.Show<SelectRaftPartCards>();
            _conditionChecker = new ConditionChecker(MyParent, win);
        }

        public override void Execute()
        {
            _distanceToPlayer = Vector3.Distance(_player.position, MyParent.transform.position);
            if (_distanceToPlayer > DistToDeselect)
            {
                Deselect();
            }
        }

        public override void Exit()
        {
            base.Exit();
            
            App.WindowManager.Close<SelectRaftPartCards>();
        }

        private void Deselect()
        {
            MyParent.SwitchContent(PartNames.Selector);
        }
    }
}