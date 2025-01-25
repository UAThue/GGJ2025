using UnityEngine;

public class PlayerController : Controller
{
    public Pawn pawn;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // Read Inputs, set movement vector of pawn accordingly
        pawn.moveVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        pawn.rotation = Input.GetAxis("Rotation");
    }
}
