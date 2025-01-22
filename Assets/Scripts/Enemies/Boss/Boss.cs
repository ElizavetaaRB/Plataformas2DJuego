using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [Header("Attack system")]
    [SerializeField] private int damage;
    [SerializeField] private float petrify_duration;

    public float Petrify_duration { get => petrify_duration; }
    public int Damage { get => damage; }

}
