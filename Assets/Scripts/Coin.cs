using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IInteractuable
{

    [SerializeField] private GameObject player;
    public void Interactuar()
    {
        Debug.Log("SE HA COGIDO POWER UP");
        if(player.GetComponent<Player>().FuerzaSalto == 29f)
        {
            player.GetComponent<Player>().Attackdamage = 40f;
        }
        else
        {
            player.GetComponent<Player>().FuerzaSalto = 29f;
        }
        Destroy(this.gameObject);
    }

}
