using System;
using UnityEngine;

namespace @_.Scripts.Rafts.Conditions
{
    public abstract class Condition : ScriptableObject
    {
        public RaftPartSetting Setting;

        public abstract bool Check(RaftPart[] part);
    }

}