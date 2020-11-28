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

    // Start is called before the first frame update
    void Start()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rectTransform.position = new Vector3(0, m_rectTransform.position.y+ m_Speed, m_rectTransform.position.z);
    }

    //y 값이 588일때 좀비 sound 넣기
}
