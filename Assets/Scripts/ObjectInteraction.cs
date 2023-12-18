using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class ObjectInteraction : MonoBehaviour
{
    private StarterAssetsInputs _input;
    public float interactionDistance = 2f;
    public Transform firepoint;
    private void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        if (_input.interact)
        {
            RaycastHit hit;
            if (Physics.Raycast(firepoint.position, firepoint.forward, out hit, interactionDistance))
            {
                InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();

                if (interactableObject != null)
                {
                    interactableObject.Interact();
                }
            }
            _input.interact = false;
        }
    }
}
