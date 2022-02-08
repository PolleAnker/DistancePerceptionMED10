using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectResizer : MonoBehaviour
{
    public GameObject objectToResize;
    public bool scaleInaccurately = false;
    public bool resetScale = false;
    
    void Update()
    {
        if(scaleInaccurately){
            scaleInaccurately = false;
            objectToResize.transform.localScale = Vector3.one;
            float randomMultiplier = Random.Range(0.5f, 2.1f);
            objectToResize.transform.localScale *= randomMultiplier;
            print("Environment scaled by factor " + randomMultiplier);
        }
        if(resetScale){
            resetScale = false;
            objectToResize.transform.localScale = Vector3.one;
            print("Environment scale was reset");
        }
    }
}
