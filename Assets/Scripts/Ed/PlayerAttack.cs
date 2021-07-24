using UnityEngine;

#region PlayerAttack
public class PlayerAttack : MonoBehaviour
{
    #region void Update
    private void Update()
    {
        //ataque do player
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 attackdirection = new Vector2(
        mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y
        );
        transform.up = attackdirection;
    }
    #endregion
}
#endregion
