using UnityEngine;
using UnityEngine.UI;

namespace GoCube.Presentation.Sounds {
    public class SoundsComponent : MonoBehaviour {

        public Sprite OnSprite;
        public Sprite OffSprite;
        [SerializeField] private Toggle _music;

        private void Start() {
            GetComponentInChildren<Toggle>().onValueChanged.AddListener(SoundChanged);
            InitSound();
        }

        private void SoundChanged(bool on) {
            AudioListener.pause = !on;
            GetComponentInChildren<Toggle>().image.sprite = on ? OnSprite : OffSprite;
            PlayerPrefs.SetString("sounds", on ? "true" : "false");
            _music.onValueChanged.Invoke(on);
            _music.interactable = on;
        }

        private void InitSound() {
            var soundStatus = PlayerPrefs.GetString("sounds");
            SoundChanged(!HasSoundPersisted(soundStatus) || bool.Parse(soundStatus));
        }

        private bool HasSoundPersisted(string soundStatus) {
            return soundStatus != "";
        }
    }
}
