using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererRope : MonoBehaviour
{
    public LineRenderer _lineRenderer;
    public List<GameObject> _pointRope;
    public Component[] _arrPointRope;

    private void Start()
    {
        _arrPointRope = GetComponentsInChildren<SpringJoint>();
        _lineRenderer.positionCount = _arrPointRope.Length;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < _arrPointRope.Length; i ++)
        {
            _lineRenderer.SetPosition(i, _arrPointRope[i].transform.position);
        }
    }
}
