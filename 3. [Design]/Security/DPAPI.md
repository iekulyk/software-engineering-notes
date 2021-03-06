DPAPI
---

Data Protection API (DPAPI).  DPAPI consists of two functions, CryptProtectData and CryptUnprotectData. One of the hardest things to do when implementing a secure cryptographic system is key management. 

DPAPI works by generating a key from the current user’s credentials (generally their password, although a smart card will provide a different credential).  It then generates a master key, and encrypts this with the key generated by the user’s credentials.  A random session key is created for each call to CryptProtectData.  This key is derived from the master key, some random data, and some optional entropy passed in by the user.  The session key is then used to do the actual encryption.  Rather than storing the session key, the random data used in key creation is stored in the encrypted output.

For added security, the master key expires every few months.  When this happens, a new master key is generated, but the old one is retained for use in decrypting any data that it had previously encrypted.  This limits the amount of data that an attacker who has compromised a single master key can decrypt.

Notice how the entire system is based on the current user’s password.  What happens when you change your password?  DPAPI will hook the password changing event, and re-encrypt the master keys using the new password.

The output from CryptProtectData is contains not only the encrypted data, but also the master key GUID, the random data used to create the session key, as well as a possible salt value and a HMAC signature of the blob to ensure that it isn’t tampered with.  However, you should always treat this output as an opaque blob that is only useful as input to CryptUnprotectData.  DPAPI will not store this blob, so its up to the calling application to persist it if needed.

DPAPI also provides a flag to work in machine mode rather that in user mode.  This mode encrypts that data such that any process on the current machine can decrypt it.

---


````
byte[] entropy = new byte[] { 0x21, 0x05, 0x07, 0x08, 0x27, 0x02, 0x23 };
        
byte[] sensitiveData = Encoding.Unicode.GetBytes(“Some sensitive data”);
byte[] protectedData = ProtectedData.Protect(sensitiveData, entropy, DataProtectionScope.CurrentUser);

PrintBytes(protectedData); // utility function that simply prints out the byte array — not part of the framework

byte[] unprotectedBytes = ProtectedData.Unprotect(protectedData, entropy, DataProtectionScope.CurrentUser);
Console.WriteLine(Encoding.Unicode.GetString(unprotectedBytes))


The output of this simple code snippet is:


01, 00, 00, 00, D0, 8C, 9D, DF, 01, 15
D1, 11, 8C, 7A, 00, C0, 4F, C2, 97, EB
01, 00, 00, 00, A1, 7A, 33, 0B, 3A, 5A
EF, 44, 80, B3, 2E, A7, D2, 15, BE, EC
00, 00, 00, 00, 02, 00, 00, 00, 00, 00
03, 66, 00, 00, A8, 00, 00, 00, 10, 00
00, 00, 81, B5, A3, 00, 84, D6, 06, 22
B3, DD, 02, F4, 53, 32, C8, 88, 00, 00
00, 00, 04, 80, 00, 00, A0, 00, 00, 00
10, 00, 00, 00, E8, BC, A2, CE, 88, 37
8E, 21, 20, 40, A4, 9E, A3, B9, FC, 47
28, 00, 00, 00, 92, 1F, 97, 84, 4B, A8
B9, 2A, CB, 9F, AA, C7, 36, 59, 52, AB
17, 22, 34, 5D, 79, 19, 70, FD, A1, CC
33, E0, B7, D4, 1B, DC, 76, 6E, D3, 50
C0, BF, 8A, 8F, 14, 00, 00, 00, 83, DE
8E, F8, FB, 4F, 0E, 43, FF, 8B, 65, D9
6E, BF, 1D, 95, 28, 67, 21, DD
Some sensitive data
```
