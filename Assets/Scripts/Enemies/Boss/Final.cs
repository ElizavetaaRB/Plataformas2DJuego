using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Final : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Boss thisboss;
    [SerializeField] private GameObject completed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thisboss.IsDestroyed())
        {
            completed.SetActive(true);
        }
    }
}
