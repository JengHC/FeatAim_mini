using TMPro;
using UnityEngine;

public class ScoreTotal : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public static int Score
    {
        get;
        private set;
    }

    public float lastHitTime;

    void OnEnable()
    {
        Target.OnTargetHit += OnTargetHit;
        //Timer.OnGameEnded += OnGameEnded;
        lastHitTime = Time.time;
    }

    void OnDisable()
    {
        Target.OnTargetHit -= OnTargetHit;
        //Timer.OnGameEnded -= OnGameEnded;
    }

    void OnTargetHit()
    {
        // ���� ���� ���� �ð��� ������ ���� ���� �ð��� ���� ���
        float timeSinceLastHit = Time.time - lastHitTime;

        // �⺻ ���� �� �߰� ���� ���
        int baseScore = 1000;
        float multiple = 1.0f;  //�׳� ���ϰ� �ϸ� ���� �����ϱ�, ������ ���� Mathf����ϱ� ����

        // timeSinceLasthit�� 1�� �����̸� multiple�� 2�谡 ��
        if (timeSinceLastHit <= 1.0f)
        {
            multiple = 2.0f;
        }
        else if (timeSinceLastHit <= 3.0f)
        {
            multiple = 1.5f;
        }
        else if (timeSinceLastHit <= 5.0f)
        {
            multiple = 1.2f;
        }

        //���� �߰�
        Score += Mathf.RoundToInt(baseScore * multiple);
        text.text = $"{Score}";

        // ���� ���� �������� �ɸ� �ð��� ���� ��� �ϵ���, ���� �ð����� �ٽ� ����
        lastHitTime = Time.time;

        Score++;
        text.text = $"{Score}";
    }

    //void OnGameEnded()
    //{
    //	Score = 0;
    //	text.text = $"{Score}";
    //}
}