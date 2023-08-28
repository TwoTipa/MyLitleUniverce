using System;
using _.Scripts.Players;
using _.Scripts.Rafts;
using _.Scripts.Ui.Windows;
using MyBase.Common;
using MyBase.Common.Ui;
using UnityEngine;
using UnityEngine.Serialization;

namespace _.Scripts
{
    public class App : Singleton<MonoBehaviour>
    {
        public static WindowManager WindowManager;

        [SerializeField] private Raft raft;
        [SerializeField] private Player player;

        public override void Touch()
        {
            base.Touch();
            
            
        }

        protected override void Awake()
        {
            base.Awake();
            
            WindowManager = new GameObject("WindowManager").AddComponent<WindowManager>();
            WindowManager.transform.SetParent(transform);

            player.Initialization();
            raft.Initialization(player);
        }

        private void Start()
        {
            WindowManager.Show<GamePlayUi>();
        }

        private void OnEnable()
        {
            MainMenuWindow.MainMenuOpen += OnMainMenuOpen;
        }

        private void OnDisable()
        {
            MainMenuWindow.MainMenuOpen -= OnMainMenuOpen;
        }

        private void OnMainMenuOpen(bool obj)
        {
            
        }
    }
}