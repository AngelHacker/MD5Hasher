Imports System.Security.Cryptography
Imports System.Text

Public Class GetMd5Hash
    Private Shared Function ComputeHashMD5(myByte() As Byte) As String
        '创建MD5实例
        Dim md5Hasher As MD5 = MD5.Create()
        '计算MD5，Imports System.Security.Cryptography
        Dim data As Byte() = md5Hasher.ComputeHash(myByte)
        '创建可变字符串，Imports System.Text
        Dim myStringBuilder As New StringBuilder()

        ' 连接每一个 byte 的 hash 码，并格式化为十六进制字符串
        For i = 0 To data.Length - 1
            myStringBuilder.Append(data(i).ToString("x2"))
        Next i
        Return myStringBuilder.ToString
    End Function
    ''' <summary>
    ''' 计算文件的MD5值
    ''' </summary>
    ''' <param name="myFilePath">文件的绝对路径</param>
    ''' <returns>返回32位MD5值</returns>
    ''' <remarks></remarks>
    Public Function GetFileMd5Hash(ByVal myFilePath As String) As String
        Dim ret As String
        '以字节形式读取文件
        Try
            Dim originalDate As Byte() = My.Computer.FileSystem.ReadAllBytes(myFilePath)
            ret = ComputeHashMD5(originalDate)
        Catch ex As Exception
            ret = String.Empty
        End Try
        Return ret
    End Function

    ''' <summary>
    ''' 计算字符串的MD5值
    ''' </summary>
    ''' <param name="myString">待计算的字符串</param>
    ''' <returns>返回32位MD5值</returns>
    ''' <remarks>计算字符串的 MD5 哈希值，并将该哈希作为 32 字符的十六进制格式字符串返回。此哈希字符串与能创建 32 字符的十六进制格式哈希字符串的任何 MD5 哈希函数（在任何平台上）兼容。</remarks>
    Public Function GetStrMd5Hash(ByVal myString As String) As String
        '将输入内容转换为byte数组并计算其hash值
        Return ComputeHashMD5(Encoding.Default.GetBytes(myString))
    End Function
End Class
