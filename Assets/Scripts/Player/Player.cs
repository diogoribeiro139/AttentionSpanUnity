using UnityEngine;

public class TouchMove : MonoBehaviour
{
    private Vector2 touchOffset;
    private bool isDragging = false;
    private int touchId = -1;

    public void StartDragging(int newTouchId, Vector2 touchPos)
    {
        if (!isDragging)
        {
            touchId = newTouchId;
            touchOffset = (Vector2)transform.position - touchPos;
            isDragging = true;
        }
    }

    public void MoveObject(Vector2 touchPos)
    {
        if (isDragging)
        {
            transform.position = touchPos + touchOffset;
        }
    }

    public void StopDragging()
    {
        isDragging = false;
        touchId = -1;
    }
}