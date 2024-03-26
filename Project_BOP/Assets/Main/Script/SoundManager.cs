using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource BGM;
    public AudioClip[] bglist, sfxlist;
    public AudioMixer BGMmixer;
    public AudioMixer SFXmixer;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene SceneName, LoadSceneMode mode)
    {
        for (int i = 0; i < 2; i++)
        {
            if(SceneName.name == bglist[i].name)
            {
                BGMPlay(bglist[i]);
            }
        }
    }
    public void SFXPlay(string sfxName)
    {
        if (sfxName == "Blop")
        {
            GameObject go = new GameObject(sfxName + "Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = SFXmixer.FindMatchingGroups("AddCoin")[0];
            audioSource.clip = sfxlist[0];
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.Play();
            Destroy(go, sfxlist[0].length);

        }
        if (sfxName == "Shield")
        {
            GameObject go = new GameObject(sfxName + "Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = SFXmixer.FindMatchingGroups("Shield")[0];
            audioSource.clip = sfxlist[1];
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.Play();
            Destroy(go, sfxlist[1].length);
        }
        if (sfxName == "Flex")
        {
            GameObject go = new GameObject(sfxName + "Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = SFXmixer.FindMatchingGroups("Flex")[0];
            audioSource.clip = sfxlist[2];
            audioSource.loop = true;
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.Play();
            Destroy(go, sfxlist[2].length);
        }
        if (sfxName == "Slap")
        {
            GameObject go = new GameObject(sfxName + "Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = SFXmixer.FindMatchingGroups("Die")[0];
            audioSource.clip = sfxlist[3];
            audioSource.loop = true;
            audioSource.Play();
            Destroy(go, sfxlist[3].length);
        }
        if (sfxName == "GameOver")
        {
            GameObject go = new GameObject(sfxName + "Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = SFXmixer.FindMatchingGroups("GameOver")[0];
            audioSource.clip = sfxlist[4];
            audioSource.loop = true;
            audioSource.Play();
            Destroy(go, sfxlist[4].length);
        }
        if (sfxName == "BRKShield")
        {
            GameObject go = new GameObject(sfxName + "Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = SFXmixer.FindMatchingGroups("BRKShield")[0];
            audioSource.clip = sfxlist[5];
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.Play();
            Destroy(go, sfxlist[5].length);
        }
        if (sfxName == "Open")
        {
            GameObject go = new GameObject(sfxName + "Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = SFXmixer.FindMatchingGroups("Open")[0];
            audioSource.clip = sfxlist[6];
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.Play();
            Destroy(go, sfxlist[6].length);
        }
        if (sfxName == "Close")
        {
            GameObject go = new GameObject(sfxName + "Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = SFXmixer.FindMatchingGroups("Close")[0];
            audioSource.clip = sfxlist[7];
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.Play();
            Destroy(go, sfxlist[7].length);
        }
        if (sfxName == "Buy")
        {
            GameObject go = new GameObject(sfxName + "Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = SFXmixer.FindMatchingGroups("Buy")[0];
            audioSource.clip = sfxlist[8];
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.Play();
            Destroy(go, sfxlist[8].length);
        }
        if (sfxName == "GameStart")
        {
            GameObject go = new GameObject(sfxName + "Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = SFXmixer.FindMatchingGroups("GameStart")[0];
            audioSource.clip = sfxlist[9];
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.Play();
            Destroy(go, sfxlist[9].length);
        }
    }

    public void BGMPlay(AudioClip clip)
    {
        BGM.clip = clip;
        BGM.loop = true;
        BGM.Play();

    }

    public void SetBGMVolume(float volume)
    {
        BGM.volume = volume;
    }

}
