using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LogoDisplayManager : MonoBehaviour
{
    public Image fade_mage;
    public float fade_speed                 = 0.3f;
    public float fade_wait_time             = 2.0f;
    public float scene_transition_wait_time = 0.5f;

    void Start()
    {
        StartCoroutine(FadeInOut());
    }

    IEnumerator FadeInOut()
    {
        fade_mage.color = Color.black;

        // フェードイン
        float alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fade_speed;
            fade_mage.color = new Color(0f, 0f, 0f, alpha);
            yield return null; // 1フレーム待機
        }

        // 待機
        float timer = 0f;
        while (timer < fade_wait_time)
        {
            timer += Time.deltaTime;
            yield return null; // 1フレーム待機
        }

        // フェードアウト
        alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fade_speed;
            fade_mage.color = new Color(0f, 0f, 0f, alpha);
            yield return null; // 1フレーム待機
        }

        // 待機
        timer = 0f;
        while (timer < scene_transition_wait_time)
        {
            timer += Time.deltaTime;
            yield return null; // 1フレーム待機
        }

        // シーン遷移
        SceneManager.LoadScene("TitleScene");
    }
}
