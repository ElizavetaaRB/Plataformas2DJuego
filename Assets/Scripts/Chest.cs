using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractuable
{

    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI jumpUI;
    [SerializeField] private TextMeshProUGUI attackUI;
    private Animator animator;
    public void Interactuar()
    {
        Debug.Log("SE HA COGIDO POWER UP");
        if(player.GetComponent<Player>().FuerzaSalto == 29f)
        {
            player.GetComponent<Player>().Attackdamage = 40;
            attackUI.enabled = true;
            
        }
        else
        {
            player.GetComponent<Player>().FuerzaSalto = 29f;
            jumpUI.enabled = true;
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
