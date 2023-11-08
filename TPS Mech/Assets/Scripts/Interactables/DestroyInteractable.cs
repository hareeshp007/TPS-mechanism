
using UnityEngine;

namespace TPShooter.Interactable
{
    public class DestroyInteractable : MonoBehaviour, IInteractable
    {
        public void OnInteract()
        {
            this.gameObject.SetActive(false);
        }
    }
}