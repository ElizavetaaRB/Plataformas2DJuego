using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    [SerializeField] private float tiempoEntrDaño;
    [SerializeField] private int damage;
    private float tiempoDañonext;

    private void OnTriggerStay2D(Collider2D elotro)
    {
        if (elotro.gameObject.CompareTag("PlayerDetection") || elotro.gameObject.CompareTag("PlayerAreaCuerpo"))
        {
            tiempoDañonext -=Time.deltaTime;
            if (tiempoDañonext <= 0)
            {
                LifeSystem sistemavidasPlayer = elotro.gameObject.GetComponent<LifeSystem>();
                if (sistemavidasPlayer != null)
                {
                    sistemavidasPlayer.GetDamage(damage);
                    if (sistemavidasPlayer.Lifes <= 0)
                    {
                        sistemavidasPlayer.QuitGAME();
                    }
                    else
                    {
                        sistemavidasPlayer.UiLifeplayer(sistemavidasPlayer.Lifes);
                    }
                    tiempoDañonext = tiempoEntrDaño;
                }
            }
        }


    }
}
