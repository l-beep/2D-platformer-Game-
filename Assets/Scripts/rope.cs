using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class rope : MonoBehaviour
{
    [SerializeField, Range(2, 50)] int segmentCount = 2;

    public Transform pointA;
    public Transform pointB;

    public HingeJoint2D hingePrefab;

    [HideInInspector] public Transform[] segments;

    Vector2 GetSegmentPosition(int segmentIndex)
    {
        Vector2 posA = pointA.position;
        Vector2 posB = pointB.position;

        float fraction = 1f / (float)segmentCount;
        return Vector2.Lerp(posA, posB, fraction * segmentIndex);
    }

    [Button]
    void GenerateRope()
    {
        segments = new Transform[segmentCount];
        for (int i = 0; i < segmentCount; i++)
        {
            var currJoint = Instantiate(hingePrefab, GetSegmentPosition(i), Quaternion.identity, this.transform);
            segments[i] = currJoint.transform;
            if(i > 0)
            {
                int prevIndex = i - 1;
                currJoint.connectedBody = segments[prevIndex].GetComponent<Rigidbody2D>();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (pointA == null || pointB == null) return;
        Gizmos.color = Color.green;
        for (int i = 0; i < segmentCount; i++)
        {
            Vector2 posAindex = GetSegmentPosition(i);
            Gizmos.DrawSphere(posAindex, 0.1f);
        }

       

    }
    [Button]
    void DeleteSegments()
    {
        if(transform.childCount > 0)
        {
            for (int i = transform.childCount - 1; i > 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
        segments = null;
    }
}
