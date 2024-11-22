using UnityEngine;

public class BasicCharacterController : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotateSpeed = 150.0f;

    private void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}
