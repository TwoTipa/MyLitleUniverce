using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _.Scripts.Players;
using _.Scripts.Rafts.RaftParts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace _.Scripts.Rafts
{
    public class Raft : MonoBehaviour
    {
        public static Dictionary<PartNames, RaftPartContent> PartsList = new();
        public int CellSize => cellSize;
        public Player Player { get; private set; }

        [SerializeField] private Transform raftPartContainer;
        [SerializeField] private int raftLenght = 6;
        [SerializeField] private int raftWeight = 6;
        [SerializeField] private int cellSize = 1;

        private RaftPart _raftPartPrefab;

        private readonly Dictionary<Vector2Int, RaftPart> _allParts = new();

        #region Editor
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (Application.isPlaying) return;
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(transform.position, new Vector3(raftLenght * cellSize, 1, raftWeight * cellSize) * 0.99f);
        }
#endif

        #endregion

        public void Initialization(Player player)
        {
            Player = player;
            PartsList.Add(PartNames.Empty, Resources.Load<EmptyPart>("RaftParts/EmptyPart"));
            PartsList.Add(PartNames.Selector, Resources.Load<SelectorPart>("RaftParts/SelectorPart"));
            PartsList.Add(PartNames.PreBuilder, Resources.Load<PreBuilderPart>("RaftParts/PreBuilderPart"));
            PartsList.Add(PartNames.Builder, Resources.Load<BuilderPart>("RaftParts/BuilderPart"));
            
            _raftPartPrefab = Resources.Load<RaftPart>("GamePlay/RaftPart");
            StartRaftBuild();
        }

        public bool TryBuildPart(Vector2Int pos)
        {
            if(_allParts.ContainsKey(pos)) return false;

            var newPart = BuildRaftPart(pos);
            newPart.Initialize(new Vector2(cellSize, cellSize), this);

            _allParts.Add(pos, newPart);
            return true;
        }
        public async Task<bool> TryBuildPart(Vector2Int pos, PartNames type)
        {
            if(_allParts.ContainsKey(pos)) return false;

            var newPart = BuildRaftPart(pos);
            await newPart.Initialize(new Vector2(cellSize, cellSize), this, type);
            
            _allParts.Add(pos, newPart);
            return true;
        }

        private RaftPart BuildRaftPart(Vector2Int pos)
        {
            var localPos = new Vector3(pos.x, 0, pos.y) * cellSize;
            var newPart = Instantiate(_raftPartPrefab, Vector3.zero, Quaternion.identity, raftPartContainer);
            newPart.transform.localPosition = localPos;
            return newPart;
        }

        private void StartRaftBuild()
        {
            for (int i = 0; i < raftLenght; i++)
            {
                for (int j = 0; j < raftWeight; j++)
                {
                    var res = TryBuildPart(new Vector2Int(i, j), PartNames.Empty).Result;
                    if (!res)
                    {
                        var pos = new Vector2Int(i, j);
                        _allParts[pos].SwitchContent(PartNames.Empty);
                    }
                }
            }
        }
    }

}