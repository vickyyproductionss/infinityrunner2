using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public static cameraFollow instance;
    public Transform player;
    public Vector3 offset;
    public float translationSpeed = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void setTargetTransfrom(Transform t)
    {
        player = t;
    }
    void LateUpdate()
    {
        Vector3 playerPos = player.position;
        //transform.position = new Vector3(0, playerPos.y, playerPos.z - 10) + offset;
        transform.position = Vector3.Lerp(transform.position, player.position + offset, translationSpeed * Time.deltaTime);
    }
    //public static cameraFollow instance;
    //[SerializeField] private Vector3 Offset;
    //[SerializeField] private Transform target;
    //[SerializeField] private float translationSpeed;
    //[SerializeField] private float rotationSpeed;
    //private void Awake()
    //{
    //    if (instance == null)
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
    //    HandleRotation();
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
}
