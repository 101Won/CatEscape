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

        //길이 
        //Vector3 c = playerTrans.position - this.transform.position;
        //float d1 = c.magnitude;

        //float d2 = Mathf.Abs(playerTrans.position.y - this.transform.position.y);
    }

    void Update()
    {
        // 플레이어와 충돌하면 화살표 삭제
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

    //충돌체크를 한후에 충돌이 되었다면 true를 반환 
    public bool CheckCollsion()
    {
        // 애로우와 플레이어의 거리 체크
        float distance = Vector3.Distance(playerTrans.position, this.transform.position);

        PlayerController playerController = this.playerTrans.gameObject.GetComponent<PlayerController>();

        float sumRadius = this.radius + playerController.radius;
        //  Debug.Log($"{distance}, {sumRadius}");



        if (distance <= sumRadius)
        {
            // Debug.Log("충돌했습니다.");
            playerController.hp = playerController.hp - damage;
            Debug.Log($"<color=yellow>현재 체력: {playerController.hp}</color>");

            if (playerController.hp <= 0)
            {
                Debug.Log("고양이 주금....");
                // 컨트롤 막기????????????????????????????????????????????????????
                ArrowGenerator.ArrowState = ArrowGenerator.ArrowState.Stop;



                // 화살표 생성 중지 매서드 넣기
            }
            return true;
        }
        else
        {
            // Debug.Log("충돌안했습니다.");
            return false;
        }
    }
}