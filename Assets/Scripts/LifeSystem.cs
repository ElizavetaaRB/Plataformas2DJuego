using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private GameObject exitMenu;
    [SerializeField] private int lifes;
    [SerializeField] private TextMeshProUGUI playerlifes;

    public int Lifes { get => lifes; }

    public void GetDamage(int damage)
    {
        lifes -= damage;
        
        if(lifes <= 0)
        {

            Destroy(gameObject);
        }
    }

    public void QuitGAME()
    {
        playerlifes.text = "Lifes: 0";
        exitMenu.SetActive(true);
    }

    public void UiLifeplayer(int vidasplayer)
    {
        playerlifes.text = "Lifes: " + vidasplayer;
    }



}
