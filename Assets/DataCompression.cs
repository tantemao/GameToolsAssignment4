using UnityEngine;
using System;

public static class DataCompression
{
    public static byte[] CompressData(byte[] data)
    {
        // Simulated data compression for testing
        Debug.Log("Compressing data...");
        byte[] compressedData = new byte[data.Length / 2];
        for (int i = 0; i < data.Length; i += 2)
        {
            compressedData[i / 2] = (byte)(data[i] + data[i + 1]);
        }
        Debug.Log("Compressed data: " + BitConverter.ToString(compressedData));
        return compressedData;
    }

    public static byte[] DecompressData(byte[] compressedData)
    {
        // Simulated data decompression for testing
        Debug.Log("Decompressing data...");
        byte[] decompressedData = new byte[compressedData.Length * 2];
        for (int i = 0; i < compressedData.Length; i++)
        {
            decompressedData[i * 2] = (byte)(compressedData[i] / 2);
            decompressedData[i * 2 + 1] = (byte)(compressedData[i] - decompressedData[i * 2]);
        }
        Debug.Log("Decompressed data: " + BitConverter.ToString(decompressedData));
        return decompressedData;
    }
}
