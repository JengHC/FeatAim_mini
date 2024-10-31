using UnityEngine;

public class TargetBoundary : MonoBehaviour
{
    public static TargetBoundary Instance;

    void Awake()
    {
        Instance = this;
    }

    [SerializeField]
    BoxCollider col;

    public Vector3 GetRandomPosition()
    {
        Vector3 center = col.center + transform.position;

        // box collider�� size =  col.size.x , �ݶ��̴� ������ �ּڰ� ���� �ִ񰪱��� ���� ����
        // minX �ּҰ��� center.x������ x������ ���� ������, ������ �������ϱ� -col.size.x /2f�� �ȴ�.
        // �̿� ���� ������� X,Y,Z �� ���δ� ���� �۾��� �ϰ�, �ִ� �ּҰ��� ���� Random.Range�� ������.
        float minX = center.x - col.size.x / 2f;
        float maxX = center.x + col.size.x / 2f;

        float minY = center.y - col.size.y / 2f;
        float maxY = center.y + col.size.y / 2f;

        float minZ = center.z - col.size.z / 2f;
        float maxZ = center.z + col.size.z / 2f;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        return randomPosition;
    }    
}
