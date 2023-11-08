using UnityEngine;

namespace TPShooter.Interactable
{
    public class GateInteractable : MonoBehaviour, IInteractable
    {
        public Animator GateAnimator;
        [SerializeField]
        private bool GateOpen = false;

        public void OnInteract()
        {
            GateOpen = !GateOpen;
            GateAnimator.SetBool("OpenGate", GateOpen);
        }
    }
}

