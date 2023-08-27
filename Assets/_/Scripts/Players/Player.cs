using System;
using _.Scripts.GameplayResources;
using UnityEngine;

namespace _.Scripts.Players
{
    public class Player : MonoBehaviour, ISystem, IMovable
    {
        [SerializeField] private float speed;
        [SerializeField] private int maxSlotToHand;
        
        private Move _move;
        private PlayerResourcePick _resourcePick;
        private PlayerInteractor _playerInteract;
        private PlayerAnimator _playerAnimator;
        
        public void Initialization()
        {
            _move = new Move(transform, speed);
            _move.MoveToDir(Vector3.zero);

            var newResourcePick = new GameObject("Hand").AddComponent<PlayerResourcePick>();
            newResourcePick.transform.SetParent(transform);
            newResourcePick.Initialization(maxSlotToHand);
            _resourcePick = newResourcePick;
            _resourcePick.transform.localPosition = Vector3.zero;

            _playerAnimator = new PlayerAnimator(GetComponent<CharacterController>(), GetComponentInChildren<Animator>());
            
            _playerInteract = new PlayerInteractor();
        }

        private void Update()
        {
            ButtonController();
            _playerAnimator.Execute();
            
#if DEBUG
            TestController();
#endif
        }
        
        private void OnCollisionEnter(Collision other)
        {
            _resourcePick.Pick(other);
            _playerInteract.Interact(other);
        }

        private void OnCollisionExit(Collision other)
        {
            _playerInteract.InteractOut(other);
        }

        private void TestController()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                
            }
        }
        
        private void ButtonController()
        {
            Vector3 dir = Vector3.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir += Vector3.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                dir += Vector3.right;
            }
            if (Input.GetKey(KeyCode.W))
            {
                dir += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                dir += Vector3.back;
            }
            _move.MoveToDir(dir);
        }
    }
}