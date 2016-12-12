Public Class Relacional

    Private entorno As Entorno = Nothing
    Private casteo As Casteos = New Casteos
    Private comprobacion As ComprobacionTipos = New ComprobacionTipos

    Public Function resolverRelacional(ByRef ent As Entorno, ByVal expresion As Nodo)
        Dim resultado As Resultado = New Resultado

        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz

        'Casos unitarios
        Select Case expresion.subrol
            Case Constantes.SR_NULO
                Return nulo(expresion.cad)
        End Select

        Dim expr As Expresion = New Expresion
        'Comprobando errores op1
        Dim op1 As Resultado = expr.resolver(entorno, CType(expresion.getHijo(0), Nodo))
        If (op1.tipo = Constantes.ERR) Then
            Return resultado
        End If
        'Comprobando errores op2
        Dim op2 As Resultado = expr.resolver(entorno, CType(expresion.getHijo(1), Nodo))
        If (op2.tipo = Constantes.ERR) Then
            Return resultado
        End If


        'Casos binarios
        Select Case expresion.subrol
            Case Constantes.SR_IGUAL
                Return igual(op1, op2)
            Case Constantes.SR_DIFERENTE
                Return diferente(op1, op2)
            Case Constantes.SR_MAYOR
                Return mayor(op1, op2)
            Case Constantes.SR_MAYOR_IGUAL
                Return mayorIgual(op1, op2)
            Case Constantes.SR_MENOR
                Return menor(op1, op2)
            Case Constantes.SR_MENOR_IGUAL
                Return menorIgual(op1, op2)
        End Select
        Return resultado

    End Function

    Private Function nulo(ByVal id As String)
        Dim resultado As Resultado = New Resultado
        resultado.tipo = Constantes.T_BOOLEAN
        resultado.valor = "false"

        Dim obj As Simbolo
        For Each obj In entorno.ctxLocal
            If (obj.nombre = id And obj.instancia) Then
                resultado.tipo = Constantes.T_BOOLEAN
                resultado.valor = "true"
                Return resultado
            End If
        Next

        For Each obj In entorno.ctxGlobal
            If (obj.nombre = id And obj.instancia) Then
                resultado.tipo = Constantes.T_BOOLEAN
                resultado.valor = "true"
                Return resultado
            End If
        Next
        Return resultado
    End Function

    Private Function igual(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        resultado.tipo = Constantes.T_BOOLEAN
        If (op1.tipo = op2.tipo And op1.valor = op2.valor) Then
            resultado.valor = "true"
            Return resultado
        End If
        resultado.valor = "false"
        Return resultado
    End Function

    Private Function diferente(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        resultado.tipo = Constantes.T_BOOLEAN
        If (op1.tipo <> op2.tipo Or op1.valor <> op2.valor) Then
            resultado.valor = "true"
            Return resultado
        End If
        resultado.valor = "false"
        Return resultado
    End Function

    Private Function mayor(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        If (comprobacion.tipoRelacional(op1.tipo, op2.tipo) <> Constantes.T_BOOLEAN) Then
            Return resultado
        End If
        resultado.tipo = Constantes.T_BOOLEAN
        If (op1.tipo = Constantes.T_DOBLE Or op2.tipo = Constantes.T_DOBLE) Then
            Dim val1 As Double = casteo.obtenerDouble(op1)
            Dim val2 As Double = casteo.obtenerDouble(op2)
            If (val1 > val2) Then
                resultado.valor = "true"
            End If
            Return resultado
        End If

        Dim v1 As Integer = casteo.obtenerInt(op1)
        Dim v2 As Integer = casteo.obtenerInt(op2)
        resultado.valor = "false"
        If (v1 > v2) Then
            resultado.valor = "true"
        End If
        Return resultado
    End Function

    Private Function mayorIgual(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        If (comprobacion.tipoRelacional(op1.tipo, op2.tipo) <> Constantes.T_BOOLEAN) Then
            Return resultado
        End If
        resultado.tipo = Constantes.T_BOOLEAN
        If (op1.tipo = Constantes.T_DOBLE Or op2.tipo = Constantes.T_DOBLE) Then
            Dim val1 As Double = casteo.obtenerDouble(op1)
            Dim val2 As Double = casteo.obtenerDouble(op2)
            If (val1 >= val2) Then
                resultado.valor = "true"
            End If
            Return resultado
        End If

        Dim v1 As Integer = casteo.obtenerInt(op1)
        Dim v2 As Integer = casteo.obtenerInt(op2)
        resultado.valor = "false"
        If (v1 >= v2) Then
            resultado.valor = "true"
        End If
        Return resultado
    End Function

    Private Function menor(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        If (comprobacion.tipoRelacional(op1.tipo, op2.tipo) <> Constantes.T_BOOLEAN) Then
            Return resultado
        End If
        resultado.tipo = Constantes.T_BOOLEAN
        If (op1.tipo = Constantes.T_DOBLE Or op2.tipo = Constantes.T_DOBLE) Then
            Dim val1 As Double = casteo.obtenerDouble(op1)
            Dim val2 As Double = casteo.obtenerDouble(op2)
            If (val1 < val2) Then
                resultado.valor = "true"
            End If
            Return resultado
        End If

        Dim v1 As Integer = casteo.obtenerInt(op1)
        Dim v2 As Integer = casteo.obtenerInt(op2)
        resultado.valor = "false"
        If (v1 < v2) Then
            resultado.valor = "true"
        End If
        Return resultado
    End Function

    Private Function menorIgual(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        If (comprobacion.tipoRelacional(op1.tipo, op2.tipo) <> Constantes.T_BOOLEAN) Then
            Return resultado
        End If
        resultado.tipo = Constantes.T_BOOLEAN
        If (op1.tipo = Constantes.T_DOBLE Or op2.tipo = Constantes.T_DOBLE) Then
            Dim val1 As Double = casteo.obtenerDouble(op1)
            Dim val2 As Double = casteo.obtenerDouble(op2)
            If (val1 <= val2) Then
                resultado.valor = "true"
            End If
            Return resultado
        End If

        Dim v1 As Integer = casteo.obtenerInt(op1)
        Dim v2 As Integer = casteo.obtenerInt(op2)
        resultado.valor = "false"
        If (v1 <= v2) Then
            resultado.valor = "true"
        End If
        Return resultado
    End Function

End Class
