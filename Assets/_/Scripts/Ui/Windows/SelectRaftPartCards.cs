using System;
using _.Scripts.GameplayResources;
using _.Scripts.GameplayResources.ResourceContainers;
using _.Scripts.Rafts;
using MyBase.Common.GameplayResources;
using MyBase.Common.Ui;
using UnityEngine;

namespace _.Scripts.Ui.Windows
{
    public class SelectRaftPartCards : WindowBase
    {
        [SerializeField] private Transform content;
        private RaftPartCard _raftPartCardPrefab;
        private RaftPart _part;

        public void AddCard()
        {
            if (_raftPartCardPrefab == null)
                _raftPartCardPrefab = Resources.Load<RaftPartCard>("Ui/Windows/RaftPartCard");
            var newCard = Instantiate(_raftPartCardPrefab, content);
            var setting = new RaftPartSetting();
            setting.Name = PartNames.Empty;
            Resource[] needResources = {new WoodResource(2)};
            setting.NeedResources = needResources;
            newCard.Initialize(setting, _part);
        }

        public void SetPart(RaftPart part)
        {
            _part = part;
        }
    }
}