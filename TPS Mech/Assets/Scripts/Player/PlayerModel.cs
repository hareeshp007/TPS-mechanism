using System;
using UnityEngine;

namespace TPShooter.Player
{
    public class PlayerModel
    {
        private PlayerController playerController;

        public int health { get; private set; }
        public int Maxhealth { get; private set; }
        public int Speed { get; private set; }
        public int RunSpeed { get; private set; }
        public float JumpHeight { get; private set; }
        public float JumpVariable{ get; private set; }
        public float Gravity { get; private set; }
        public float turnTime { get; private set; }
        public float MinYVelocity { get; private set; }

        public int CurrentSpeed { get; private set; }
        public void SetPlayerController(PlayerController Controller)
        {
            this.playerController = Controller;
            Debug.Log("Controller-Model Connection");
        }
        public int SetHealth(int _health)
        {
            health = _health;
            return health;
        }
        public PlayerModel(PlayerScriptableObject playerSO)
        {
            SetValues(playerSO);
        }
        public void SetValues(PlayerScriptableObject playerSO)
        {
            Maxhealth = playerSO.maxHealth;
            health = Maxhealth;
            Speed = playerSO.Speed;
            RunSpeed = playerSO.RunSpeed;
            JumpHeight = playerSO.jumpHeight;
            JumpVariable = playerSO.JumpVariable;
            Gravity = playerSO.Gravity;
            turnTime = playerSO.turnTime;
            MinYVelocity= playerSO.MinYVelocity;
            CurrentSpeed = Speed;
        }
        public void SetCurrentSpeed()
        {
            if(CurrentSpeed == RunSpeed)
            {
                CurrentSpeed = Speed;
            }
            else
            {
                CurrentSpeed = RunSpeed;
            }
            
        }
    }

}