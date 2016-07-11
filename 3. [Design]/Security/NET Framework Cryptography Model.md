[.NET Framework Cryptography Model](https://msdn.microsoft.com/en-us/library/0ss79b2x.aspx)
---

The .NET Framework provides implementations of many standard cryptographic algorithms. These algorithms are easy to use and have the safest possible default properties. In addition, the .NET Framework cryptography model of object inheritance, stream design, and configuration is extremely extensible/

**Object Inheritance**

---

The .NET Framework security system implements an extensible pattern of derived class inheritance. The hierarchy is as follows: 

  - Algorithm type class, such as SymmetricAlgorithm, AsymmetricAlgorithm or HashAlgorithm. This level is abstract.
  - Algorithm class that inherits from an algorithm type class; for example, Aes, RC2, or ECDiffieHellman. This level is abstract.
  - mplementation of an algorithm class that inherits from an algorithm class; for example, AesManaged, RC2CryptoServiceProvider, or ECDiffieHellmanCng. This level is fully implemented.
  
Using this pattern of derived classes, it is easy to add a new algorithm or a new implementation of an existing algorithm. For example, to create a new public-key algorithm, you would inherit from the AsymmetricAlgorithm class. To create a new implementation of a specific algorithm, you would create a non-abstract derived class of that algorithm.

**How Algorithms Are Implemented in the .NET Framework**

---

As an example of the different implementations available for an algorithm, consider symmetric algorithms. The base for all symmetric algorithms is SymmetricAlgorithm, which is inherited by the following algorithms:

  - Aes
  - DES
  - RC2
  - Rijndael
  - TripleDES
  
Aes is inherited by two classes: AesCryptoServiceProvider and AesManaged. The AesCryptoServiceProvider class is a wrapper around the Windows Cryptography API (CAPI) implementation of Aes, whereas the AesManaged class is written entirely in managed code. There is also a third type of implementation, Cryptography Next Generation (CNG), in addition to the managed and CAPI implementations. An example of a CNG algorithm is ECDiffieHellmanCng. CNG algorithms are available on Windows Vista and later. 

You can choose which implementation is best for you. The managed implementations are available on all platforms that support the .NET Framework. The CAPI implementations are available on older operating systems, and are no longer being developed. CNG is the very latest implementation where new development will take place. However, the managed implementations are not certified by the Federal Information Processing Standards (FIPS), and may be slower than the wrapper classes.

**Stream Design**

---

The common language runtime uses a stream-oriented design for implementing symmetric algorithms and hash algorithms. The core of this design is the CryptoStream class, which derives from the Stream class. Stream-based cryptographic objects support a single standard interface (CryptoStream) for handling the data transfer portion of the object. Because all the objects are built on a standard interface, you can chain together multiple objects (such as a hash object followed by an encryption object), and you can perform multiple operations on the data without needing any intermediate storage for it. The streaming model also enables you to build objects from smaller objects. For example, a combined encryption and hash algorithm can be viewed as a single stream object, although this object might be built from a set of stream objects.

**Cryptographic Configuration**

---

Cryptographic configuration lets you resolve a specific implementation of an algorithm to an algorithm name, allowing extensibility of the .NET Framework cryptography classes. You can add your own hardware or software implementation of an algorithm and map the implementation to the algorithm name of your choice. If an algorithm is not specified in the configuration file, the default settings are used. For more information about cryptographic configuration, see Configuring Cryptography Classes.

**Choosing an Algorithm**

You can select an algorithm for different reasons: for example, for data integrity, for data privacy, or to generate a key. Symmetric and hash algorithms are intended for protecting data for either integrity reasons (protect from change) or privacy reasons (protect from viewing). Hash algorithms are used primarily for data integrity.

Here is a list of recommended algorithms by application:

    Data privacy:

        Aes

    Data integrity:

        HMACSHA256

        HMACSHA512

    Digital signature:

        ECDsa

        RSA

    Key exchange:

        ECDiffieHellman

        RSA

    Random number generation:

        RNGCryptoServiceProvider

    Generating a key from a password:

        Rfc2898DeriveBytes
