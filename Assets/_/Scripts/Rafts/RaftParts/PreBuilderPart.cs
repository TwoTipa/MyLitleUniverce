using _.Scripts.Players;
using _.Scripts.Ui.Windows;
using MyBase.Common.Ui;
using UnityEngine;

namespace _.Scripts.Rafts.RaftParts
{
    [CreateAssetMenu(menuName = "RaftParts/PreBuilderPart", fileName = "PreBuilderPart")]
    public class PreBuilderPart : RaftPartContent, INotExpansion
    {
        private float _startDistanceToPlayer;
        private float _distanceToPlayer;
        private Transform _player;
        private RaftPartContent _oldState;
        public override void Enter(RaftPart part)
        {
            base.Enter(part);

            _player = MyParent.Raft.Player.transform;
            _startDistanceToPlayer = Vector3.Distance(_player.position,MyParent.transform.position);
            App.WindowManager.Show<SelectRaftPartCards>();
        }

        public override void Execute()
        {
            _distanceToPlayer = Vector3.Distance(_player.position, MyParent.transform.position);
            if (_distanceToPlayer > 2.2f)
            {
                MyParent.SwitchContent(PartNames.Selector);
            }
        }

        public override void Exit()
        {
            base.Exit();
            
            App.WindowManager.Close<SelectRaftPartCards>();
        }

        private void Deselect(Collision other)
        {
            MyParent.SwitchContent(PartNames.Selector);
        }
    }
}