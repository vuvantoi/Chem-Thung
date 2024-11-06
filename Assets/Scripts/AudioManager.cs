using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; // Tham chiếu đến Audio Source
    public Slider volumeSlider; // Tham chiếu đến Slider

    void Start()
    {
        // Đặt giá trị slider theo âm lượng hiện tại
        volumeSlider.value = audioSource.volume;

        // Thêm listener để điều chỉnh âm lượng khi slider thay đổi
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Phương thức điều chỉnh âm lượng
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
