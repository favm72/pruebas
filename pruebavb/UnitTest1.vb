Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()
        Dim ext = "asdasda.PDF.".Split(".").LastOrDefault()
        Assert.AreEqual("", ext)

    End Sub

    <TestMethod()> Public Sub TestMethod2()
        Dim input As String = "A\5/BC+*12.5as-/das"
        Dim nueva As String = Regex.Replace(input, "[^0-9.]+", "")
        Assert.AreEqual(12.5R, CDbl(nueva))
    End Sub

    <TestMethod()> Public Sub TestMethod3()
        Dim key As String = "@@++YSYS@-"
        Dim keyArray As Byte()
        Dim arrValue As Byte() = UTF8Encoding.UTF8.GetBytes("")
        Dim hashmd5 As New MD5CryptoServiceProvider()
        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key))
        hashmd5.Clear()
        Dim tdes As New TripleDESCryptoServiceProvider()
        tdes.Key = keyArray
        tdes.Mode = CipherMode.ECB
        tdes.Padding = PaddingMode.PKCS7

        Dim cTransform As ICryptoTransform = tdes.CreateEncryptor()
        Dim ArrayResultado As Byte() = cTransform.TransformFinalBlock(arrValue, 0, arrValue.Length)
        tdes.Clear()
        Dim nuevo = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length)
        Assert.AreEqual("", nuevo)
    End Sub
End Class