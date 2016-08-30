using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(CableComponent))]
public class DragCable : MonoBehaviour
{
    public GameObject childJoint;
    public DragCable otherEnd;
    public float endDistances = 3;
    [HideInInspector]
    public bool canDrag = true;

    private bool _drag;
    private Rigidbody2D _myRigidbody;
    private bool _wasKinematic;

    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
        _wasKinematic = _myRigidbody.isKinematic;
    }

    void OnMouseDrag()
    {
        if (canDrag && otherEnd.canDrag)
        {
            DragFunction();
        }

        else if (!otherEnd.canDrag && canDrag && Vector2.Distance(transform.position, otherEnd.transform.position) < endDistances)
        {
            DragFunction();
        }
    }

    void FixedUpdate()
    {
        if (_drag)
        {
            transform.rotation = childJoint.transform.rotation;
        }
    }

    public void HasConnection()
    {
        canDrag = false;
    }

    void OnMouseDown()
    {
        _drag = true;
        _myRigidbody.isKinematic = true;

        if (otherEnd != null && otherEnd.canDrag)
            otherEnd.DisableKinemactic(_drag);
    }

    void OnMouseUp()
    {
        if (_drag == true)
        {
            _myRigidbody.isKinematic = _wasKinematic;
        }

        if (otherEnd != null && !otherEnd.canDrag && Vector2.Distance(transform.position, otherEnd.transform.position) >= endDistances)
        {
            _myRigidbody.isKinematic = false;
        }

        _drag = false;
    }

    void DragFunction()
    {
        // We are converting a 2D mouse coordinate to 3D
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));

        _myRigidbody.position = new Vector3(pos_move.x, pos_move.y, pos_move.z);
        transform.rotation = childJoint.transform.rotation;
    }

    public void DisableKinemactic(bool isDragging)
    {
        _myRigidbody.isKinematic = !isDragging;
    }
}