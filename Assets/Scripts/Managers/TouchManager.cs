using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public static TouchManager Instance { get; private set; }
    private Dictionary<int, TouchMove> activeTouches = new Dictionary<int, TouchMove>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);
                    if (hit.collider != null)
                    {
                        TouchMove touchMove = hit.collider.GetComponent<TouchMove>();
                        if (touchMove != null && !activeTouches.ContainsKey(touch.fingerId))
                        {
                            activeTouches[touch.fingerId] = touchMove;
                            touchMove.StartDragging(touch.fingerId, touchPos);
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    if (activeTouches.ContainsKey(touch.fingerId))
                    {
                        activeTouches[touch.fingerId].MoveObject(touchPos);
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (activeTouches.ContainsKey(touch.fingerId))
                    {
                        activeTouches[touch.fingerId].StopDragging();
                        activeTouches.Remove(touch.fingerId);
                    }
                    break;
            }
        }
    }
}