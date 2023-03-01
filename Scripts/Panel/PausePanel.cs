using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PausePanel : BasePanel
{
    //X��ť
    public Button xBtn;
    //���ֿ���
    public Toggle musicToggle;
    //��Ч����
    public Toggle soundToggle;
    //���ֻ���
    public Slider musicSlider;
    //��Ч����
    public Slider soundSlider;
    //������Ϸ��ť
    public Button goGameBtn;
    //��������Ϸ���水ť
    public Button goBkBtn;

    protected override void Init()
    {
        //��ͣ��Ϸ����
        MusicMgr.GetInstance().PauseBKMusic();
        //��ֹ���̿���
        GameManager.GetInstance().inputStop = true;
        //ÿ�δ����ʱͬ��һ������ϵ���������
        UpdateMusicData();

        xBtn.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            //������ͣ���
            UiManager.Instance.HidePanel<PausePanel>();
            //�ⴥ���̿���
            GameManager.GetInstance().inputStop = false;
            //������Ϸ������������
            MusicMgr.GetInstance().PlayBKMusic("Music" + SceneManager.GetActiveScene().name);
        });

        //������ϵ���������ͬ�������ݹ������Լ�������
        musicToggle.onValueChanged.AddListener((isOpen) =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            MusicManager.Instance.SetOpenMusic(isOpen);
        });
        soundToggle.onValueChanged.AddListener((isOpen) =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            DataManager.Instance.SetOpenSound(isOpen);
        });
        musicSlider.onValueChanged.AddListener((value) =>
        {
            MusicManager.Instance.SetMusicValue(value);
        });
        soundSlider.onValueChanged.AddListener((value) =>
        {
            DataManager.Instance.SetSoundValue(value);
        });
        goGameBtn.onClick.AddListener(() =>
        {
            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            //������ͣ���
            UiManager.Instance.HidePanel<PausePanel>();
            //������Ϸ������������
            MusicMgr.GetInstance().PlayBKMusic("Music"+SceneManager.GetActiveScene().name);
            //�ⴥ���̿���
            GameManager.GetInstance().inputStop = false;
        });
        goBkBtn.onClick.AddListener(() =>
        {

            //ͬ����Ч����
            DataManager.Instance.UpdateSoundData(clickAudioSource);
            //���ŵ����Ч
            clickAudioSource.Play();
            //�ر���Ϸ���
            UiManager.Instance.HidePanel<GameDataPanel>();
            //��ת��������ϷUI����
            SceneManager.LoadScene("UI");
            //��UI�������ı�������
            MusicManager.Instance.isPlayMusic(true);
            //������ͣ���
            UiManager.Instance.HidePanel<PausePanel>();
            //��ui�������
            UiManager.Instance.ShowPanel<BkPanel>();
            //��ui�����
            UiManager.Instance.ShowPanel<MainPanel>();
            //�ⴥ���̿���
            GameManager.GetInstance().inputStop = false;

        });
        //�������ʱ��ͣ��Ϸʱ��
        Time.timeScale = 0;
    }
    /// <summary>
    /// ͬ��һ������ϵ���������
    /// </summary>
    public void UpdateMusicData()
    {
        //ÿ�δ����ʱͬ��һ������ϵ���������
        MusicData musicData = DataManager.Instance.musicData;
        musicToggle.isOn = musicData.isOpenMusic;
        soundToggle.isOn = musicData.isOpenSound;
        musicSlider.value = musicData.musicValue;
        soundSlider.value = musicData.soundValue;
    }
    //�ر����ʱ�ָ���Ϸ�����ٶ�
    public override void HideSelf(UnityAction action)
    {
        base.HideSelf(action);
        Time.timeScale = 1f;
    }
}
