using System;
using System.Collections.Generic;
using _.Scripts.GameplayResources;
using MyBase.Common.GameplayResources;

namespace _.Scripts.Rafts
{
    [Serializable]
    public struct RaftPartSetting
    {
        public PartNames Name;
        public List<Resource> NeedResources;
    }
}