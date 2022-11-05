Imports System.Data.SqlClient
Imports System.IO
Public Class Form1

    Dim c As New SqlConnectionStringBuilder
    Dim con As New SqlConnection
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        c.DataSource = "."
        c.InitialCatalog = "Tawfeek2"
        c.UserID = "sa"
        c.Password = ""
        con.ConnectionString = c.ConnectionString

    End Sub

    Dim path As String = "D:\TawfiqSror\doroos\"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each File In Directory.GetFiles(path)
            Dim str As String = File.Replace("." & File.Split(".").Last, "").Replace(path, "")
            For i As Integer = 0 To str.Split(" ").Length - 1
                Dim comstr As String = "insert names select '" & str.Split(" ")(i) & "'"
                Dim com As New SqlCommand(comstr, con)
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
            Next
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each File In Directory.GetFiles(path)
            Dim str As String = File.Replace("." & File.Split(".").Last, "").Replace(path, "")
            Directory.CreateDirectory(path & str)
            IO.File.Move(File, path & str & "\" & File.Split("\").Last)
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim path As String = "D:\Tawfiqsror بعد التعديل الثالث\"
        For Each File In Directory.GetFiles(path, "*", SearchOption.AllDirectories)
            Dim str As String = File.Split("\").Last
            While str.StartsWith("1 ") OrElse str.StartsWith("2 ") OrElse str.StartsWith("3 ") OrElse str.StartsWith("4 ") OrElse str.StartsWith("5 ") OrElse str.StartsWith("6 ") OrElse str.StartsWith("7 ") OrElse str.StartsWith("8 ") OrElse str.StartsWith("9 ")
                str = str.Substring(2)
            End While
            If str <> File.Split("\").Last Then
                Try
                    IO.File.Move(File, File.Replace(File.Split("\").Last, "") & str)
                Catch ex As Exception
                End Try
            End If
        Next
        MessageBox.Show("Done")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim path1 As String = "D:\1 - Tawfiqsror بعد التعديل\"
        Dim path2 As String = "D:\2 - Tawfiqsror بعد التعديل الثاني\"

        For Each File In Directory.GetFiles(path1, "*", SearchOption.AllDirectories)
            For Each File2 In Directory.GetFiles(path2, "*", SearchOption.AllDirectories)
                If File.Split("\").Last = File2.Split("\").Last Then
                    GoTo A
                End If
            Next
            RichTextBox1.Text &= File & vbCrLf
A:
        Next
        MessageBox.Show("Done")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim path As String = "D:\3 - Tawfiqsror بعد التعديل الثالث\"

        For Each File In Directory.GetFiles(path, "*", SearchOption.AllDirectories)
            Dim str As String = File.Replace(" .", ".").Replace(" .", ".").Replace(" .", ".")
            If File <> str Then
                Try
                    IO.File.Move(File, str)
                Catch ex As Exception
                End Try
            End If
        Next
        For Each File In Directory.GetFiles(path, "*", SearchOption.AllDirectories)
            Dim str As String = File.Split("\").Last
            If str.Split(".").Last.ToLower = "amr" Then
                Try
                    IO.File.Move(File, File.ToLower.Replace(".amr", " .mp3"))
                Catch ex As Exception
                End Try
            End If
            If str.Split(".").Last.ToLower = "wav" Then
                Try
                    IO.File.Move(File, File.ToLower.Replace(".wav", "  .mp3"))
                Catch ex As Exception
                End Try
            End If
            If str.Split(".").Last.ToLower = "wma" Then
                Try
                    IO.File.Move(File, File.ToLower.Replace(".wma", "   .mp3"))
                Catch ex As Exception
                End Try
            End If
        Next
        MessageBox.Show("Done")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim path As String = "D:\3 - Tawfiqsror بعد التعديل الثالث\تقطيع\"
        For Each File In Directory.GetFiles(path, "*", SearchOption.AllDirectories)
            IO.Directory.CreateDirectory(File.Replace("." & File.Split(".").Last, ""))
            IO.Directory.CreateDirectory(File.Replace("." & File.Split(".").Last, "") & "\المقطع")
            Try
                IO.File.Move(File, File.Replace("." & File.Split(".").Last, "") & "\" & File.Split("\").Last)
            Catch ex As Exception
                IO.File.Move(File, File.Replace("." & File.Split(".").Last, "") & "\..." & File.Substring(File.Length - 7))
            End Try
        Next
        MessageBox.Show("Done")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim path As String = "D:\3 - Tawfiqsror بعد التعديل الثالث\تقطيع\"
        For Each File In Directory.GetDirectories(path)
            Try
                IO.Directory.Delete(File & "\المقطع")
            Catch ex As Exception
            End Try
        Next
        MessageBox.Show("Done")
    End Sub
End Class
