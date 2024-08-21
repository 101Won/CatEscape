using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float moveSpeed = 0.001f;
    private int dir = -1;
    public float radius = 1f;
    private Transform playerTrans;
    private int damage = 10;

    private void Start()
    {
        this.playerTrans = GameObject.Find("player").transform;

        //���� 
        //Vector3 c = playerTrans.position - this.transform.position;
        //float d1 = c.magnitude;

        //float d2 = Mathf.Abs(playerTrans.position.y - this.transform.position.y);
    }

    void Update()
    {
        // �÷��̾�� �浹�ϸ� ȭ��ǥ ����
        this.transform.Translate(0, dir * moveSpeed, 0);

        bool isCollided = this.CheckCollsion();

        if (isCollided)
        {
            Object.Destroy(this.gameObject);
        }

        if (this.transform.position.y <= -6.36f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        GizmosExtensions.DrawWireArc(this.transform.position, 360, radius);
    }

    //�浹üũ�� ���Ŀ� �浹�� �Ǿ��ٸ� true�� ��ȯ 
    public bool CheckCollsion()
    {
        // �ַο�� �÷��̾��� �Ÿ� üũ
        float distance = Vector3.Distance(playerTrans.position, this.transform.position);

        PlayerController playerController = this.playerTrans.gameObject.GetComponent<PlayerController>();

        float sumRadius = this.radius + playerController.radius;
        //  Debug.Log($"{distance}, {sumRadius}");



        if (distance <= sumRadius)
        {
            // Debug.Log("�浹�߽��ϴ�.");
            playerController.hp = playerController.hp - damage;
            Debug.Log($"<color=yellow>���� ü��: {playerController.hp}</color>");

            if (playerController.hp <= 0)
            {
                Debug.Log("����� �ֱ�....");
                // ��Ʈ�� ����????????????????????????????????????????????????????
                ArrowGenerator.ArrowState = ArrowGenerator.ArrowState.Stop;



                // ȭ��ǥ ���� ���� �ż��� �ֱ�
            }
            return true;
        }
        else
        {
            // Debug.Log("�浹���߽��ϴ�.");
            return false;
        }
    }
}