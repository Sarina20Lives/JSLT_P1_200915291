Public Class FlujoIf

    Private entorno As Entorno = Nothing

    Public Sub resolverIf(ByRef ent As Entorno, ByVal nodo As Nodo)
        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz
        Dim exp As Expresion = New Expresion
        Dim casteo As Casteos = New Casteos
        Dim resultado As Resultado = exp.resolver(entorno, nodo.getHijo(0))
        If (resultado.tipo <> Constantes.T_BOOLEAN) Then
            'Existe un problema en la condición
            Return
        End If
        If (casteo.castStrToBool(resultado.valor)) Then
            Dim noprimero As Boolean = False
            Dim sentencia As Sentencia = Nothing
            Dim obj As Nodo
            For Each obj In nodo.hijos
                If (noprimero) Then
                    sentencia = New Sentencia
                    sentencia.resolver(entorno, obj)
                End If
                noprimero = True
            Next
        End If
    End Sub

End Class
