 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
using System.IO;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(RectTransform))]
public class Sliders : MonoBehaviour
{

	private Slider _slider;
	private float _sliderSize;
	public Image fill;

	void Awake()
	{
		_slider = GetComponent<Slider>();
		
	}
	void Update()
	{
		UpdateSliderSense();
		Debug.Log(_sliderSize);
		_slider.fillRect.localPosition = new Vector3(0, 0, 0);
	}
	public void UpdateSliderSense()
	{
		if (_sliderSize == 0)
		{
			_sliderSize = GetComponent<RectTransform>().rect.width;
			_sliderSize = _sliderSize / (_slider.maxValue - _slider.minValue);
		}

		_slider.fillRect.rotation = new Quaternion(0, 0, 0, 0);
		_slider.fillRect.pivot = new Vector2(_slider.fillRect.transform.parent.localPosition.x, _slider.fillRect.pivot.y);
		if (_slider.value > 0)
		{
			_slider.fillRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _sliderSize * _slider.value);
			fill.GetComponent<Image>().color = Color.green;
		}
		else
		{
			_slider.fillRect.Rotate(0, 0, 180);
			_slider.fillRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, -1 * _sliderSize * _slider.value);
			fill.GetComponent<Image>().color = Color.red;
		}
		_slider.fillRect.localPosition = new Vector3(0, 0, 0);
	}

}
