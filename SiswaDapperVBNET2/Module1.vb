Imports System.Data.OleDb
Imports Dapper

Module Module1

    Private Function GetOpenConnection() As OleDbConnection
        Dim conn As OleDbConnection = Nothing

        Dim appDir As String = System.IO.Directory.GetCurrentDirectory()
        Dim strConn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appDir + "\SISWA.MDB;User Id=admin;Password=;"

        Try

            conn = New OleDbConnection(strConn)
            conn.Open()

        Catch ex As Exception

        End Try

        Return conn
    End Function

    Sub Main()

        Dim daftarSiswa = New List(Of Siswa)()
        Using conn As OleDbConnection = GetOpenConnection()
            Dim strSql = "SELECT nis, nama FROM siswa"
            daftarSiswa = conn.Query(Of Siswa)(strSql, Nothing).ToList()
        End Using

        Console.WriteLine("NIS" & vbTab & "NAMA")
        Console.WriteLine("===================================")

        For Each siswa In daftarSiswa
            Console.WriteLine(siswa.Nis & vbTab & siswa.Nama)
        Next

        Console.ReadKey()
    End Sub

End Module
