using System;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public static Action OnTargetHit;
    [SerializeField] private float minimumDistance = 1f; // 타겟 간 최소 거리

    void Start()
    {
        RandomizePosition();
    }

    public void Hit()
    {
        RandomizePosition();
        OnTargetHit?.Invoke();
    }

    //void RandomizePosition()
    //{
    //    transform.position = TargetBoundary.Instance.GetRandomPosition();
    //}
    void RandomizePosition()
    {
        Vector3 newPosition;
        int attempts = 0;
        bool positionFound = false;

        // 10회까지 겹치지 않는 위치를 찾기 위해 시도
        while (attempts < 10 && !positionFound)
        {
            newPosition = TargetBoundary.Instance.GetRandomPosition();

            if (!IsOverlapping(newPosition))
            {
                transform.position = newPosition;
                positionFound = true;
            }

            attempts++;
        }

        // 만약 적합한 위치를 찾지 못했을 경우, 마지막 위치 사용
        if (!positionFound)
        {
            transform.position = TargetBoundary.Instance.GetRandomPosition();
        }
    }

    bool IsOverlapping(Vector3 position)
    {
        // 특정 반경 내에 겹치는 콜라이더가 있는지 확인
        Collider[] colliders = Physics.OverlapSphere(position, minimumDistance);
        foreach (var collider in colliders)
        {
            if (collider.gameObject != this.gameObject && collider.CompareTag("Target"))
            {
                return true; // 다른 타겟과 겹침
            }
        }
        return false; // 겹치지 않음
    }
}
