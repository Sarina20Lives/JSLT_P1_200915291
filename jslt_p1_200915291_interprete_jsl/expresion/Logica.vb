Public Class Logica

    Private entorno As Entorno = Nothing
    Private casteo As Casteos = New Casteos
    Private comprobacion As ComprobacionTipos = New ComprobacionTipos

    Public Function resolverLogica(ByRef ent As Entorno, ByVal expresion As Nodo)
        Dim resultado As Resultado = New Resultado

        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz

        Dim expr As Expresion = New Expresion
        'Comprobando errores op1
        Dim op1 As Resultado = expr.resolver(entorno, CType(expresion.getHijo(0), Nodo))
        If (op1.tipo <> Constantes.T_BOOLEAN) Then
            Return resultado
        End If

        'Casos unitarios
        Select Case expresion.subrol
            Case Constantes.SR_NOT
                Return negacion(op1)
        End Select

        'Comprobando errores op2
        Dim op2 As Resultado = expr.resolver(entorno, CType(expresion.getHijo(1), Nodo))
        If (op1.tipo <> Constantes.T_BOOLEAN) Then
            Return resultado
        End If


        'Casos binarios
        Select Case expresion.subrol
            Case Constantes.SR_AND
                Return logAnd(op1, op2)
            Case Constantes.SR_NAND
                Return logNand(op1, op2)
            Case Constantes.SR_OR
                Return logOr(op1, op2)
            Case Constantes.SR_NOR
                Return logNor(op1, op2)
            Case Constantes.SR_XOR
                Return logXor(op1, op2)
        End Select
        Return resultado

    End Function

    Private Function negacion(ByVal op1 As Resultado)
        Dim resultado As Resultado = New Resultado
        resultado.tipo = Constantes.T_BOOLEAN
        If (casteo.castStrToBool(op1.valor)) Then
            resultado.valor = "false"
            Return resultado
        End If
        resultado.valor = "true"
        Return resultado
    End Function

    Private Function logAnd(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        resultado.tipo = Constantes.T_BOOLEAN
        If (casteo.castStrToBool(op1.valor) And casteo.castStrToBool(op2.valor)) Then
            resultado.valor = "true"
            Return resultado
        End If
        resultado.valor = "false"
        Return resultado
    End Function

    Private Function logNand(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        resultado.tipo = Constantes.T_BOOLEAN
        If (casteo.castStrToBool(op1.valor) And casteo.castStrToBool(op2.valor)) Then
            resultado.valor = "false"
            Return resultado
        End If
        resultado.valor = "true"
        Return resultado
    End Function

    Private Function logOr(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        resultado.tipo = Constantes.T_BOOLEAN
        If (casteo.castStrToBool(op1.valor) Or casteo.castStrToBool(op2.valor)) Then
            resultado.valor = "true"
            Return resultado
        End If
        resultado.valor = "false"
        Return resultado
    End Function

    Private Function logNor(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        resultado.tipo = Constantes.T_BOOLEAN
        If (casteo.castStrToBool(op1.valor) Or casteo.castStrToBool(op2.valor)) Then
            resultado.valor = "false"
            Return resultado
        End If
        resultado.valor = "true"
        Return resultado
    End Function

    Private Function logXor(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        resultado.tipo = Constantes.T_BOOLEAN
        If (casteo.castStrToBool(op1.valor) <> casteo.castStrToBool(op2.valor)) Then
            resultado.valor = "true"
            Return resultado
        End If
        resultado.valor = "false"
        Return resultado
    End Function

End Class
