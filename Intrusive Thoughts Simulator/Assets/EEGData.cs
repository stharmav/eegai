using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using UnityEngine.UI;

public class EEGData : MonoBehaviour
{
    public OSC osc;

    public bool useEEG = true;
    public bool useAlpha = true;
    public bool useBeta = true;
    public bool useDelta = true;
    public bool useTheta = true;
    public bool useGamma = true;
    public bool useAcc = true;
    //public bool useBlink = true;  

    public string museName = "/muse";

    public static float[] eegData;
    public static float[] alphaData;
    public static float[] betaData;
    public static float[] deltaData;
    public static float[] thetaData;
    public static float[] gammaData;
    public static float[] accData;

    public Text output;

    // Script initialization
    void Start()
    {

        UnityEngine.Debug.Log("Started");
        output.text = "Connecting...";

        osc = GetComponent<OSC>();

        eegData = new float[4];
        alphaData = new float[4];
        betaData = new float[4];
        thetaData = new float[4];
        deltaData = new float[4];
        gammaData = new float[4];
        accData = new float[3];

        if (useEEG) osc.SetAddressHandler(museName + "/eeg", OnReceiveEEG);
        if (useAlpha) osc.SetAddressHandler(museName + "/elements/alpha_absolute", OnReceiveAlpha);
        if (useBeta) osc.SetAddressHandler(museName + "/elements/beta_absolute", OnReceiveBeta);
        if (useTheta) osc.SetAddressHandler(museName + "/elements/theta_absolute", OnReceiveTheta);
        if (useGamma) osc.SetAddressHandler(museName + "/elements/gamma_absolute", OnReceiveGamma);
        if (useDelta) osc.SetAddressHandler(museName + "/elements/delta_absolute", OnReceiveDelta);
        if (useAcc) osc.SetAddressHandler(museName + "/acc", OnReceiveAcc);
    }

    // NOTE: The received messages at each server are updated here
    void Update()
    {
        float avAlpha = 0f;
        foreach (float a in alphaData) {
            avAlpha += a;
        }
        output.text = "Alpha: " + avAlpha;
    }

    void OnReceiveEEG(OscMessage message)
    {
        for (int i = 0; i < 4; i++)
        {
            eegData[i] = message.GetFloat(i);
        }
    }

    void OnReceiveAlpha(OscMessage message)
    {
        for (int i = 0; i < 4; i++)
        {
            alphaData[i] = message.GetFloat(i);
        }
    }

    void OnReceiveBeta(OscMessage message)
    {
        for (int i = 0; i < 4; i++)
        {
            betaData[i] = message.GetFloat(i);
        }
    }

    void OnReceiveGamma(OscMessage message)
    {
        for (int i = 0; i < 4; i++)
        {
            gammaData[i] = message.GetFloat(i);
        }
    }

    void OnReceiveDelta(OscMessage message)
    {
        for (int i = 0; i < 4; i++)
        {
            deltaData[i] = message.GetFloat(i);
        }
    }

    void OnReceiveTheta(OscMessage message)
    {
        for (int i = 0; i < 4; i++)
        {
            thetaData[i] = message.GetFloat(i);
        }
    }

    void OnReceiveAcc(OscMessage message)
    {
        for (int i = 0; i < 3; i++)
        {
            accData[i] = message.GetFloat(i);
        }
    }

}