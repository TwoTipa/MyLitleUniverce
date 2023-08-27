using Unity.VisualScripting;
using UnityEngine;

namespace _.Scripts.Players
{
    public class Move
    {
        private float _speed;
        private Vector3 _dir;
        private Transform _player;
        private Animator _model;
        private CharacterController _characterController;

        public Move(Transform meParent, float speed)
        {
            _player = meParent;
            _speed = speed;
            _model = _player.GetComponentInChildren<Animator>();
            
            _characterController = _player.AddComponent<CharacterController>();
            _characterController.radius = 0.1f;
            _characterController.height = 1;
        }
        
        public void MoveToDir(Vector3 dir)
        {

            _dir = dir.normalized;
            _characterController.Move(_dir * (_speed * Time.deltaTime));
            
            if (dir == Vector3.zero) return;
            var rot = Quaternion.LookRotation(_characterController.velocity.normalized);
            var transform = _model.transform;
            transform.rotation = rot;
            transform.localPosition = new Vector3(0, -0.57f, 0);
        }
    }
}