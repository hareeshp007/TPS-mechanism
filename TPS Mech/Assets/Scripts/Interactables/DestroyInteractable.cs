using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInteractable : MonoBehaviour,IInteractable
{
    public void OnInteract()
    {
        this.gameObject.SetActive(false);
    }
}
