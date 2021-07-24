using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //velocidade do player
    public float moveSpeed;
    public float attackRadius;
    public Transform attackArea;
    public LayerMask isEminem;
    [SerializeField]
    private bool isHit;

    private void Update()
    {
        Ataque();
    }
    private void FixedUpdate()
    {
        
      PlayerMove();

    }

    private void Ataque()
    {
        //ataque do player
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToViewportPoint(mousePosition);
        Vector2 attackdirection = new Vector2(
        mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y
        );
        transform.up = attackdirection;
    }

    private void PlayerMove()
    {
        //movimentação normalizada
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 1);
        transform.position = Vector2.MoveTowards(transform.position, transform.position + direction, moveSpeed * Time.deltaTime);

        isHit = Physics2D.OverlapCircle(attackArea.position, attackRadius, isEminem);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.attackArea.position, this.attackRadius);
    }
}
