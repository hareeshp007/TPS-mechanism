
using UnityEngine;
namespace TPShooter.Player
{
    public class PlayerServices : MonoSingletonGeneric<PlayerServices>
    {
        public Transform StartPoint;
        public PlayerScriptableObject PlayerSO;
        [SerializeField]
        private PlayerController playerController;
        [SerializeField]
        private PlayerView playerView;
        [SerializeField]
        private PlayerModel playerModel;

        private void Start()
        {
            SpawnPlayer();
        }
        private void SpawnPlayer()
        {
            this.playerModel = new PlayerModel(PlayerSO);
            this.playerView = GameObject.Instantiate<PlayerView>(PlayerSO.player,StartPoint);
            this.playerController=new PlayerController(this.playerModel,this.playerView);
        }
    }
}

