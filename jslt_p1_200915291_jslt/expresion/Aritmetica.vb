Public Class Aritmetica

    Private entorno As Entorno = Nothing
    Private casteo As Casteos = New Casteos
    Private comprobacion As ComprobacionTipos = New ComprobacionTipos

    Public Function resolverAritmetica(ByRef ent As Entorno, ByVal expresion As Nodo)
        Dim resultado As Resultado = New Resultado

        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz


        'Casos unitarios
        Select Case expresion.subrol
            Case Constantes.SR_POS_INC
                Return posInc(expresion.cad)
            Case Constantes.SR_POS_DEC
                Return posDec(expresion.cad)
            Case Constantes.SR_PRE_INC
                Return preInc(expresion.cad)
            Case Constantes.SR_PRE_DEC
                Return preDec(expresion.cad)
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
            Case Constantes.SR_SUM
                Return suma(op1, op2)
            Case Constantes.SR_SUB
                Return resta(op1, op2)
            Case Constantes.SR_MUL
                Return multiplicacion(op1, op2)
            Case Constantes.SR_DIV
                Return division(op1, op2)
            Case Constantes.SR_MOD
                Return modulo(op1, op2)
            Case Constantes.SR_POW
                Return potencia(op1, op2)
        End Select
        Return resultado

    End Function

    Private Function incrementar(ByVal tipo As Integer, ByVal valor As String)
        If (tipo = Constantes.T_ENTERO) Then
            valor = Convert.ToString(casteo.castStrToInt(valor) + 1)
        End If
        If (tipo = Constantes.T_DOBLE) Then
            valor = Convert.ToString(casteo.castStrToDoble(valor) + 1.0)
        End If
        If (tipo = Constantes.T_CARACTER) Then
            valor = Convert.ToString(casteo.castIntToChar(casteo.castCharToInt(valor) + 1))
        End If
        Return valor
    End Function

    Private Function decrementar(ByVal tipo As Integer, ByVal valor As String)
        If (tipo = Constantes.T_ENTERO) Then
            valor = Convert.ToString(casteo.castStrToInt(valor) - 1)
        End If
        If (tipo = Constantes.T_DOBLE) Then
            valor = Convert.ToString(casteo.castStrToDoble(valor) - 1.0)
        End If
        If (tipo = Constantes.T_CARACTER) Then
            valor = Convert.ToString(casteo.castIntToChar(casteo.castCharToInt(valor) - 1))
        End If
        Return valor
    End Function

    Private Function posInc(ByVal id As String)
        Dim resultado As Resultado = New Resultado
        Dim obj As Simbolo
        For Each obj In entorno.ctxLocal
            If (obj.nombre = id And obj.instancia And comprobacion.tipoVariacion(obj.tipo) <> Constantes.ERR) Then
                resultado.tipo = obj.tipo
                resultado.valor = obj.valor
                obj.valor = incrementar(obj.tipo, obj.valor)
                Return resultado
            End If
        Next
        For Each obj In entorno.ctxGlobal
            If (obj.nombre = id And obj.instancia And comprobacion.tipoVariacion(obj.tipo) <> Constantes.ERR) Then
                resultado.tipo = obj.tipo
                resultado.valor = obj.valor
                obj.valor = incrementar(obj.tipo, obj.valor)
                Return resultado
            End If
        Next
        Return resultado
    End Function

    Private Function posDec(ByVal id As String)
        Dim resultado As Resultado = New Resultado
        Dim obj As Simbolo
        For Each obj In entorno.ctxLocal
            If (obj.nombre = id And obj.instancia And comprobacion.tipoVariacion(obj.tipo) <> Constantes.ERR) Then
                resultado.tipo = obj.tipo
                resultado.valor = obj.valor
                obj.valor = decrementar(obj.tipo, obj.valor)
                Return resultado
            End If
        Next
        For Each obj In entorno.ctxGlobal
            If (obj.nombre = id And obj.instancia And comprobacion.tipoVariacion(obj.tipo) <> Constantes.ERR) Then
                resultado.tipo = obj.tipo
                resultado.valor = obj.valor
                obj.valor = decrementar(obj.tipo, obj.valor)
                Return resultado
            End If
        Next
        Return resultado
    End Function

    Private Function preInc(ByVal id As String)
        Dim resultado As Resultado = New Resultado
        Dim obj As Simbolo
        For Each obj In entorno.ctxLocal
            If (obj.nombre = id And obj.instancia And comprobacion.tipoVariacion(obj.tipo) <> Constantes.ERR) Then
                obj.valor = incrementar(obj.tipo, obj.valor)
                resultado.tipo = obj.tipo
                resultado.valor = obj.valor
                Return resultado
            End If
        Next
        For Each obj In entorno.ctxGlobal
            If (obj.nombre = id And obj.instancia And comprobacion.tipoVariacion(obj.tipo) <> Constantes.ERR) Then
                obj.valor = incrementar(obj.tipo, obj.valor)
                resultado.tipo = obj.tipo
                resultado.valor = obj.valor
                Return resultado
            End If
        Next
        Return resultado
    End Function

    Private Function preDec(ByVal id As String)
        Dim resultado As Resultado = New Resultado
        Dim obj As Simbolo
        For Each obj In entorno.ctxLocal
            If (obj.nombre = id And obj.instancia And comprobacion.tipoVariacion(obj.tipo) <> Constantes.ERR) Then
                obj.valor = decrementar(obj.tipo, obj.valor)
                resultado.tipo = obj.tipo
                resultado.valor = obj.valor
                Return resultado
            End If
        Next
        For Each obj In entorno.ctxGlobal
            If (obj.nombre = id And obj.instancia And comprobacion.tipoVariacion(obj.tipo) <> Constantes.ERR) Then
                obj.valor = decrementar(obj.tipo, obj.valor)
                resultado.tipo = obj.tipo
                resultado.valor = obj.valor
                Return resultado
            End If
        Next
        Return resultado
    End Function

    Private Function suma(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        If (op1.tipo = Constantes.T_CADENA Or op2.tipo = Constantes.T_CADENA) Then
            resultado.tipo = Constantes.T_CADENA
            resultado.valor = op1.valor + op2.valor
            Return resultado
        End If
        If (op1.tipo = Constantes.T_CARACTER And op2.tipo = Constantes.T_CARACTER) Then
            resultado.tipo = Constantes.T_CADENA
            resultado.valor = op1.valor + op2.valor
            Return resultado
        End If
        If (op1.tipo = Constantes.T_BOOLEAN And op2.tipo = Constantes.T_BOOLEAN) Then
            resultado.tipo = Constantes.T_BOOLEAN
            resultado.valor = "false"
            If (casteo.castStrToBool(op1.valor) Or casteo.castStrToBool(op2.valor)) Then
                resultado.valor = "true"
            End If
            Return resultado
        End If
        If (op1.tipo = Constantes.T_DOBLE Or op2.tipo = Constantes.T_DOBLE) Then
            resultado.tipo = Constantes.T_DOBLE
            Dim val1 As Double = casteo.obtenerDouble(op1)
            Dim val2 As Double = casteo.obtenerDouble(op2)
            resultado.valor = Convert.ToString(val1 + val2)
            Return resultado
        End If
        resultado.tipo = Constantes.T_ENTERO
        Dim v1 As Integer = casteo.obtenerInt(op1)
        Dim v2 As Integer = casteo.obtenerInt(op2)
        resultado.valor = Convert.ToString(v1 + v2)
        Return resultado
    End Function

    Private Function resta(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        If (op1.tipo = Constantes.T_CADENA Or op2.tipo = Constantes.T_CADENA) Then
            Return resultado
        End If
        If (op1.tipo = Constantes.T_DOBLE Or op2.tipo = Constantes.T_DOBLE) Then
            resultado.tipo = Constantes.T_DOBLE
            Dim val1 As Double = casteo.obtenerDouble(op1)
            Dim val2 As Double = casteo.obtenerDouble(op2)
            resultado.valor = Convert.ToString(val1 - val2)
            Return resultado
        End If
        resultado.tipo = Constantes.T_ENTERO
        Dim v1 As Integer = casteo.obtenerInt(op1)
        Dim v2 As Integer = casteo.obtenerInt(op2)
        resultado.valor = Convert.ToString(v1 - v2)
        Return resultado
    End Function

    Private Function multiplicacion(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        If (op1.tipo = Constantes.T_CADENA Or op2.tipo = Constantes.T_CADENA) Then
            Return resultado
        End If
        If (op1.tipo = Constantes.T_BOOLEAN And op2.tipo = Constantes.T_BOOLEAN) Then
            resultado.tipo = Constantes.T_BOOLEAN
            resultado.valor = "false"
            If (casteo.castStrToBool(op1.valor) And casteo.castStrToBool(op2.valor)) Then
                resultado.valor = "true"
            End If
            Return resultado
        End If
        If (op1.tipo = Constantes.T_DOBLE Or op2.tipo = Constantes.T_DOBLE) Then
            resultado.tipo = Constantes.T_DOBLE
            Dim val1 As Double = casteo.obtenerDouble(op1)
            Dim val2 As Double = casteo.obtenerDouble(op2)
            resultado.valor = Convert.ToString(val1 * val2)
            Return resultado
        End If
        resultado.tipo = Constantes.T_ENTERO
        Dim v1 As Integer = casteo.obtenerInt(op1)
        Dim v2 As Integer = casteo.obtenerInt(op2)
        resultado.valor = Convert.ToString(v1 * v2)
        Return resultado
    End Function

    Private Function division(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        If (op1.tipo = Constantes.T_CADENA Or op2.tipo = Constantes.T_CADENA) Then
            Return resultado
        End If
        Dim val1 As Double = casteo.obtenerDouble(op1)
        Dim val2 As Double = casteo.obtenerDouble(op2)
        If (val2 = 0) Then
            'Division entre cero
            Return resultado
        End If
        resultado.tipo = Constantes.T_DOBLE
        resultado.valor = Convert.ToString(val1 / val2)
        Return resultado
    End Function

    Private Function modulo(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        If (op1.tipo = Constantes.T_CADENA Or op2.tipo = Constantes.T_CADENA) Then
            Return resultado
        End If
        If (op1.tipo = Constantes.T_DOBLE Or op2.tipo = Constantes.T_DOBLE) Then
            Dim val1 As Double = casteo.obtenerDouble(op1)
            Dim val2 As Double = casteo.obtenerDouble(op2)
            If (val2 = 0) Then
                'Mod entre cero
                Return resultado
            End If
            resultado.tipo = Constantes.T_ENTERO
            resultado.valor = Convert.ToString(casteo.castDobleToInt(val1 Mod val2))
            Return resultado
        End If
        resultado.tipo = Constantes.T_ENTERO
        Dim v1 As Integer = casteo.obtenerInt(op1)
        Dim v2 As Integer = casteo.obtenerInt(op2)
        If (v2 = 0) Then
            'Mod entre cero
            Return resultado
        End If
        resultado.tipo = Constantes.T_ENTERO
        resultado.valor = Convert.ToString(v1 Mod v2)
        Return resultado
    End Function

    Private Function potencia(ByVal op1 As Resultado, ByVal op2 As Resultado)
        Dim resultado As Resultado = New Resultado
        If (op1.tipo = Constantes.T_CADENA Or op2.tipo = Constantes.T_CADENA) Then
            Return resultado
        End If
        resultado.tipo = Constantes.T_DOBLE
        Dim val1 As Double = casteo.obtenerDouble(op1)
        Dim val2 As Double = casteo.obtenerDouble(op2)
        resultado.valor = Convert.ToString(val1 ^ val2)
        Return resultado
    End Function

End Class
