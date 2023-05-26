using UnityEngine;
using System;
public class Frontend : MonoBehaviour
{
    private EncryptedInputSender inputSender;
    private string encryptionKey;

    private void Start()
    {
        inputSender = new EncryptedInputSender();
        encryptionKey = GenerateEncryptionKey();
    }

    private void Update()
    {
        // Gather input from the player
        byte[] playerInput = GatherPlayerInput();

        // Encrypt the input
        byte[] encryptedInput = EncryptInput(playerInput, encryptionKey);

        // Pack the data
        int[] packedData = PackData(encryptedInput);

        // Gate transmission through a lock step
        LockstepManager lockstepManager = new LockstepManager();
        lockstepManager.StartLockstepSimulation();

        // Send data to the backend
        SendDataToBackend(packedData);

        // Process data received from the backend
        byte[] receivedData = ReceiveDataFromBackend();

        // Decrypt the received data
        byte[] decryptedData = DecryptData(receivedData, encryptionKey);

        // Unpack the data
        byte[] unpackedData = UnpackData(decryptedData);

        // Update game objects or game states using the unpacked data
        UpdateGameObjects(unpackedData);
    }

    private byte[] GatherPlayerInput()
    {
        // Simulated player input for testing
        byte[] input = new byte[4] { 1, 2, 3, 4 };
        return input;
    }

    private string GenerateEncryptionKey()
    {
        // Simulated encryption key generation for testing
        return "encryptionKey";
    }

    private byte[] EncryptInput(byte[] input, string encryptionKey)
    {
        // Simulated input encryption for testing
        Debug.Log("Encrypting input...");
        byte[] encryptedInput = new byte[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            encryptedInput[i] = (byte)(input[i] ^ encryptionKey[i % encryptionKey.Length]);
        }
        Debug.Log("Encrypted input: " + BitConverter.ToString(encryptedInput));
        return encryptedInput;
    }

    private int[] PackData(byte[] data)
    {
        // Simulated data packing for testing
        Debug.Log("Packing data...");
        int[] packedData = new int[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            packedData[i] = data[i] << 8 | data[i];
        }
        Debug.Log("Packed data: " + string.Join(", ", packedData));
        return packedData;
    }

    private void SendDataToBackend(int[] packedData)
    {
        Debug.Log("Sending data to backend...");
        byte[] packedBytes = ConvertIntArrayToByteArray(packedData);
        inputSender.SendEncryptedInput(packedBytes, encryptionKey);
    }

    private byte[] ReceiveDataFromBackend()
    {
        // Simulated receiving data from backend for testing
        Debug.Log("Receiving data from backend...");
        byte[] receivedData = new byte[4] { 128, 64, 32, 16 };
        Debug.Log("Received data: " + BitConverter.ToString(receivedData));
        return receivedData;
    }

    private byte[] DecryptData(byte[] data, string encryptionKey)
    {
        // Simulated data decryption for testing
        Debug.Log("Decrypting data...");
        byte[] decryptedData = new byte[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            decryptedData[i] = (byte)(data[i] ^ encryptionKey[i % encryptionKey.Length]);
        }
        Debug.Log("Decrypted data: " + BitConverter.ToString(decryptedData));
        return decryptedData;
    }

    private byte[] UnpackData(byte[] packedData)
    {
        // Simulated data unpacking for testing
        Debug.Log("Unpacking data...");
        byte[] unpackedData = new byte[packedData.Length];
        for (int i = 0; i < packedData.Length; i++)
        {
            unpackedData[i] = (byte)(packedData[i] >> 8);
        }
        Debug.Log("Unpacked data: " + BitConverter.ToString(unpackedData));
        return unpackedData;
    }

    private void UpdateGameObjects(byte[] data)
    {
        // Simulated game object update for testing
        Debug.Log("Updating game objects with data: " + BitConverter.ToString(data));
    }

    private byte[] ConvertIntArrayToByteArray(int[] data)
    {
        byte[] byteArray = new byte[data.Length * 4];
        for (int i = 0; i < data.Length; i++)
        {
            byte[] intBytes = System.BitConverter.GetBytes(data[i]);
            System.Buffer.BlockCopy(intBytes, 0, byteArray, i * 4, 4);
        }
        return byteArray;
    }
}
