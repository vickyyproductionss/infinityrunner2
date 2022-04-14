using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;


    void LateUpdate()
    {
        Vector3 playerPos = player.position;
        //transform.position = new Vector3(0, playerPos.y, playerPos.z - 10) + offset;
        transform.position = player.position + offset;
    }
    #region oldCode
    //public static CameraFollow2 instance;
    //[SerializeField] private Vector3 Offset;
    //[SerializeField] private Transform target;
    //[SerializeField] private float translationSpeed;
    //[SerializeField] private float rotationSpeed;
    //private void Awake()
    //{
    //    if(instance == null)
    //    {
    //        instance = this;
    //    }
    //}
    //private void Start()
    //{
    //}
    //public void setTargetTransfrom(Transform t)
    //{
    //    target = t;
    //}
    //private void LateUpdate()
    //{
    //    HandleTranslation();
    //    //HandleRotation();
    //}
    //public void HandleTranslation()
    //{
    //    Vector3 targetPosition = target.TransformPoint(Offset);
    //    transform.position = Vector3.Lerp(transform.position, targetPosition, translationSpeed * Time.deltaTime);
    //}
    //private void HandleRotation()
    //{
    //    var direction = target.position - transform.position;
    //    var rotation = Quaternion.LookRotation(direction, Vector3.up);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    //}
    #endregion
}


