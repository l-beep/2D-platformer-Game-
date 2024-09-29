using UnityEngine;

public class Spike : MonoBehaviour
{
    public float movespeed = 0.8f;
    public float range = 3;

    float startingY;
    int movedirection = 1;
   
    void Start()
    {
        startingY = transform.position.y;
    }

   
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * movespeed * Time.fixedDeltaTime * movedirection);
        if (transform.position.y < startingY || transform.position.y > startingY + range)
            movedirection *= -1;
    }
}
