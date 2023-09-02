using System;
using System.Collections.Generic;
using _.Scripts.GameplayResources;
using _.Scripts.Rafts.Conditions;
using _.Scripts.Ui.Windows;
using MyBase.Common.GameplayResources;
using UnityEngine;

namespace _.Scripts.Rafts
{
    public class ConditionChecker
    {
        private RaftPart _raftPart;
        private RaftPart[] _allParts;
        private SelectRaftPartCards _selector;
        private List<RaftPartSetting> _cards = new();
        private Condition[] _conditions;
        private Raft _raft;
        
        public ConditionChecker(RaftPart raftPart, SelectRaftPartCards selector, Condition[] conditions, RaftPart[] allParts)
        {
            _conditions = conditions;
            _raftPart = raftPart;
            _selector = selector;
            _allParts = allParts;
            _selector.SetPart(_raftPart);

            CheckConditions();
        }

        private void CheckConditions()
        {
            foreach (var item in _conditions)
            {
                if (item.Check(_allParts))
                {
                    _cards.Add(item.Setting);
                }
            }
            
            AddCards();
        }

        private void AddCards()
        {
            foreach (var item in _cards)
            {
                var raftPartSetting = item;

                var k = Vector3.Distance(Vector3.zero, _raftPart.transform.position)/10;

                foreach (var needResource in raftPartSetting.NeedResources)
                {
                    var tmpResource = needResource.Amount * k;
                    needResource.Amount = (int)tmpResource;
                }
                
                _selector.AddCard(raftPartSetting);
            }
        }
    }
}