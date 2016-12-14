Public Class FlujoSwitch

    Private entorno As Entorno = Nothing

    Public Sub resolverSwitch(ByRef ent As Entorno, ByVal nodo As Nodo)
        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz
        Dim encontrado As Boolean = False
        Dim obj As Nodo
        For Each obj In nodo.hijos
            If (obj.subrol = Constantes.SR_CASO) Then
                encontrado = resolverCase(obj)
            End If
            If (encontrado) Then
                Return
            End If
            If (obj.subrol = Constantes.SR_DEFAULT) Then
                resolverDefault(obj)
                Return
            End If
        Next
    End Sub

    Private Function resolverCase(ByVal caso As Nodo)
        Dim exp As Expresion = New Expresion
        Dim casteo As Casteos = New Casteos
        Dim resultado As Resultado = exp.resolver(entorno, caso.getHijo(0))
        If (resultado.tipo <> Constantes.T_BOOLEAN) Then
            'Existe un problema en la condición
            Return False
        End If
        If (casteo.castStrToBool(resultado.valor)) Then
            Dim noprimero As Boolean = False
            Dim sentencia As Sentencia = Nothing
            Dim obj As Nodo
            For Each obj In caso.hijos
                If (noprimero) Then
                    sentencia = New Sentencia
                    sentencia.resolver(entorno, obj)
                End If
                noprimero = True
            Next
            Return True
        End If
        Return False
    End Function

    Private Sub resolverDefault(ByVal def As Nodo)
        Dim sentencia As Sentencia = Nothing
        Dim obj As Nodo
        For Each obj In def.hijos
            sentencia = New Sentencia
            sentencia.resolver(entorno, obj)
        Next
    End Sub

End Class
