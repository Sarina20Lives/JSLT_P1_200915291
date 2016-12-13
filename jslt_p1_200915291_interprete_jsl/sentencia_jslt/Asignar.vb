Public Class Asignar

    Private entorno As Entorno = Nothing
    Private manArch As ManejoArchivos = New ManejoArchivos
    Dim casteo As Casteos = New Casteos


    Public Sub resolverAsig(ByRef ent As Entorno, ByVal nodo As Nodo)
        Dim exp As Expresion = New Expresion
        Dim resultado As Resultado = New Resultado
        Dim casteado As Resultado = New Resultado

        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz

        resultado = exp.resolver(entorno, nodo.getHijo(0))
        If (resultado.tipo = Constantes.ERR) Then
            'No se puede asignar, debido a que existe error en la expresion
            Return
        End If

        Dim obj As Simbolo
        For Each obj In entorno.ctxLocal
            If (obj.nombre = nodo.cad) Then
                casteado = casteo.getCasteo(obj.tipo, resultado)
                If (casteado.tipo = obj.tipo) Then
                    obj.valor = casteado.valor
                    obj.instancia = True
                    Return
                End If
            End If
        Next
        For Each obj In entorno.ctxGlobal
            If (obj.nombre = nodo.cad) Then
                casteado = casteo.getCasteo(obj.tipo, resultado)
                If (casteado.tipo = obj.tipo) Then
                    obj.valor = casteado.valor
                    obj.instancia = True
                    Return
                End If
            End If
        Next

    End Sub

    Public Sub resolverConcat(ByRef ent As Entorno, ByVal nodo As Nodo)
        Dim exp As Expresion = New Expresion
        Dim resultado As Resultado = New Resultado
        Dim casteado As Resultado = New Resultado

        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz

        resultado = exp.resolver(entorno, nodo.getHijo(0))
        If (resultado.tipo = Constantes.ERR) Then
            'No se puede asignar, debido a que existe error en la expresion
            Return
        End If

        Dim obj As Simbolo
        For Each obj In entorno.ctxLocal
            If (obj.nombre = nodo.cad) Then
                casteado = casteo.getCasteo(obj.tipo, resultado)
                If (casteado.tipo = obj.tipo) Then
                    If (obj.instancia) Then
                        obj.valor = concatenar(obj.tipo, obj.valor, casteado.valor)
                        Return
                    End If
                    obj.valor = casteado.valor
                    obj.instancia = True
                    Return
                End If
            End If
        Next
        For Each obj In entorno.ctxGlobal
            If (obj.nombre = nodo.cad) Then
                casteado = casteo.getCasteo(obj.tipo, resultado)
                If (casteado.tipo = obj.tipo) Then
                    If (obj.instancia) Then
                        obj.valor = concatenar(obj.tipo, obj.valor, casteado.valor)
                        Return
                    End If
                    obj.valor = casteado.valor
                    obj.instancia = True
                    Return
                End If
            End If
        Next
    End Sub


    Private Function concatenar(ByVal tipo As Integer, ByVal valI As String, ByVal valN As String)
        If (tipo = Constantes.T_DOBLE) Then
            Return "" + (casteo.castStrToDoble(valI) + casteo.castStrToDoble(valN))
        End If
        If (tipo = Constantes.T_ENTERO) Then
            Return "" + (casteo.castStrToInt(valI) + casteo.castStrToInt(valN))
        End If
        If (tipo = Constantes.T_CARACTER) Then
            Return "" + (casteo.castIntToChar(casteo.castCharToInt(valI) + casteo.castCharToInt(valN)))
        End If
        If (tipo = Constantes.T_CADENA) Then
            Return "" + valI + valN
        End If
        If (tipo = Constantes.T_BOOLEAN) Then
            If (casteo.castStrToBool(valI) Or casteo.castStrToBool(valN)) Then
                Return "true"
            End If
            Return "false"
        End If
        Return ""
    End Function

    Public Sub resolverPosInc(ByRef ent As Entorno, ByVal obj As Nodo)
        Dim aritmetica As Aritmetica = New Aritmetica
        Dim resultado As Resultado
        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz
        resultado = aritmetica.resolverAritmetica(entorno, obj)
    End Sub

    Public Sub resolverPosDec(ByRef ent As Entorno, ByVal obj As Nodo)
        Dim aritmetica As Aritmetica = New Aritmetica
        Dim resultado As Resultado
        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz
        resultado = aritmetica.resolverAritmetica(entorno, obj)
    End Sub

End Class
