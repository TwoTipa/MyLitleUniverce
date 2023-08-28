using System;
using _.Scripts.Ui.Windows;
using UnityEngine;

namespace _.Scripts.Rafts
{
    public class ConditionChecker
    {
        private RaftPart _raftPart;
        private SelectRaftPartCards _selector;
        
        public ConditionChecker(RaftPart raftPart, SelectRaftPartCards selector)
        {
            _raftPart = raftPart;
            _selector = selector;
            _selector.SetPart(_raftPart);

            CheckConditions();
        }

        private void CheckConditions()
        {
            _selector.AddCard();
            _selector.AddCard();
            _selector.AddCard();
        }
    }
}