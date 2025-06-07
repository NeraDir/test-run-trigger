using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable item))
        {
            item.OnEnter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable item))
        {
            item.OnExit();
        }
    }
}
