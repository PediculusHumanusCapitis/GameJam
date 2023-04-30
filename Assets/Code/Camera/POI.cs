using UnityEngine;

public class POI : MonoBehaviour
{
    public float speed;
    public Transform trackingObject;
    public Vector3 shiftObject;
    public bool shiftLock = true;
    public bool ShiftLock {
        get { return shiftLock; }
        set { shiftLock = value; }
    }
    private float oldZ;
    private float oldX;

    private void Start() {
        oldZ = transform.position.z;
        oldX = transform.position.x;
    }

    private void Update() {
        if(!ShiftLock) {
            transform.position = Vector2.Lerp(transform.position, trackingObject.position + shiftObject, speed * Time.deltaTime);
        }
        transform.position = new Vector3(oldX, transform.position.y, oldZ);
    }
}
