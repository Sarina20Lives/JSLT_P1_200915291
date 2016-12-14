Public Class Plantilla

    Private entorno As Entorno = Nothing

    Public Sub resolverPlantilla(ByRef ent As Entorno, ByVal raiz As Nodo)
        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno = entorno.crearEntorno(ent)

        Dim noprimero As Boolean = False
        Dim sentencia As Sentencia = Nothing
        Dim obj As Nodo
        For Each obj In raiz.hijos
            If (noprimero) Then
                sentencia = New Sentencia
                sentencia.resolver(entorno, obj)
            End If
            noprimero = True
        Next

    End Sub

End Class
