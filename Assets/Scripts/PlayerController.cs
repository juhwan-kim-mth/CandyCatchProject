using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [FormerlySerializedAs("canMove")] 
    public bool CanMove = true;

    [FormerlySerializedAs("maxPos")] [SerializeField]
    float _maxPos;

    [FormerlySerializedAs("MoveSpeed")] [SerializeField]
    float _moveSpeed;

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            Move();
        }
    }

    void Move()
    {
        var inputX = Input.GetAxis("Horizontal");
        var position = transform.position;
        position += _moveSpeed * inputX * Time.deltaTime * Vector3.right;

        var xPos = Mathf.Clamp(position.x, -_maxPos, _maxPos);
        position = new Vector3(xPos, position.y, position.z);
        transform.position = position;
    }
}