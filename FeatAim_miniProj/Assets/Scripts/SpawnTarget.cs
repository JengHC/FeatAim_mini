using System;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public static Action OnTargetHit;
    [SerializeField] private float minimumDistance = 1f; // Ÿ�� �� �ּ� �Ÿ�

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

        // 10ȸ���� ��ġ�� �ʴ� ��ġ�� ã�� ���� �õ�
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

        // ���� ������ ��ġ�� ã�� ������ ���, ������ ��ġ ���
        if (!positionFound)
        {
            transform.position = TargetBoundary.Instance.GetRandomPosition();
        }
    }

    bool IsOverlapping(Vector3 position)
    {
        // Ư�� �ݰ� ���� ��ġ�� �ݶ��̴��� �ִ��� Ȯ��
        Collider[] colliders = Physics.OverlapSphere(position, minimumDistance);
        foreach (var collider in colliders)
        {
            if (collider.gameObject != this.gameObject && collider.CompareTag("Target"))
            {
                return true; // �ٸ� Ÿ�ٰ� ��ħ
            }
        }
        return false; // ��ġ�� ����
    }
}
