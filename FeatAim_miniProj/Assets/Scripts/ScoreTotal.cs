using TMPro;
using UnityEngine;

public class ScoreTotal : MonoBehaviour
{
    [SerializeField] 
    TMP_Text text;
    [SerializeField] 
    TMP_Text text1;
    private bool isGameActive = false;

    public static int Score
    {
        get;
        private set;
    }
    public float lastHitTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isGameActive = true;
        }
    }

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
        if (!isGameActive)
            return;

        // ���� ���� ���� �ð��� ������ ���� ���� �ð��� ���� ���
        float timeSinceLastHit = Time.time - lastHitTime;

        // �⺻ ���� �� �߰� ���� ���
        int baseScore = 1000;
        float multiple = 1.0f;  //�׳� ���ϰ� �ϸ� ���� �����ϱ�, ������ ���� Mathf����ϱ� ����

        // timeSinceLasthit�� 1�� �����̸� multiple�� 2�谡 ��
        if (timeSinceLastHit <= 0.7f)
        {
            multiple = 2.0f;
        }
        else if (timeSinceLastHit <= 0.5f)
        {
            multiple = 1.5f;
        }
        else if (timeSinceLastHit <= 0.2f)
        {
            multiple = 1.2f;
        }

        //���� �߰�
        Score += Mathf.RoundToInt(baseScore * multiple);
        text.text = $"{Score}";

        // ���� ���� �������� �ɸ� �ð��� ���� ��� �ϵ���, ���� �ð����� �ٽ� ����
        lastHitTime = Time.time;

        Score++;
        text1.text = $"����: {Score}";
    }

    public static  void ResetScore()
    {
        Score = 0;
        ScoreTotal instance = FindObjectOfType<ScoreTotal>();

        if (instance != null)
        {
            instance.text.text = $"{Score}";
            instance.text1.text = $"����: {Score}";
        }
    }

    //void OnGameEnded()
    //{
    //    Score = 0;
    //    text1.text = $"{Score}";
    //}
}
