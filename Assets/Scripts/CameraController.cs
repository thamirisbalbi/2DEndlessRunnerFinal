using UnityEngine;

public enum CameraType
{
    FollowPlayer,
}

public class CameraController : MonoBehaviour
{

    private Transform leftEdge;
    private Transform rightEdge;
    [SerializeField] private CameraType cameraType;
    private Transform player; //captura do mov de player

    private float halfWidth;
    private float halfHeight;
    //private int cameraFrame = 0; // top edge and down edge 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        leftEdge = GameObject.FindGameObjectWithTag("leftEdge").transform;
        rightEdge = GameObject.FindGameObjectWithTag("rightEdge").transform;
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;


    }

    void FollowPlayer()
    {
        float x = Mathf.Clamp(player.position.x, leftEdge.position.x + halfWidth, rightEdge.position.x - halfWidth);
        float y = transform.position.y;
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);

    }
    void LateUpdate()
    {

        switch (cameraType)
        {
            case CameraType.FollowPlayer: FollowPlayer(); break;
        }


    }
}


