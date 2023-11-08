

using TPShooter.UI;
using UnityEngine;

namespace TPShooter.Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;

        public CharacterController Controller;
        public Transform Camera;
        public Animator PlayerAnimator;
        public Transform GroundCheck;
        public LayerMask GroundMask;
        public LayerMask InteractorSource;
        public float InteractorRange;
        public ThirdPersonCameraLook CinemachineCamera;

        [Header("Movement")]
        [SerializeField]
        private float horizontal;
        [SerializeField]
        private float vertical;
        [SerializeField]
        private Vector3 direction;
        [SerializeField]
        private Vector3 Movedirection;
        [Header("Jump")]
        [SerializeField]
        private float groundDistance = 0.4f;
        [SerializeField]
        private bool isGrounded;
        [SerializeField]
        private InGameUIManager gameUIManager;

#if UNITY_ANDROID
        [SerializeField]
        private Joystick joystick;
        [SerializeField]
        private Joystick camerajoystick;
        [SerializeField]
        private UnityEngine.UI.Button jumpButton;
        [SerializeField]
        private UnityEngine.UI.Button interactButton;
        [SerializeField]
        private UnityEngine.UI.Button RunButton;

#endif
        private void Start()
        {
#if UNITY_STANDALONE_WIN
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
#endif
#if UNITY_ANDROID
            UnityEngine.Cursor.lockState = CursorLockMode.None;
#endif
        }
        void Update()
        {
            inputHandle();
            setAnimationParameters();
            checks();
            PhysicsExternal();
        }

        private void PhysicsExternal()
        {
            Vector3 velocity = playerController.PhysicsExternal(isGrounded);
            Debug.Log(velocity);
            Controller.Move(velocity);
        }

        private void checks()
        {
            isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, GroundMask);
            if (direction.magnitude > 0)
            {
                Vector3 Movement = playerController.TPMovement(direction, Movedirection, transform.eulerAngles) * Time.deltaTime;
                Controller.Move(Movement);
            }
        }

        private void setAnimationParameters()
        {
            float MovementSpeed = playerController.CurrentSpeed() * direction.magnitude;
            PlayerAnimator.SetFloat("speed", MovementSpeed);
            PlayerAnimator.SetBool("isGrounded", isGrounded);
        }

        private void inputHandle()
        {
#if UNITY_ANDROID
            horizontal = joystick.Horizontal;
            vertical = joystick.Vertical;
            direction = new Vector3(horizontal, 0f, vertical).normalized;
            Debug.Log(direction);
            CinemachineCamera.setJoystick(camerajoystick);

#endif
#if UNITY_STANDALONE_WIN
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            direction = new Vector3(horizontal, 0f, vertical).normalized;
            if (isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jump();
                }
                if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
                {
                    run();
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interact();
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    escape()
                }
#endif
        }
        private void escape()
        {
            if (Time.timeScale != 0)
            {
                gameUIManager.Pause();
            }
            else
            {
                gameUIManager.Resume();
            }

        }

        private void interact()
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, InteractorRange, InteractorSource);
            foreach (Collider collider in colliderArray)
            {
                collider.gameObject.GetComponent<IInteractable>().OnInteract();
            }
        }

        public void SetPlayerController(PlayerController _playerController)
        {
            playerController = _playerController;
            Debug.Log("Controller-View Connection");
        }

        public void RotatePlayer(float angleRotation)
        {
            transform.rotation = Quaternion.Euler(0f, angleRotation, 0f);
        }

        public void setUiManager(InGameUIManager inGameUIManager)
        {
            gameUIManager = inGameUIManager;
#if UNITY_ANDROID
            SetJoysticks();
#endif
        }

        public void SetJoysticks()
        {
            joystick = gameUIManager.PlayerJoystick;
            camerajoystick= gameUIManager.CameraJoystick;
            jumpButton=gameUIManager.Jump;
            RunButton = gameUIManager.Run;
            interactButton = gameUIManager.Interact;
            RunButton.onClick.AddListener(run);
            jumpButton.onClick.AddListener(jump);
            interactButton.onClick.AddListener(interact);
            
        }

        private void run()
        {
            playerController.Changespeed();
        }

        private void jump()
        {if(isGrounded)
            {
                PlayerAnimator.SetTrigger("Jump");
                playerController.Jump();
            }
        }
    }
}