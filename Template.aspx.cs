using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Security;
using System.Security.Cryptography;
using System.Text;

public partial class Default_Template : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button5_Click(object sender, EventArgs e)
    {

    }

    public static bool Verify(string plainText, string hashValue)
    {
        //convert hash value into byte array
        byte[] byteHashSalt = Convert.FromBase64String(hashValue);

        int hashByteSize;
        hashByteSize = 20; //this is the hash size of the secure hash algorithm

        // If the hash value is less than the standard byte size, it is not valid.
        // As it would not have been done with the same algorithm.
        if (byteHashSalt.Length < hashByteSize)
        {
            return false;
        }

        // Array holds the original salt bytes from the hash value.
        byte[] saltBytes = new byte[byteHashSalt.Length - hashByteSize];

        // Copy salt from the end of the hash to the new array.
        for (int i = 0; i < saltBytes.Length; i++)
        {
            saltBytes[i] = byteHashSalt[hashByteSize + i];
        }

        string expectedHashString = HashPassword(plainText, saltBytes);
        return (hashValue == expectedHashString);
    }

    public static string HashPassword(string Password, byte[] saltBytes)
    {
        if (saltBytes == null)
        {
            // Generate random number for salt between 4 and 8.
            Random random = new Random();
            int saltSize = random.Next(4, 8);

            // New byte array which holds salt.
            saltBytes = new byte[saltSize];

            // Create secure new random generator.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            // Assign the salt secure byte values.
            rng.GetNonZeroBytes(saltBytes);
        }

        // Convert password into array of bytes.
        byte[] PasswordBytes = Encoding.UTF8.GetBytes(Password);

        // Create array which will hold the password and the salt
        byte[] PasswordWithSaltBytes = new byte[PasswordBytes.Length + saltBytes.Length];

        // Copy password bytes into array.
        for (int i = 0; i < PasswordBytes.Length; i++)
        {
            PasswordWithSaltBytes[i] = PasswordBytes[i];
        }


        // Add salt bytes to array.
        for (int i = 0; i < saltBytes.Length; i++)
        {
            PasswordWithSaltBytes[PasswordBytes.Length + i] = saltBytes[i];
        }

        HashAlgorithm hash;
        hash = new SHA1Managed();

        // Compute a hash value for the password with its salt.
        byte[] hashBytes = hash.ComputeHash(PasswordWithSaltBytes);

        // Create array that will hold the bytes and the salt.
        byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];

        // Copy hash bytes into new salt hash array.
        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashWithSaltBytes[i] = hashBytes[i];
        }

        // Add salt bytes to the calculated hash.
        for (int i = 0; i < saltBytes.Length; i++)
        {
            hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];
        }

        // Convert result into a string.
        string hashValue = Convert.ToBase64String(hashWithSaltBytes);

        // Return the result.
        return hashValue;
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        TextBox1.Text = HashPassword(TextBox2.Text,null);

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        if(Verify(TextBox3.Text,TextBox1.Text))
        {
            lblValid.Text = "True";
        }
    }
}