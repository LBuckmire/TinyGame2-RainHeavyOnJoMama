using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodlock : MonoBehaviour
{
    public GameObject[] Activate;
    public GameObject TObject;
    public bool ETarget;
    bool Finalobject = false;

    void Start()
    {
        if (ETarget) TObject.SetActive(false);
    }

    void Update()
    {
        int Objectsleft = Activate.Length;

        foreach(GameObject _gameobject in Activate)
        {
            if (!_gameobject) Objectsleft--;
        }

        if(Objectsleft <1 && Finalobject == false)
        {
            if (ETarget)
            {
                TObject.SetActive(true);
                Finalobject = true;
            }
            else
                TObject.SetActive(false);
            Finalobject = true;
        }
        
    }

}
