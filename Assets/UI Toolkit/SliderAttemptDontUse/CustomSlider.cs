using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomSlider : MonoBehaviour
{

    private VisualElement m_Root;
    private VisualElement m_Slider;
    private VisualElement m_Dragger;
    private VisualElement m_Bar;
    private VisualElement m_NewDragger;

    // Start is called before the first frame update
    void Start()
    {
        m_Root = GetComponent<UIDocument>().rootVisualElement;
        m_Slider = m_Root.Q<Slider>("VolumeSlider");
        m_Dragger = m_Root.Q<VisualElement>("unity-dragger");

        AddElements();

        m_Slider.RegisterCallback<ChangeEvent<float>>(SliderValueChanged);

        m_Slider.RegisterCallback<GeometryChangedEvent>(SliderInit);
    }

    

    void AddElements() 
    {
        m_Bar = new VisualElement();
        m_Dragger.Add(m_Bar);
        m_Bar.name = "Bar";
        m_Bar.AddToClassList("bar"); 

        m_NewDragger = new VisualElement();
        m_Slider.Add(m_NewDragger);
        m_Bar.name = "NewDragger";
        m_Bar.AddToClassList("newdragger");
        m_NewDragger.pickingMode = PickingMode.Ignore;
    }

    void SliderValueChanged(ChangeEvent<float> value) 
    {
        Vector2 dist = new Vector2((m_NewDragger.layout.width - m_NewDragger.layout.width) / 2, (m_NewDragger.layout.height - m_Dragger.layout.height) / 2);
        Vector2 pos = m_Dragger.parent.LocalToWorld(m_Dragger.transform.position);
        m_NewDragger.transform.position = m_NewDragger.parent.WorldToLocal(pos);
    }
    void SliderInit(GeometryChangedEvent evt)
    {
       Vector2 dist = new Vector2((m_NewDragger.layout.width - m_NewDragger.layout.width) / 2, (m_NewDragger.layout.height - m_Dragger.layout.height) / 2);
        Vector2 pos = m_Dragger.parent.LocalToWorld(m_Dragger.transform.position);
        m_NewDragger.transform.position = m_NewDragger.parent.WorldToLocal(pos);
    }
    // Update is called once per frame
    void Update()
    {
        
    }   
}
