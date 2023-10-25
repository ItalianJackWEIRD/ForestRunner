using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public static bool swipeLeft, swipeRight, swipeUp, swipeDown;

    public bool tap;
    public bool isDraging = false;
    public Vector2 startTouch, swipeDelta;
    
    public float deadZone; // Cambiato il tipo di deadZone a float per un controllo più preciso

    private void Start()
    {
        
    }

    private void Update()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;

        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if (swipeDelta.magnitude >= deadZone)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();
        }
    }

    public void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}