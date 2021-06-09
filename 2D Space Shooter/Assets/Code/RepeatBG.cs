using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    public float verticalSize;
    private Vector2 _offsetUp;
    
    void Update()
    {
        if(transform.position.y < -verticalSize)
        RepeatBackground();
    }

    private void RepeatBackground()
    {
        _offsetUp = new Vector2(0, verticalSize * 2f);
        transform.position = (Vector2)transform.position + _offsetUp;
    }
}
