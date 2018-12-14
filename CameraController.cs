using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
    private static bool cameraExists;
    public BoxCollider2D boundsBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

	// Use this for initialization
	void Start () 
	{
	//при переходе на новый уровень дупликат камеры автоматически удаляется
        DontDestroyOnLoad(transform.gameObject);
        if (!cameraExists)
	{
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
	//создание рамок для движения камеры в соответствии с ее размерами
        minBounds = boundsBox.bounds.min;
        maxBounds = boundsBox.bounds.max;
        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update() 
    {
	//камера следует за игроком и не выходит за рамки карты
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

    }
    public void SetBounds(BoxCollider2D newBounds)
    {
	//ограничение карты
        boundsBox = newBounds;

        minBounds = boundsBox.bounds.min;
        maxBounds = boundsBox.bounds.max;
    }
}
