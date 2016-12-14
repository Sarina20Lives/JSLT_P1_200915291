Public Class BucleFor

    Private entorno As Entorno = Nothing

    Public Sub resolverFor(ByRef ent As Entorno, ByVal nodo As Nodo)
        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno = entorno.crearEntorno(ent)

        Dim obj As Nodo = nodo.getHijo(0)
        Dim ambitos As ArrayList = New ArrayList
        If (obj.subrol <> Constantes.SR_COLLECTION) Then
            Return
        End If
        ambitos = entorno.ambito.getHijos(obj.cad)

        Dim noprimero As Boolean = False
        Dim sentencia As Sentencia = Nothing
        Dim hijo As Nodo
        Dim entTemp As Entorno
        Dim ptr As PtrJson
        For Each ptr In ambitos
            noprimero = False
            entTemp = New Entorno
            entTemp.ambito = ptr
            entTemp.ctxGlobal = entorno.ctxGlobal
            entTemp.ctxLocal = entorno.ctxLocal
            entTemp.raiz = entorno.raiz
            For Each hijo In nodo.hijos
                If (noprimero) Then
                    sentencia = New Sentencia
                    sentencia.resolver(entTemp, hijo)
                End If
                noprimero = True
            Next
        Next
    End Sub


End Class
