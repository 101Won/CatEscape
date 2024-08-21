using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float rangeX; 
    public float elapsedTime; // 경과 시간 = 화살 생성 시간

    public enum ArrowState
    {
        Start, Stop
    }
    public ArrowState arrowState;

    void Update()
    {
       // Debug.Log($"경과 시간 누적 체크: {this.elapsedTime}");
        this.elapsedTime += Time.deltaTime; // 경과 시간 계산
        
        arrowState= ArrowState.Start;

        if (this.elapsedTime > 1.3f) // 1.3생성
        {
            CreateArrow();
           this.elapsedTime = 0;
        //    Debug.Log($"경과 시간 리셋 체크: {this.elapsedTime}");
        }
    }

    // 매서드를 나누는 이유는 하나의 매서드는 하나의 기능만 갖자.
    void CreateArrow()
    {
        bool flag = true;

        while (true)
        {
            // 화살 생성
            // 랜덤 x좌표 생성
            rangeX = Random.Range(-8.0f, 8.0f);
            // Debug.Log($"x 범위:{rangeX}");

            GameObject arrowGo = Object.Instantiate(arrowPrefab);
            arrowGo.transform.position = new Vector3(rangeX, 5.5f, 0);

            if (arrowState == ArrowState.Stop)
            {
                flag = false;
            }

        }
    }


}