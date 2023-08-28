using MyBase.Common.GameplayResources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _.Scripts.Rafts.RaftParts
{
    [CreateAssetMenu(menuName = "RaftParts/BuilderPart", fileName = "BuilderPart")]
    public class BuilderPart : RaftPartContent, INotExpansion
    {
        public override void Execute()
        {
            
        }
    }
}