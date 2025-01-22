using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bendicion : MonoBehaviour, IInteractuable
{
    [SerializeField] private Player player;

    public void Interactuar()
    {
        player.GetComponent<LifeSystem>().Lifes = 180;
        player.GetComponent<LifeSystem>().UiLifeplayer(player.GetComponent<LifeSystem>().Lifes);
    }




}
