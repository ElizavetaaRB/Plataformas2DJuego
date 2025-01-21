using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractuable
{

    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshPro jumpUI;
    [SerializeField] private TextMeshPro attackUI;
    private Animator animator;
    public void Interactuar()
    {
        Debug.Log("SE HA COGIDO POWER UP");
        if(player.GetComponent<Player>().FuerzaSalto == 29f)
        {
            player.GetComponent<Player>().Attackdamage = 40;
            attackUI.gameObject.SetActive(true);
            
        }
        else
        {
            player.GetComponent<Player>().FuerzaSalto = 29f;
            jumpUI.gameObject.SetActive(true);
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
