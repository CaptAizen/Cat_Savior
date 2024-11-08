using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public GameObject[] objectsToMove;
    public float moveSpeed = 5f;
    public float moveDuration = 2f;

    private GameObject player;
    private bool isMoving = false;
    private float moveStartTime;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found. Make sure your player object has the 'Player' tag.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            isMoving = true;
            moveStartTime = Time.time;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            float elapsedTime = Time.time - moveStartTime;
            if (elapsedTime < moveDuration)
            {
                MoveObjectsTowardsPlayer();
            }
            else
            {
                isMoving = false;
            }
        }
    }

    void MoveObjectsTowardsPlayer()
    {
        foreach (GameObject obj in objectsToMove)
        {
            if (obj != null)
            {
                Vector3 direction = (player.transform.position - obj.transform.position).normalized;
                obj.transform.position += direction * moveSpeed * Time.deltaTime;
            }
        }
    }
}
