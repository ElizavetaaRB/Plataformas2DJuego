using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;





public class SpawnBat : MonoBehaviour
{
    [SerializeField] private Murcielago batprefab;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float timemaxSpawn;
    [SerializeField] private int maxbat;
    private float timer;
    private int actualbats;

    void Start()
    {
        actualbats = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timemaxSpawn && actualbats < maxbat)
        {
            Murcielago batcopy = Instantiate(batprefab,new Vector3(Random.Range(15f,20f),Random.Range(12f,16f),0),Quaternion.identity);
            Murcielago.counterbat++;
            actualbats = Murcielago.counterbat;
           // Debug.Log(Murcielago.counterbat);
            batcopy.Waypoints = waypoints;



            timer = 0f;
        }
    }
}
