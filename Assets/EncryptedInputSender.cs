using UnityEngine;
using System;
public class EncryptedInputSender
{
    public void SendEncryptedInput(byte[] input, string encryptionKey)
    {
        // Simulated sending of encrypted input for testing
        Debug.Log("Sending encrypted input...");
        Debug.Log("Encrypted input: " + BitConverter.ToString(input));
        Debug.Log("Encryption key: " + encryptionKey);
        // ...
    }
}
