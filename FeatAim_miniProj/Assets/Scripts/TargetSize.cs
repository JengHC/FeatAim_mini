using UnityEngine;

public class TargetSize : MonoBehaviour
{

    [SerializeField] 
    Vector3 sizeRate = new Vector3(0.005f, 0.005f, 0.005f); // �� �ʸ��� �پ��� ����

    [SerializeField] 
    Vector3 minScale = new Vector3(0.3f, 0.3f, 0.3f); // �ּ� ũ��
   
    void Update()
    {
        transform.localScale -= sizeRate * Time.deltaTime;

        transform.localScale = new Vector3(
            Mathf.Max(transform.localScale.x, minScale.x),
            Mathf.Max(transform.localScale.y, minScale.y),
            Mathf.Max(transform.localScale.z, minScale.z));

    }
}
