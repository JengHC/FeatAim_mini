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

        // box collider의 size =  col.size.x , 콜라이더 범위의 최솟값 부터 최댓값까지 공이 스폰
        // minX 최소값은 center.x값에서 x값에서 반을 나누고, 음수로 내려가니까 -col.size.x /2f가 된다.
        // 이와 같은 방식으로 X,Y,Z 축 전부다 같은 작업을 하고, 최대 최소값을 통해 Random.Range를 돌린다.
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
