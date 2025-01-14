using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxPushable : MonoBehaviour
{

    [SerializeField] private float force;
    [SerializeField] private Player player;

    private Vector2 playerDirection;


    public void Interactuar()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0) + (Vector3)playerDirection * force * Time.deltaTime;
    }




    private void OnCollisionEnter2D(Collision2D elotro)
    {
        if(elotro.gameObject.CompareTag("PlayerDetection") || elotro.gameObject.CompareTag("PlayerAreaCuerpo"))
        {
            playerDirection = elotro.transform.right;
            Interactuar();
        }
    }





}
