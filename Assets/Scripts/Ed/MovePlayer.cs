using UnityEngine;

#region Move Player
public class MovePlayer : MonoBehaviour
{
    #region variaveis
    //velocidade do player
    public float moveSpeed;
    public Vector3 direction;
    public float attackRadius;
    public Transform attackArea;
    public LayerMask isEminem;
    [SerializeField]
    private byte attackDamage;
    [SerializeField]
    private bool collision;
    #endregion

    #region void start
    private void Start()
    {
        //para ajudar a rotação da area de ataque em volta do player
        attackArea.transform.position = new Vector2(this.gameObject.transform.position.x,this.gameObject.transform.position.y+0.5f) ;
    }
    #endregion

    #region Update
    private void Update()
    {
        Ataque();
    }
    #endregion

    #region void fixedUpdate
    private void FixedUpdate()
    {
        
        PlayerMove();

    }
    #endregion

    #region PlayerMove
    private void PlayerMove()
    {
        //movimentação normalizada
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 1);
        transform.position = Vector2.MoveTowards(transform.position, transform.position + direction, moveSpeed * Time.deltaTime);
    }
    #endregion

    #region Ataque
    private void Ataque()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Collider2D[] enemiescolider = Physics2D.OverlapCircleAll(attackArea.position, attackRadius, isEminem);
            foreach (Collider2D collider2D in enemiescolider)
            {
                if (collider2D.TryGetComponent<EnemyFollow>(out EnemyFollow enemyFollow))
                {
                    collider2D.gameObject.GetComponent<EnemyFollow>().ReduceLife(attackDamage);
                }
            }
        }
    }
    #endregion


    #region OnDrawGizmos
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.attackArea.position, this.attackRadius);
    }
    #endregion
}
#endregion
