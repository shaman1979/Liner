using UnityEngine;

public class Rotation : MonoBehaviour
{
    private enum Direction
    {
        Left = 1,
        Right = -1
    }
    [SerializeField]
    private Direction direction;
    [SerializeField]
    private float speed;

    private void Start()
    {
        direction = (Direction)Random.Range(-1, 1);
        transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
    }

    void Update()
    {
        RotationModel();
    }

    private void RotationModel()
    {
        transform.Rotate(0f,0f,(int)direction * speed * Time.deltaTime);
    }
}
