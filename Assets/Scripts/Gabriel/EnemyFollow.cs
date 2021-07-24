using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    #region Variables
    private Rigidbody2D rb;
    private Vector2 movement;
    private Transform playerPrefab;

    [SerializeField] private byte speedMovement;
    [SerializeField] private byte life;
    #endregion

    #region Mono
    private void Start()
    {
        GetComponents();
    }

    private void Update()
    {
        MoveNormalize();
        DeathEnemy();
    }

    private void FixedUpdate()
    {
        MoveCharacter(this.movement);
    }
    #endregion

    #region Get Components
    /// <summary>
    /// This method is responsive for capture components of Enemy and Player.
    /// </summary>
    private void GetComponents()
    {
        this.playerPrefab = GameObject.Find("Player").GetComponent<Transform>();
        this.rb = GetComponent<Rigidbody2D>();
    }
    #endregion

    #region Move Normalized
    /// <summary>
    /// Configure movement of player and optmize
    /// </summary>
    private void MoveNormalize()
    {
        Vector3 directionPlayer = this.playerPrefab.position - this.gameObject.transform.position;
        directionPlayer.Normalize();
        this.movement = directionPlayer;
    }
    #endregion

    #region Move Character
    /// <summary>
    /// Movement Character and captura vector 2 of move.
    /// </summary>
    /// <param name="direction"></param>
    private void MoveCharacter(Vector2 direction)
    {
        this.rb.MovePosition((Vector2)this.transform.position + (direction * this.speedMovement * Time.deltaTime));
    }
    #endregion

    #region DeathEnemy
    /// <summary>
    /// Controller life.
    /// </summary>
    private void DeathEnemy()
    {
        if (life <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    #endregion
}
