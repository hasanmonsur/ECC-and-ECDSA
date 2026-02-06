// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;

Console.WriteLine("Signature Generate ");


// Create ECC key using NIST P-256 curve
using ECDsa ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);

ECParameters privateKey = ecdsa.ExportParameters(true);
ECParameters publicKey = ecdsa.ExportParameters(false);

Console.WriteLine($"ECC Private Key Generated X:   {Convert.ToBase64String(privateKey.Q.X)}");
Console.WriteLine($"ECC Private Key Generated Y:   {Convert.ToBase64String(privateKey.Q.Y)}");

Console.WriteLine($"ECC Public Key Generated X:   {Convert.ToBase64String(publicKey.Q.X)}");
Console.WriteLine($"ECC Public Key Generated Y:   {Convert.ToBase64String(publicKey.Q.Y)}");


Console.WriteLine("Sifganture Verify");


byte[] data = Encoding.UTF8.GetBytes("Hello Secure World");

// Sign data
byte[] signature = ecdsa.SignData(data, HashAlgorithmName.SHA256);

Console.WriteLine($"Sign data :   {Convert.ToBase64String(signature)}");

// Verify signature
bool isValid = ecdsa.VerifyData(data, signature, HashAlgorithmName.SHA256);

Console.WriteLine($"Signature Valid: {isValid}");

