using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _.Scripts.Rafts.RaftParts;
using UnityEngine;

namespace _.Scripts.Rafts
{
    public class RaftPart : MonoBehaviour
    {
        public Raft Raft => _raft;
        private RaftPartContent _content;
        private Raft _raft;

        public Task Initialize(Vector2 cellSize, Raft raft)
        {
            _raft = raft;
            transform.localScale = new Vector3(cellSize.x, 1, cellSize.y);
            SwitchContent(PartNames.Selector);
            
            SetNeighbor();
            return Task.CompletedTask;
        }
        
        public Task Initialize(Vector2 cellSize, Raft raft, PartNames type)
        {
            _raft = raft;
            transform.localScale = new Vector3(cellSize.x, 1, cellSize.y);
            SwitchContent(type);
            
            if (_content is SelectorPart) return Task.CompletedTask;
            SetNeighbor();
            return Task.CompletedTask;
        }

        public RaftPartContent SwitchContent(PartNames newContent)
        { 
            if (_content != null)
                _content.Exit();
            _content = Instantiate(Raft.PartsList[newContent], transform); 
            _content.Enter(this);
            
            SetNeighbor();

            return _content;
        }
        
        private void Update()
        {
            _content.Execute();
        }

        private void SetNeighbor()
        {
            if (_content is INotExpansion) return;
            var position = transform.localPosition / _raft.CellSize;
            _raft.TryBuildPart(new Vector2Int((int)position.x+1, (int)position.z));
            _raft.TryBuildPart(new Vector2Int((int)position.x-1, (int)position.z));
            _raft.TryBuildPart(new Vector2Int((int)position.x, (int)position.z+1));
            _raft.TryBuildPart(new Vector2Int((int)position.x, (int)position.z-1));
        }
    }
    
    public enum PartNames
    {
        Empty,
        Selector,
        PreBuilder,
        Builder
    }
}