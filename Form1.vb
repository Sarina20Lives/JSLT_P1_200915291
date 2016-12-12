Public Class Form1

    Private Sub Banalizar_Click(sender As Object, e As EventArgs) Handles Banalizar.Click
        EvaluarCadena(RTBentrada.Text)
    End Sub

    Public Sub EvaluarCadena(ByVal text As String)
        Dim Cadena As System.IO.StringReader = New System.IO.StringReader(text)
        Setup()
        Parse(Cadena)

    End Sub

End Class
