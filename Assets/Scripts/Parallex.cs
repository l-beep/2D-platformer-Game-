using UnityEngine;

public class Parallex : MonoBehaviour
{
    public Transform mainCam;
    public Transform middleBG;
    public Transform sideBG;

    public float length = 35;

    private void Update()
    {
        if (mainCam.position.x > middleBG.position.x)
            sideBG.position = middleBG.position + Vector3.right * length;

        if (mainCam.position.x < middleBG.position.x)
            sideBG.position = middleBG.position + Vector3.left * length;


        if (mainCam.position.x > sideBG.position.x || mainCam.position.x < sideBG.position.x)
        {
            Transform z = middleBG;
            middleBG = sideBG;
            sideBG = z;

        }

    }
}

