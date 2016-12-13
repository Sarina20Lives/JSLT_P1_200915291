Public Class ManejoArchivos



    Public Function leer(ByVal directorio As String)
        Dim contActual As String = ""
        Dim sr As New System.IO.StreamReader(Constantes.DIRECTORIO)
        contActual = sr.ReadToEnd()
        sr.Close()
        Return contActual
    End Function

    Public Sub escribirHtml(ByVal contNuevo As String)
        Dim sw As New System.IO.StreamWriter(Constantes.DIRECTORIO)
        sw.WriteLine(contNuevo)
        sw.Close()
    End Sub

    Public Sub appendHtml(ByVal contNuevo As String)
        Dim contActual As String = ""
        Dim sr As New System.IO.StreamReader(Constantes.DIRECTORIO)
        contActual = sr.ReadToEnd()
        sr.Close()
        contActual += contNuevo
        Dim sw As New System.IO.StreamWriter(Constantes.DIRECTORIO)
        sw.WriteLine(contActual)
        sw.Close()
    End Sub

End Class
