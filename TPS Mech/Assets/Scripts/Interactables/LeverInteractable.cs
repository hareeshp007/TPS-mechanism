
using UnityEngine;

public class LeverInteractable : MonoBehaviour, IInteractable
{
    public Animator Leveranimator;
    [SerializeField]
    private bool LeverOpen=false;
    public void OnInteract()
    {
        Debug.Log("interacted");
        LeverOpen = !LeverOpen;
        Leveranimator.SetBool("isOpen", LeverOpen);
    }
}
