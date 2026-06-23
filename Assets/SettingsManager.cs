using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider voiceVolumeSlider;
    public Slider sensitivitySlider;

    public AudioSource voiceAudio;

    public static float controllerSensitivity = 1f;

    void Start()
    {
        masterVolumeSlider.value = AudioListener.volume;
        voiceVolumeSlider.value = voiceAudio.volume;
        sensitivitySlider.value = controllerSensitivity;

        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        voiceVolumeSlider.onValueChanged.AddListener(SetVoiceVolume);
        sensitivitySlider.onValueChanged.AddListener(SetSensitivity);
    }

    public void SetMasterVolume(float value)
    {
        AudioListener.volume = value;
        Debug.Log("Master Volume: " + value);

    }

    public void SetVoiceVolume(float value)
    {
        voiceAudio.volume = value;
    }

    public void SetSensitivity(float value)
    {
        controllerSensitivity = value;
    }
}