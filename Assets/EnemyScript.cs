using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject gameManager; // GameObjectそのものが入る変数
    private GameManagerScript gameManagerScript; // Scriptが入る変数

    // Start is called before the first frame update
    void Start()
    {
        // ゲームマネージャーのオブジェクトを探す
        gameManager = GameObject.Find("GameManager");
        // スクリプトを獲得
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();

        Destroy(gameObject, 5);
        transform.rotation = Quaternion.Euler(0, 180, 0);

        // 乱数で左右へ
        int r = Random.Range(0, 2);
        if (r == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.IsGameOver() == true)
        {
            return;
        }

        float moveSpeed = 4;
        Vector3 velocity = new Vector3(0, 0, moveSpeed * Time.deltaTime);
        transform.position += transform.rotation * velocity;

        // 左右で反転
        if (transform.position.x > 4)
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }
        if (transform.position.x < -4)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }

    }

}
