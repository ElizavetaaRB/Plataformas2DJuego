using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractuable
{
    public void Interactuar()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        Destroy(gameObject);
    }
}
