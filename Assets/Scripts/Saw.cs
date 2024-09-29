using UnityEngine;

public class Saw : MonoBehaviour
{
    public float movespeed = 2;
    int movedirection = 1;

    public Transform Rightcheck;
    public Transform Leftcheck;

    

   
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * movespeed * movedirection * Time.fixedDeltaTime);
        if (Physics2D.Raycast(Rightcheck.position, Vector2.down, 2) == false)
            movedirection = -1;

        if (Physics2D.Raycast(Leftcheck.position, Vector2.down, 2) == false)
            movedirection = 1;


    }
}
