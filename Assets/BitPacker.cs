using UnityEngine;
public static class BitPacker
{
    public static uint PackBits(int[] bits)
    {
        uint packedData = 0;
        // Simulated bit packing for testing
        Debug.Log("Packing bits...");
        for (int i = 0; i < bits.Length; i++)
        {
            packedData |= (uint)(bits[i] << i);
        }
        Debug.Log("Packed bits: " + packedData);
        return packedData;
    }

    public static int[] UnpackBits(uint packedData, int numBits)
    {
        int[] unpackedBits = new int[numBits];
        // Simulated bit unpacking for testing
        Debug.Log("Unpacking bits...");
        for (int i = 0; i < numBits; i++)
        {
            unpackedBits[i] = (int)((packedData >> i) & 1);
        }
        Debug.Log("Unpacked bits: " + string.Join(", ", unpackedBits));
        return unpackedBits;
    }
}
