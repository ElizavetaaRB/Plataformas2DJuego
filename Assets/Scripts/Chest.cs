using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractuable
{

    [SerializeField] private GameObject player;
    
    private Animator animator;
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
        animator.SetTrigger("ChestOpen");
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Destruir()
    {
        Destroy(gameObject);
    }

    }
