using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{ 
    public void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().Save();
    }
}
