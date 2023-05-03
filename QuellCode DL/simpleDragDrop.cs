using UnityEngine;

public class simpleDragDrop : MonoBehaviour
{
    private bool isBeingHeld = false;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // record the starting position
    }

    void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Dragging");
            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        Debug.Log("NotDragging");
        isBeingHeld = false;
    }
}
