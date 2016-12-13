Public Class Form1

    Private Sub Banalizar_Click(sender As Object, e As EventArgs) Handles Banalizar.Click
        EvaluarCadena(RTBentrada.Text)
    End Sub

    Public Sub EvaluarCadena(ByVal text As String)
        Dim Cadena As System.IO.StringReader = New System.IO.StringReader(text)
        Setup()
        'false = json, true = jslt
        Dim analisis As Boolean = False
        Dim direccion As String = ""
        Dim raizJsl As Nodo = New Nodo
        Dim raizJson As PtrJson = New PtrJson
        Dim manArch As ManejoArchivos = New ManejoArchivos
        Parse(Cadena, analisis, raizJson, raizJsl, direccion)
        If (analisis) Then
            Dim transform As Transform = New Transform
            transform.resolverTransform(raizJsl, direccion)
        End If
    End Sub

End Class
