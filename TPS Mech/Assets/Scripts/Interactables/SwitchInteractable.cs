
using UnityEngine;

namespace TPShooter.Interactable
{
    public class SwitchInteractable : MonoBehaviour, IInteractable
    {
        public Animator SwitchAnimator;
        public void OnInteract()
        {
            Debug.Log("switch interacted");
            SwitchAnimator.SetBool("ButtonPressed", true);
        }


    }
}
