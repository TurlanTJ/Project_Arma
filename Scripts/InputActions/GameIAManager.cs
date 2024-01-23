using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIAManager : MonoBehaviour
{
    private GameIA _inputActions;

    // Start is called before the first frame update
    void Awake()
    {
        _inputActions = new GameIA();
        _inputActions.Player.Enable();
    }

    public Vector3 GetMovementDirection()
    {
        Vector2 val = _inputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 dir = new Vector3(val.x, 0f, val.y);

        return dir;
    }
}
