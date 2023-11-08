
using System;
using TPShooter.UI;
using UnityEngine;
namespace TPShooter.Player
{
    public class PlayerServices : MonoSingletonGeneric<PlayerServices>
    {
        
        public PlayerScriptableObject PlayerSO;
        [SerializeField]
        private Transform StartPoint;
        [SerializeField]
        private InGameUIManager GameUI;
        [SerializeField]
        private PlayerController playerController;
        [SerializeField]
        private PlayerView playerView;
        [SerializeField]
        private PlayerModel playerModel;

        private void Awake()
        {
            base.Awake();
            SpawnPlayer();
            Time.timeScale = 1.0f;
        }

        private void SpawnPlayer()
        {
            this.playerModel = new PlayerModel(PlayerSO);
            this.playerView = GameObject.Instantiate<PlayerView>(PlayerSO.player,StartPoint);
            this.playerController=new PlayerController(this.playerModel,this.playerView);
            
        }
        public void SetUIManager(InGameUIManager InGameUIManager)
        {
            GameUI=InGameUIManager;
            this.playerView.setUiManager(GameUI);
        }

    }
}

