using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GunScriptableObject newGun;
    public Gun playerGun;
    private void Start()
    {
        playerGun = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Gun>();
    }
    public void Interact()
    {
        playerGun.gunScriptableObject = newGun;
        playerGun.UpdateMaterial();
    }
}
