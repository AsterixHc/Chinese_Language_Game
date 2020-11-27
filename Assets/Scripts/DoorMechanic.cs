using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanic : MonoBehaviour
{
    public int DoorDamage;
    public bool DoorUnlocked = false;

    public void UnlockDoor()
    {
        //Destroy(this.gameObject);
        gameObject.SetActive(false);
    }
}
