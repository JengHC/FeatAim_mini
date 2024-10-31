using UnityEngine;

public class TargetSize : MonoBehaviour
{

    [SerializeField] private Vector3 sizeRate = new Vector3(0.02f, 0.02f, 0.02f); // 매 초마다 줄어드는 비율
    [SerializeField] private Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f); // 최소 크기
   
    void Update()
    {
        transform.localScale -= sizeRate * Time.deltaTime;

        transform.localScale = new Vector3(
            Mathf.Max(transform.localScale.x, minScale.x),
            Mathf.Max(transform.localScale.y, minScale.y),
            Mathf.Max(transform.localScale.z, minScale.z));

    }
}
