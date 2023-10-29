using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] LineRenderer LineRenderer;
    [SerializeField] DistanceJoint2D DistanceJoint2D;
    // Start is called before the first frame update
    private void Awake()
    {
        DistanceJoint2D.enabled = false;
        LineRenderer.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        { 
            Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LineRenderer.SetPosition(0, mousePos);
            LineRenderer.SetPosition(1,transform.position);

            DistanceJoint2D.connectedAnchor = mousePos;
            DistanceJoint2D.enabled = true;
            LineRenderer.enabled = true;

        }
        else
        {
            DistanceJoint2D.enabled = false;
            LineRenderer.enabled = false;

        }
        if (DistanceJoint2D.enabled)
        {
            LineRenderer.SetPosition(1, transform.position);
        }
    }
}
