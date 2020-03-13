using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAllMagnets : MonoBehaviour
{
    [SerializeField] GameObject[] magnets;

    public void OnPressed()
    {
        for (int i = 0; i < magnets.Length; i++)
        {
            magnets[i].SetActive(true);            
        }
    }
}
