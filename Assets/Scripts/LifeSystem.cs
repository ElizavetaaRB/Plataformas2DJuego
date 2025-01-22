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


    private float blinkdura = 0.5f;

    public int Lifes { get => lifes; set => lifes = value; }

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
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        playerlifes.color = Color.yellow;
        yield return new WaitForSeconds(blinkdura);
        playerlifes.color = Color.white;

    }

    }
