using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Boss : MonoBehaviour
{
    [Header("Attack system")]
    [SerializeField] private int damage;
    [SerializeField] private float petrify_duration;


    public float Petrify_duration { get => petrify_duration; }
    public int Damage { get => damage; }






}
