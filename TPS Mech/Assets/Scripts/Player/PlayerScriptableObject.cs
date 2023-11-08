using UnityEngine;

namespace TPShooter.Player
{
    [CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObject/Player/NewPlayer")]
    public class PlayerScriptableObject : ScriptableObject
    {
        public int health;
        public int maxHealth;
        public int Speed;
        public int RunSpeed;
        public float jumpHeight;
        public float JumpVariable; 
        public float Gravity; 
        public float turnTime;
        public float MinYVelocity;
        public PlayerView player;

        
    }

}

