using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class creditCtrl : MonoBehaviour
{
    public Image m_creditImage;
    public RectTransform m_rectTransform;
    [SerializeField]
    private float m_Speed;
    SoundManager Sound;

    // Start is called before the first frame update
    void Start()
    {
        m_rectTransform = GetComponent<RectTransform>();
        Sound = FindObjectOfType<SoundManager>();
        Sound.EndingPlay();
    }

    // Update is called once per frame
    void Update()
    {
        m_rectTransform.position = new Vector3(0, m_rectTransform.position.y+ m_Speed, m_rectTransform.position.z);

        if(m_rectTransform.position.y + m_Speed > 150f)
        {
            //좀비소리 넣기 2초 정도
            StartCoroutine(twosec());
       }
        Debug.Log(m_rectTransform.position.y + m_Speed);
    }

    IEnumerator twosec()
    {
        WaitForSeconds two = new WaitForSeconds(2f);
        yield return two;
        UnityEditor.EditorApplication.isPlaying = false;

    }
}
