using UnityEngine;
using System.Collections;

public class DragCable : MonoBehaviour
{
    private bool _drag;                  // True if is being dragged
    private Rigidbody2D _myRigidbody;    // Reference to the GameObject's Rigidbody2D
    private bool _wasKinematic;          // Flag indicating whether or not the Ridigbody
    public GameObject childJoint;
    public DragCable otherEnd;
    
    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
        _wasKinematic = _myRigidbody.isKinematic;
    }

    void OnMouseDrag()
    {
        DragFunction();
    }

    void FixedUpdate()
    {
        if (_drag)
            DragFunction();
        else
            transform.rotation = childJoint.transform.rotation;
    }
    
    void OnMouseDown()
    {
        _drag = true;
        _myRigidbody.isKinematic = true;
        if(otherEnd != null)
            otherEnd.DisableKinemactic(_drag);
    }

    void OnMouseUp()
    {
        if (_drag == true)
        {
            _myRigidbody.isKinematic = _wasKinematic;
        }

        _drag = false;
    }

    void DragFunction()
    {
        // We are converting a 2D mouse coordinate to 3D
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        // Update GameObject position
        _myRigidbody.position = new Vector3(pos_move.x, pos_move.y, pos_move.z);
        transform.rotation = childJoint.transform.rotation;
        
    }

    public void DisableKinemactic(bool isDragging)
    {
        _myRigidbody.isKinematic = !isDragging;
    }
}