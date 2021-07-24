using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToViewportPoint(mousePosition);
        Vector2 attackdirection = new Vector2(
        mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y
        );
        transform.up = attackdirection;
    }
}
