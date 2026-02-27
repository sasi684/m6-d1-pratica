using UnityEngine;
using UnityEngine.UI;

public class SaveOptions : MonoBehaviour
{

    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    [SerializeField] private Toggle _toggle;

    private void OnEnable()
    {
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Music-volume", _musicSlider.value);
        PlayerPrefs.SetFloat("SFX-volume", _sfxSlider.value);

        PlayerPrefs.SetInt("Toggle", _toggle.isOn ? 1 : 0);
    }

    public void Load()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("Music-volume", 1);
        _sfxSlider.value = PlayerPrefs.GetFloat("SFX-volume", 1);

        _toggle.isOn = PlayerPrefs.GetInt("Toggle") == 1 ? true : false;
    }

}
